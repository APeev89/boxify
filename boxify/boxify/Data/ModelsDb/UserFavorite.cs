using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace boxify.Data.ModelsDb
{
    public class UserFavorite
    {
        public string UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public IdentityUser User { get; set; }

        public string FavoriteId { get; set; }

        [ForeignKey(nameof(FavoriteId))]
        public Favourite Favourite { get; set; }
    }
}
