using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ImageManager : IImageService
    {
        private readonly IImageDal _imageDal;

        public ImageManager(IImageDal imageDal)
        {
            _imageDal = imageDal;
        }

        public ImageFile GetByID(int id)
        {
            return _imageDal.Get(x => x.ImageId == id);
        }

        public List<ImageFile> GetList()
        {
            return _imageDal.List();
        }

        public void ImageFileAdd(ImageFile ımageFile)
        {
            _imageDal.Insert(ımageFile);
        }

        public void ImageFileDelete(ImageFile ımageFile)
        {
            _imageDal.Delete(ımageFile);
        }

        public void ImageFileUpdate(ImageFile ımageFile)
        {
            _imageDal.Update(ımageFile);
        }
    }
}
