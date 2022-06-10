using boxify.Data.ModelsDb;

namespace boxify.ViewModels
{
    public class AdsListViewModel
    {
        public IEnumerable<Ad> Ads { get; set; }
        public string CurrentCategory { get; set; }
    }
}
