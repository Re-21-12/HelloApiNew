namespace HelloApi.Models.Dtos
{
public record CreatePersonDto(string FirstName, string LastName, string Email);
    public record GetPersonDto(string FirstName, string LastName, string Email);

}
