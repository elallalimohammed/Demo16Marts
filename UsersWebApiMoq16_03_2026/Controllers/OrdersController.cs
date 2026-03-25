using Microsoft.AspNetCore.Mvc;
using UsersWebApiMoq16_03_2026.Repositories;

namespace UsersWebApiMoq16_03_2026.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IPaymentService _paymentService;
        private readonly IOrderRepository _orderRepository;
        public OrdersController(IUserService userSetvice,IPaymentService paymentService, IOrderRepository orderRepository)
        {
             _orderRepository = orderRepository;
            _userService = userSetvice;
            _paymentService = paymentService;
        }
    }
}
