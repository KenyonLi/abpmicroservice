using Castle.Core.Logging;
using Hangfire;
using Hangfire.Logging;
using Microsoft.AspNetCore.Mvc.TagHelpers.Cache;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.BackgroundWorkers.Hangfire;

namespace LKN.Order.Orders
{
    /// <summary>
    /// 自动回收库存任务
    /// </summary>
    public class OrderStackWorker : HangfireBackgroundWorkerBase
    {
        public ILogger<OrderStackWorker> _logger { get; set; } //efcore
        public OrderStackWorker()
        {
            RecurringJobId = nameof(OrderStackWorker);
            CronExpression = Cron.MinuteInterval(1);
        }
        public override Task DoWorkAsync(CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Executed OrderStackWorker。。。。");
            //1、遍历订单表
            //2、判断订单是否过期。根据时间字段
            //3、过期的订单，直接回复库存

            return Task.CompletedTask;
        }
    }
}
