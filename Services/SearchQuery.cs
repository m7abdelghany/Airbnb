using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;

namespace Airbnbfinal.Services
{
    public class SearchQuery
    {
        [Required]
        public int CityId { get; set; }
        public DateTime? CheckIn { get; set; }
        public DateTime? CheckOut { get; set; }
        public int? NumberOfGuests { get; set; }
        public decimal? MinimumPrice { get; set; }
        public decimal? MaximumPrice { get; set;}
        [BindProperty]
        public List<int> PlaceTypeIds { get; set; } //category

    }
}
