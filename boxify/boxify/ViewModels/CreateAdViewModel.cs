using boxify.Data.ModelsDb;

namespace boxify.ViewModels
{
    public class CreateAdViewModel
    {
        public string Name { get; set; }

        public string Category { get; set; }
        public string ImgUrl { get; set; }

        public decimal Price { get; set; }

        public string PhoneNumber { get; set; }

        public string City { get; set; }

        public string? Description { get; set; }

       

    }
}
