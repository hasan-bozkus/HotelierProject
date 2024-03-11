using System;

namespace HotelProject.WebUI.Dtos.ContactDto
{
    public class GetMessageByIDDto
    {
        public int SendMessageID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string RecevierName { get; set; }
        public string RecevierMail { get; set; }
        public string SenderName { get; set; }
        public string SenderMail { get; set; }
        public DateTime Date { get; set; }
    }
}
