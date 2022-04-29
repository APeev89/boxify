using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace boxify.Data.ModelsDb
{
    public class Coment
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [StringLength(500)]
        public string Text { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime DateFrom { get; set; } = DateTime.Now;

        [Required]
        public string AdId { get; set; }

        [ForeignKey(nameof(AdId))]
        public Ad Ad { get; set; }

        [Required]
        public string UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public IdentityUser User { get; set; }
    }
}
