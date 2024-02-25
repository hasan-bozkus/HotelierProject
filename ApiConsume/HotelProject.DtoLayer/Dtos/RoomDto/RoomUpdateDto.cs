using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DtoLayer.Dtos.RoomDto
{
    public class RoomUpdateDto
    {
        public int RoomID { get; set; }

        [Required(ErrorMessage = "Oda Numarasını giriniz")]
        public string RoomNumber { get; set; }

        [Required(ErrorMessage = "Oda görselini giriniz")]
        public string RoomCoverImage { get; set; }

        [Required(ErrorMessage = "Oda Fiyat bilgisini giriniz")]
        public int Price { get; set; }

        [Required(ErrorMessage = "Oda Başlığını giriniz")]
        [StringLength(100, ErrorMessage = "En fazla 100 karakter 100 karakter giriniz.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Oda yatak sayısını giriniz")]
        public string BedCount { get; set; }

        [Required(ErrorMessage = "Banyo sayısını giriniz")]
        public string BathCount { get; set; }

        public string Wifi { get; set; }

        [Required(ErrorMessage = "Açıklamayı giriniz")]
        public string Description { get; set; }
    }
}
