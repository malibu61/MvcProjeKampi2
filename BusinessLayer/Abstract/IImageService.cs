using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IImageService
    {
        List<ImageFile> GetList();
        void ImageFileAdd(ImageFile ımageFile);
        void ImageFileDelete(ImageFile ımageFile);
        void ImageFileUpdate(ImageFile ımageFile);
        ImageFile GetByID(int id);
    }
}
