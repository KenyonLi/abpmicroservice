﻿/*
 * Licensed to the Apache Software Foundation (ASF) under one or more
 * contributor license agreements.  See the NOTICE file distributed with
 * this work for additional information regarding copyright ownership.
 * The ASF licenses this file to You under the Apache License, Version 2.0
 * (the "License"); you may not use this file except in compliance with
 * the License.  You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Collections.Concurrent;
using System.Reflection;
using System.Text;
using Servicecomb.Saga.Omega.Abstractions.Logging;
using Servicecomb.Saga.Omega.Abstractions.Transaction;
using ServiceLocator = Servicecomb.Saga.Omega.Abstractions.Transaction.Extensions.ServiceLocator;

namespace Servicecomb.Saga.Omega.Abstractions.Context
{
    public class CompensationContext
    {
        private readonly ILogger _logger = LogManager.GetLogger(typeof(CompensationContext));
        private readonly ConcurrentDictionary<string, CompensationContextInternal> _contexts =
                new ConcurrentDictionary<string, CompensationContextInternal>();
        private readonly IServiceProvider _serviceProvider;
        public CompensationContext(IServiceProvider serviceProvider)
        {
            this._serviceProvider = serviceProvider;
        }

        public void AddCompensationContext(MethodInfo compensationMethod, Type target,Object targetObject)
        {
            _contexts.TryAdd(compensationMethod.Name, new CompensationContextInternal(target, targetObject, compensationMethod));
        }

        public void Apply(string globalTxId, string localTxId, string compensationMethod, params byte[] payloads)
        {
            CompensationContextInternal contextInternal = null;

            try
            {
                _contexts.TryGetValue(compensationMethod, out contextInternal);

                // 1、这段代码需要改造
                //  var classInstance = Activator.CreateInstance(contextInternal?.Target ?? throw new InvalidOperationException(), null);
                // 1.1 从ioc容器中获取
                var classInstance = contextInternal.TargetObject;
                // var classInstance = serviceProvider.GetService(contextInternal?.Target ?? throw new InvalidOperationException());
               // classInstance = _serviceProvider.GetService(contextInternal.Target ?? throw new InvalidOperationException());
                // 2、改造为从ioc容器获取对象，而不是新创建
                Console.WriteLine($"补偿方法对象实例为：{classInstance}");
                var messageFormat = (IMessageSerializer)ServiceLocator.Current.GetInstance(typeof(IMessageSerializer));
                var parameterInfos = contextInternal.CompensationMethod.GetParameters();
                

                var result = messageFormat.Deserialize(Encoding.UTF8.GetString(payloads), typeof(object[])) as object[];
                var objects = new object[] { };

                if (result != null)
                {
                    objects = new object[result.Length];
                    for (var index = 0; index < result.Length; index++)
                    {
                        var t = result[index];
                        var tResult = messageFormat.Serialize(t)
                            .Substring(2, messageFormat.Serialize(result[0]).Length - 4).Replace(@"\", "");
                        var typeResult = messageFormat.Deserialize(tResult, parameterInfos[0].ParameterType);
                        objects[index] = typeResult;
                    }
                }
                contextInternal.CompensationMethod.Invoke(classInstance, objects);
                _logger.Info($"Compensated transaction with global tx id [{globalTxId}], local tx id [{localTxId}]");


            }
            catch (TargetInvocationException ex)
            {
                Console.WriteLine(
                  $"Compensated transaction with global tx id [{globalTxId}], local tx id .error(Pre-checking for compensation method {contextInternal?.CompensationMethod.Name} was somehow skipped, did you forget to configure compensable method checking on service startup?{ex}");

            }
        }


        public class CompensationContextInternal
        {
            public Type Target;
            // 增加实例对象(ioc中的对象)
            public object TargetObject;
            public MethodInfo CompensationMethod;

            public CompensationContextInternal(Type target, object targetObject, MethodInfo compensationMethod)
            {
                Target = target;
                TargetObject = targetObject;
                CompensationMethod = compensationMethod;
            }
        }
    }


}
