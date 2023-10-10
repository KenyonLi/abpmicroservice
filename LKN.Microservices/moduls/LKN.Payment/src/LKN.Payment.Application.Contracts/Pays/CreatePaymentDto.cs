using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;

namespace LKN.Payment.Pays
{
    /// <summary>
    /// 创建商品Dto
    /// </summary>
    public class CreatePaymentDto
    {
        public string PaymentPrice { set; get; } //  '支付金额',
        public string PaymentStatus { set; get; } //  '支付状态',

    }
}