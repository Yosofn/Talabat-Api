namespace Talabat.DTO
{
    public class ProductDTo
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Descriprion { get; set; }

        public decimal Price { get; set; }

        public string PictureUrl { get; set; }

        public string brands { get; set; }
        public int ProductBrandId { get; set; }

        public string types { get; set; }
        public int ProductTypeId { get; set; }

    }
}
