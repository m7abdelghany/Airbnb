using Airbnbfinal.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Stripe;
using Airbnbfinal.Services;
using Airbnb.Models;
using Airbnbfinal.Models.Payment;
using Airbnbfinal.Models;

namespace Airbnbfinal.Controllers
{
    // [ApiController]
    // [Authorize]
    public class PaymentController : Controller
        {
            IHotelService hotelService;
            private readonly UserManager<AppUser> _userManager;
            ApplicationDbContext _db;

            public PaymentController(IHotelService service, UserManager<AppUser> userManager, ApplicationDbContext db)
            {
                hotelService = service;
                _userManager = userManager;
                _db = db;
            }
            public IActionResult Index()
            {
                return View("index");
            }

            public IActionResult book(int id, string checkIn, string checkOut, int guests)
            {
                var UserId = _userManager.GetUserId(User);
                var hotel = hotelService.GetById(id);

                if (UserId == hotel.UserId)
                    return RedirectToAction("Listing", "Hosting");

                var checkInSplitted = checkIn.Split('-');
                var checkOutSplitted = checkOut.Split('-');

                var checkInDate = new DateTime(int.Parse(checkInSplitted[0]), int.Parse(checkInSplitted[1]), int.Parse(checkInSplitted[2]));
                var checkOutDate = new DateTime(int.Parse(checkOutSplitted[0]), int.Parse(checkOutSplitted[1]), int.Parse(checkOutSplitted[2]));

                var diff = (checkOutDate - checkInDate).Days + 1;


                if (!hotelService.IsHotelAvailable(id, checkInDate, checkOutDate))
                {
                  return BadRequest();
                
                }

                ViewBag.checkIn = checkInDate;
                ViewBag.checkOut = checkOutDate;
                ViewBag.days = diff;
                ViewBag.hotel = hotel;
                ViewBag.guests = guests;

                return View();
            }

            [HttpPost]
            public async Task<dynamic> book(CreditCard payData, int id, string checkIn, string checkOut, int guests)
            {
                var checkInSplitted = checkIn.Split('-');
                var checkOutSplitted = checkOut.Split('-');

                var checkInDate = new DateTime(int.Parse(checkInSplitted[0]), int.Parse(checkInSplitted[1]), int.Parse(checkInSplitted[2]));
                var checkOutDate = new DateTime(int.Parse(checkOutSplitted[0]), int.Parse(checkOutSplitted[1]), int.Parse(checkOutSplitted[2]));

                var diff = (checkOutDate - checkInDate).Days + 1;
                var hotel = hotelService.GetById(id);

                if (!hotelService.IsHotelAvailable(id, checkInDate, checkOutDate))
                {
                    return BadRequest();
                }

                ViewBag.checkIn = checkInDate;
                ViewBag.checkOut = checkOutDate;
                ViewBag.days = diff;
                ViewBag.hotel = hotel;
                ViewBag.guests = guests;

                if (ModelState.IsValid)
                {
                    dynamic result = await Services.Payment.MakePayment.PayAsync(payData.Number, payData.Month, payData.Year, payData.CVV, payData.Value, payData.Name, payData.Zipcode, payData.usercity);

                    switch (result.state)
                    {
                        case "Success":
                            Booking booking = new Booking()
                            {
                                Hotel_Id = id,
                                DateFrom = checkInDate,
                                DateTo = checkOutDate,
                                UserId = _userManager.GetUserId(User),
                                NumberOfGuests = guests,
                            };
                            _db.Add(booking);
                            _db.SaveChanges();

                            Transaction transaction = new Transaction()
                            {
                                ReservationId = booking.BookingId,
                                Amount = result.amount,
                                Id = result.transactionId,
                            };
                            _db.Add(transaction);
                            _db.SaveChanges();

                         

                            return View("SucceessfulPayment");
                        case "Your card number is incorrect.":
                            ModelState.AddModelError("Number", "Your card number is incorrect");
                            return View();
                        case "Your card's expiration year is invalid.":
                            ModelState.AddModelError("Year", "Your card's expiration year is invalid");
                            return View();
                        case "Your card's expiration month is invalid":
                            ModelState.AddModelError("Month", "Your card's expiration month is invalid");
                            return View();
                        case "Amount must be no more than $999,999.99":
                            ModelState.AddModelError("Value", "Amount must be no more than $999,999.99");
                            return View();
                        case "This value must be greater than or equal to 1.":
                            ModelState.AddModelError("Value", "This value must be greater than or equal to 1");
                            return View();
                        default:
                            return View();
                    }

                }
                else
                {
                    return View();
                }
            }
        }


    }



