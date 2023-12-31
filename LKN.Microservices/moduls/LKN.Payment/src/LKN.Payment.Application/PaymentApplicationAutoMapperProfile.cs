﻿using AutoMapper;
using LKN.Payment.Pays;

namespace LKN.Payment;

public class PaymentApplicationAutoMapperProfile : Profile
{
    public PaymentApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<CreatePaymentDto, Payments>();

        CreateMap<Payments, PaymentDto>();
    }
}
