using HelloApi.Models;
using HelloApi.Models.Dtos;
using HelloApi.Repositories;

namespace HelloApi.Services
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IOrderDetailRepository _repository;
        private readonly IService<Item> _ItemRepository;

        public OrderDetailService(IOrderDetailRepository repository, IService<Item> ItemRepository) { 
        
            _repository = repository;
            _ItemRepository = ItemRepository;
        }

        public async Task<OrderDetailDto> CreateOrderDetailAsync(int ItemId, int OrderId,  int quantity)
        {
            var item = await _ItemRepository.GetByIdAsync(ItemId);
            if (item == null)
      throw new Exception("El item no existe.");
            var total = item.Price * quantity;
            var entity = await _repository.AddOrderDetailAsync(ItemId, OrderId, total, item.Price, quantity);
        
            var dto = new OrderDetailDto(entity.OrderId, entity.ItemId, entity.Quantity);
            return dto;
        }

  


        public async Task<IEnumerable<ReadOrderDetailDto>> GetByOrderItem(int orderId, int itemId)
        {
            var entities = await _repository.GetByOrderItem(orderId);
            var item = await _ItemRepository.GetByIdAsync(itemId);

            return entities.Select(e =>
                new ReadOrderDetailDto(
                    item.Price,
                    e.Quantity,
                    e.Total,
                    item.Name
                )
            );
        }

    }
}
