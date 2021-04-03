using System;
using Core.Entities;

namespace Entities.DTOs
{
    public class PaymentDto:IDto
    {
        public string CreditCardNumber { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int Cvv { get; set; }
        public decimal Amount { get; set; }
    }
}