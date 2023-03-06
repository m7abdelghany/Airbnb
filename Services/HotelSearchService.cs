using Airbnb.Models;
using Airbnbfinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;



namespace Airbnbfinal.Services
{
    public class HotelSearchService : ISearchService
    {
        public IEnumerable<Hotel> FilterByLocation (IEnumerable<Hotel> hotels, int cityId)
        {
            return hotels.Where(h=>h.City_Id == cityId);
        }
        
        public IEnumerable<Hotel> FilterByNumberOfGuests(IEnumerable<Hotel>hotels, int numberOfGuests)
        {
            return hotels.Where(h => h.Capacity >= numberOfGuests);
        }




        public static bool CheckDates(IEnumerable<DateTime>UnavailableDays, IEnumerable<DateTime> stayDays)
        {
            foreach (var day in stayDays)
            {
                if (UnavailableDays.Contains(day.Date))
                    return false;
            }
            return true;
        }
        public static IEnumerable<DateTime> GetDays (DateTime start, DateTime end)
        {
            while(start.Date < end.Date)
            {
                yield 
                    return start;
                start =start.AddDays(1);
            }
            yield return end;

        }

        IEnumerable<Hotel> ISearchService.FilterByPrice(IEnumerable<Hotel> hotels, decimal minimum, decimal maximum)
        {
            return hotels.Where(h=>h.Price <= minimum && h.Price >= maximum);
        }

        IEnumerable<Hotel> ISearchService.FilterByPlaceTypes(IEnumerable<Hotel> hotels, List<int> PlaceTypeId)
        {
            return hotels.Where(h => PlaceTypeId.Contains(h.Category.CategoryId));
        }
    }
}
