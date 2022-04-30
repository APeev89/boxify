using System.ComponentModel.DataAnnotations.Schema;

namespace boxify.Data.ModelsDb
{
    public class AdTag
    {

        public string AdId { get; set; }

        [ForeignKey(nameof(AdId))]
        public Ad Ad { get; set; }

        public string TagId { get; set; }

        [ForeignKey(nameof(TagId))]
        public Tag Tag { get; set; }
    }
}
