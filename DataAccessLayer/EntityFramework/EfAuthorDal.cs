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
    public class EfAuthorDal : GenericRepository<Author>, IAuthorDal
    {
        public EfAuthorDal() : base()
        {
        }

        public int AuthorNameCountIncludeA()
        {
            using (var context = new Context())
            {
                return context.Authors.Where(x => x.AuthorName.Contains("a")).Count();
            }
        }
    }
}
