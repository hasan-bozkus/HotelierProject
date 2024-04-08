using AutoMapper;
using HotelProject.BusinnessLayer.Abstract;
using HotelProject.DtoLayer.Dtos.BookingDto;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookignService;
        private readonly IMapper _mapper;

        public BookingController(IBookingService bookignService, IMapper mapper)
        {
            _bookignService = bookignService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = _bookignService.TGetList();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> AddBooking(CreateBookingDto createBookingDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var values = _mapper.Map<Booking>(createBookingDto);
            _bookignService.TInsert(values);

            return Ok("Başarıyla Eklendi");
        }

        [HttpPut("UpdateBooking")]
        public IActionResult UpdateBooking(UpdateBookingDto updateBookingDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var values = _mapper.Map<Booking>(updateBookingDto);
            _bookignService.TUpdate(values);
            return Ok("Başarıyla Güncellendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var values = _bookignService.TGetByID(id);
            _bookignService.TDelete(values);
            return Ok("Başarıyla Silindi");
        }

        [HttpGet("{id}")]
        public IActionResult GetBooking(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var values = _bookignService.TGetByID(id);
            return Ok(values);
        }

        [HttpGet("Last6Bookings")]
        public IActionResult Last6Bookings()
        {
            var values = _bookignService.TLast6Bookings();
            return Ok(values);
        }

        [HttpGet("BookingAproved")]
        public IActionResult BookingAproved(int id)
        {
             _bookignService.TBookingStatusChangeApproved3(id);
            return Ok();
        }

        [HttpGet("BookingCancel")]
        public IActionResult BookingCancel(int id)
        {
             _bookignService.TBookingStatusChangeCancel(id);
            return Ok();
        }

        [HttpGet("BookingWait")]
        public IActionResult BookingWait(int id)
        {
             _bookignService.TBookingStatusChangeWait(id);
            return Ok();
        }
    }
}
