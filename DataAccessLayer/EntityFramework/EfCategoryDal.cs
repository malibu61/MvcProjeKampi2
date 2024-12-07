using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfCategoryDal : GenericRepository<Category>, ICategoryDal
    {
        public EfCategoryDal() : base()
        {
        }

        public int CategoryCount()
        {
            using (var context = new Context())//Ram'i yormamak için using kullanılır
            {
                return context.Categories.Count(); // Tüm kategorilerin sayısını döndürür.
            }
        }
        public string CategoryWithMostTitle()
        {
            using (var context = new Context())
            {
                var categoryId = context.Headings
                                .GroupBy(h => h.CategoryId) // Kategorilere göre gruplama
                                .OrderByDescending(g => g.Count()) // Gruplar arasında başlık sayısına göre azalan sıralama
                                .Select(g => g.Key) // İlk başlık sayısına sahip kategori id'yi seç
                                .FirstOrDefault(); // En fazla başlığa sahip kategori id'si

                return context.Categories
                        .Where(x => x.CategoryId == categoryId) // Kategoriyi id'ye göre filtrele
                        .Select(x => x.CategoryName) // Kategori adını seç
                        .FirstOrDefault(); // İlk bulduğumuz kategoriyi döndür

            }
        }

        public int DistinctionBetweenTrueAndFalseInCategory()
        {
            using (var context = new Context())
            {
                var trueOne = context.Categories.Where(x => x.CategoryStatus == true).Count();
                var falseOne = context.Categories.Where(x => x.CategoryStatus == false).Count();

                return (trueOne - falseOne);

            }
        }

        public string LongestCategoryName()
        {
            using (var context = new Context())
            {
                return context.Categories.OrderByDescending(x => x.CategoryName.Length).Select(x => x.CategoryName).FirstOrDefault();

            }
        }
    }
}
