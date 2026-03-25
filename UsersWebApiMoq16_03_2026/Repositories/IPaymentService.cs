using UsersWebApiMoq16_03_2026.DTOs;

namespace UsersWebApiMoq16_03_2026.Repositories
{
    public interface IPaymentService
    {
        Task<PaymentResult> ProcessPayment(PaymentRequest request);
    }
}
