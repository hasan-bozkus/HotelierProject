using AutoMapper;
using HotelProject.DtoLayer.Dtos.BookingDto;
using HotelProject.DtoLayer.Dtos.RoomDto;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.WebApi.Mapping
{
    public class AutoMapperConfig : Profile
    {

        public AutoMapperConfig() 
        {
            CreateMap<RoomAddDto, Room>();
            CreateMap<Room, RoomAddDto>();

            CreateMap<RoomUpdateDto, Room>().ReverseMap();

            CreateMap<ResultBookingDto, Booking>().ReverseMap();
            CreateMap<CreateBookingDto, Booking>().ReverseMap();
            CreateMap<UpdateBookingDto, Booking>().ReverseMap();
        }
    }
}
