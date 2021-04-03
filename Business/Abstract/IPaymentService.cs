using Core.Utilities.Results;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IPaymentService
    {
        IResult Pay(PaymentDto paymentDto);
    }
}