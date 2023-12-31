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
using System.Reflection;
using Servicecomb.Saga.Omega.Abstractions.Context;
using Servicecomb.Saga.Omega.Abstractions.Logging;
using ServiceLocator = Servicecomb.Saga.Omega.Abstractions.Transaction.Extensions.ServiceLocator;

namespace Servicecomb.Saga.Omega.Abstractions.Transaction
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Module)]
    public class CompensableAttribute : Attribute
    {
        public int Retries { get; set; }

        public string CompensationMethod { get; set; }

        public int RetryDelayInMilliseconds { get; set; }

        public int Timeout { get; set; }

        private readonly ILogger _logger = LogManager.GetLogger(typeof(SagaStartAttribute));

        private readonly IEventAwareInterceptor _compensableInterceptor;

        private readonly OmegaContext _omegaContext;

        private readonly IRecoveryPolicy _recoveryPolicy;

        private readonly CompensationContext _compensationContext;
        private readonly IMessageSerializer _messageFormat;

        private readonly string _parenttxId;

        protected object InitInstance;

        protected MethodBase InitMethod;

        protected Object[] Args;

        public CompensableAttribute()
        {
        }

        public void Init(object instance, MethodBase method, object[] args)
        {
            InitMethod = method;
            InitInstance = instance;
            Args = args;
        }

        public CompensableAttribute(string compensationMethod, int retryDelayInMilliseconds = 0, int timeout = 0, int retries = 0)
        {
            _omegaContext = (OmegaContext)ServiceLocator.Current.GetInstance(typeof(OmegaContext));
            _compensableInterceptor = (IEventAwareInterceptor)ServiceLocator.Current.GetInstance(typeof(IEventAwareInterceptor));
            _recoveryPolicy = (IRecoveryPolicy)ServiceLocator.Current.GetInstance(typeof(IRecoveryPolicy));
            _compensationContext =
                (CompensationContext)ServiceLocator.Current.GetInstance(typeof(CompensationContext));
            _messageFormat = (IMessageSerializer)ServiceLocator.Current.GetInstance(typeof(IMessageSerializer));
            Retries = retries;
            CompensationMethod = compensationMethod;
            RetryDelayInMilliseconds = retryDelayInMilliseconds;
            Timeout = timeout;
            _parenttxId = _omegaContext.GetGlobalTxId();
        }

        public void OnEntry()
        {
            var type = InitInstance.GetType();
            
            _compensationContext.
                AddCompensationContext
                (type.GetMethod(CompensationMethod, BindingFlags.Instance | BindingFlags.NonPublic), type, InitInstance);

            _omegaContext.NewLocalTxId();
            var paramBytes = _messageFormat.Serialize(Args);

            _logger.Debug($"Initialized context {_omegaContext} before execution of method {InitMethod.Name}");
            _recoveryPolicy.BeforeApply(_compensableInterceptor, _omegaContext, _parenttxId, Retries, Timeout, CompensationMethod, paramBytes);
        }

        public  void OnExit()
        {
            _recoveryPolicy.AfterApply(_compensableInterceptor, _parenttxId, CompensationMethod);
            _logger.Debug($"Transaction with context {_omegaContext} has finished.");
        }

        public  void OnException(Exception exception)
        {
            _logger.Error($"Transaction {_omegaContext.GetGlobalTxId()} failed.", exception);
            _recoveryPolicy.ErrorApply(_compensableInterceptor, _parenttxId, CompensationMethod, exception);
        }

    }
}
