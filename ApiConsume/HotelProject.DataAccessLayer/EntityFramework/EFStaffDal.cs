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
    public class EFStaffDal : GenericRepository<Staff>, IStaffDal
    {
        public EFStaffDal(Context context) : base(context)
        {
        }

        public int GetStaffCount()
        {
            using (var context = new Context())
            {
                var value = context.Staffs.Count();
                return value;
            }
        }

        public List<Staff> Last4Staff()
        {
            using (var context = new Context())
            {
                var value = context.Staffs.OrderByDescending(x=> x.StaffID).Take(4).ToList();
                return value;
            }
        }
    }
}
