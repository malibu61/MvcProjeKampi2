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
    public class EfAdminDal : GenericRepository<Admin>, IAdminDal
    {
        public EfAdminDal() : base()
        {
        }

        public bool AdminLoginVerification(string _username, string _password)
        {
            using (var context = new Context())
            {
                var values = context.Admins.Where(x => x.AdminUserName == _username && x.AdminPassword == _password).FirstOrDefault();

                if (values != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
