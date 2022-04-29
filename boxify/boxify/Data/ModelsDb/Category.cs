using System.ComponentModel.DataAnnotations;

namespace boxify.Data.ModelsDb
{
    public class Category
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public ICollection<Ad> Items { get; set; } = new HashSet<Ad>();
       
    }
}
