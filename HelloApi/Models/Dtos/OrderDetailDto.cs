namespace HelloApi.Models.Dtos
{
public record OrderDetailDto(int OrderId, int ItemId, int Quantity);
public record ReadOrderDetailDto(decimal Total, int Quantity, decimal ItemPrice, string ItemName);

    public record CreateOrderDetailDto(int ItemId, int OrderId, int quantity);

    public record GetOrderDetailBy (int orderId, int itemId);
}
