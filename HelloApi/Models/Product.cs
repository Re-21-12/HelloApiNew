namespace HelloApi.Models
{
    //Esto es una clase
    public class Product
    {
        //Estos son sus atributos
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public List<Detail> Details { get; set; } = [];
    }
}