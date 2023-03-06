using Airbnb.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Airbnbfinal.Services
{
    public interface IHotelService
    {
        public Hotel GetById(int id);
        public bool DeleteById(int id);
        public IEnumerable<Hotel> GetByIds(SearchQuery search);
        public bool IsHotelAvailable(int hotelId, DateTime checkIn, DateTime checkOut);
    }
}
