using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AuthorManager : IAuthorService
    {
        IAuthorDal _authorDal;

        public AuthorManager(IAuthorDal authorDal)
        {
            _authorDal = authorDal;
        }

        public void AuthorAdd(Author author)
        {
            _authorDal.Insert(author);
        }

        public void AuthorDelete(Author author)
        {
            _authorDal.Delete(author);
        }

        public void AuthorUpdate(Author author)
        {
            _authorDal.Update(author);
        }

        public Author GetByID(int id)
        {
            return _authorDal.Get(x => x.AuthorId == id);
        }

        public List<Author> GetList()
        {
            return _authorDal.List();
        }

        public int TAuthorNameCountIncludeA()
        {
            return _authorDal.AuthorNameCountIncludeA();
        }
    }
}
