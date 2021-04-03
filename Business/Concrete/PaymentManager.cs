using Business.Abstract;
using Core.Utilities.Results;
using Entities.DTOs;

namespace Business.Concrete
{
    public class PaymentManager:IPaymentService
    {
        public IResult Pay(PaymentDto paymentDto)
        {
            return new SuccessResult("Ödeme Başarılı");
        }
    }
}