namespace HelloApi.Models.Dtos
{
public record OrderDto(int Number, int PersonId);
    public record ReadOrderDto(int Number, GetPersonDto Person, List<ReadOrderDetailDto> OrderDetails, DateTime createdAt);

}
