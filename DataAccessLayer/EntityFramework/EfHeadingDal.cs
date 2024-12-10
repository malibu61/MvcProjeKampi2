using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfHeadingDal : GenericRepository<Heading>, IHeadingDal
    {
        public EfHeadingDal() : base()
        {
        }

        public int SoftwareCategoryCountInHeadingTable()
        {
            using (var context = new Context())
            {
                return context.Headings.Where(x => x.CategoryId == 12).Count();
            }
        }
    }
}
