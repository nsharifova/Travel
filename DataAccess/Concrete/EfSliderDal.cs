
using Core.DataAccess.EntityFrameWork;
using DataAccess.Concrete.EntityFrameWork;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EfSliderDal : EfEntityRepositoryBase<TravelDbContext, Slider>, ISliderDal
    {
    }
}
