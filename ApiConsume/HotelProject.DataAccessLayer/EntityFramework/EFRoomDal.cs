﻿using HotelProject.DataAccessLayer.Abstract;
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
    public class EFRoomDal : GenericRepository<Room>, IRoomDal
    {
        public EFRoomDal(Context context) : base(context)
        {
        }

        public int GetRoomCount()
        {
            using(var context = new Context())
            {
                var values = context.Rooms.Count();
                return values;
            }
        }
    }
}
