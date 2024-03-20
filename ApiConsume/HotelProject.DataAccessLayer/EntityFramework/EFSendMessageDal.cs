using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.Repositories;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.EntityFramework
{
    public class EFSendMessageDal : GenericRepository<SendMessage>, ISendMessageDal
    {
        public EFSendMessageDal(Context context) : base(context)
        {
        }

        public int GetSendMessageCount()
        {
            var context = new Context();
            return context.SendMessages.Count();
        }
    }
}
