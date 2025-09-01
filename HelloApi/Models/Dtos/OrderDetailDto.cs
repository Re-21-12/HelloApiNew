namespace HelloApi.Models.Dtos
{
public record OrderDetailDto(int OrderId, int ItemId, int Quantity);
public record ReadOrderDetailDto(decimal Total, int Quantity, decimal ItemPrice, string ItemName);

}
