using System.ComponentModel.DataAnnotations;

namespace boxify.Data.ModelsDb
{
    public class Tag
    {

        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        public ICollection<AdTag> AdTags { get; set; } = new HashSet<AdTag>();
    }
}
