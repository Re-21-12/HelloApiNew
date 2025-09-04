using HelloApi.Models.Dtos;
using HelloApi.Services;
using Microsoft.AspNetCore.Mvc;
using HelloApi.Services;
using HelloApi.Models;
namespace HelloApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderDetailController : ControllerBase
    {
        private readonly IService<OrderDetail> _service;
        private readonly IOrderDetailService _orderDetailService;


        public OrderDetailController(IService<OrderDetail> service, IOrderDetailService orderDetailService)
        {
            _service = service;
            _orderDetailService = orderDetailService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var orderDetails = await _service.GetAllAsync();
            return Ok(orderDetails);
        }

        [HttpGet("{orderId}/{itemId}")]
        public async Task<IActionResult> GetByOrderItem(int orderId, int itemId)
        {
           var orderDetails = await _orderDetailService.GetByOrderItem(orderId, itemId);
            return Ok(orderDetails);
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrderDetail([FromBody] CreateOrderDetailDto request)
        {
            var orderDetail = await _orderDetailService.CreateOrderDetailAsync(request.ItemId, request.OrderId,  request.quantity);
            return CreatedAtAction(nameof(GetAll), new { id = orderDetail.OrderId }, orderDetail);
        }

    }
}