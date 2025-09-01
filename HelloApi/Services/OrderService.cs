using HelloApi.Models;
using HelloApi.Models.Dtos;
using HelloApi.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HelloApi.Services
{
    public class OrderService : Service<Order>
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IRepository<Person> _personRepository;


        public OrderService(
            IRepository<Order> orderRepository, 
            IOrderDetailRepository orderDetailRepository,
            IRepository<Person> personRepository) : base(orderRepository)
        {
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
            _personRepository = personRepository;
        }

        public async Task<ReadOrderDto> GetInvoice(int id )
        {
            //revusar que trae orderDetails
            var ordersDetails = await _orderDetailRepository.GetByOrderItem(id);
            var order = await _orderRepository.GetByIdAsync(id);
            if (order == null) return null;

            var person = await _personRepository.GetByIdAsync(order.PersonId);
            if (person == null) return null;

            var personDto = new GetPersonDto(person.FirstName, person.LastName, person.Email);

            var readOrderDto = new ReadOrderDto(
                order.Number,
                personDto,
                ordersDetails.Select(e =>
                    new ReadOrderDetailDto(
                        (e.Quantity * e.Price),
                        e.Quantity,
                        e.Price,
                        e.Item.Name
                    )
                ).ToList(),
                order.CreatedAt
            );
            return readOrderDto;
        }

    }
}
