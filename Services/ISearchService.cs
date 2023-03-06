using Airbnb.Models;
using Airbnbfinal.Models;
using System;
using System.Collections.Generic;

namespace Airbnbfinal.Services
{
    public interface ISearchService
    {
        public IEnumerable<Hotel> FilterByLocation(IEnumerable<Hotel> hotels, int cityId)
            ;
       
        public IEnumerable<Hotel> FilterByNumberOfGuests(IEnumerable<Hotel> hotels, int NumberOfGuests)
            ;
        public IEnumerable<Hotel> FilterByPrice(IEnumerable<Hotel> hotels, decimal minimum, decimal maximum)
            ;
        public IEnumerable<Hotel> FilterByPlaceTypes(IEnumerable<Hotel> hotels, List<int> PlaceTypeId)
            ;
    }
}
