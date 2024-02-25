using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DtoLayer.Dtos.RoomDto
{
    public class RoomAddDto
    {
        [Required(ErrorMessage = "Oda numarasını yazınız")]
        public string RoomNumber { get; set; }
        public string RoomCoverImage { get; set; }

        [Required(ErrorMessage = "Fiyat bilgisini giriniz")]
        public int Price { get; set; }

        [Required(ErrorMessage = "Oda başlığını giriniz")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Yatak sayısını giriniz")]
        public string BedCount { get; set; }

        [Required(ErrorMessage = "Banyo sayısını giriniz")]
        public string BathCount { get; set; }

        public string Wifi { get; set; }

        public string Description { get; set; }
    }
}
