﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface ICategoryDal : IRepositoryDal<Category>
    {
        int CategoryCount();
        string CategoryWithMostTitle();
        int DistinctionBetweenTrueAndFalseInCategory();
        string LongestCategoryName();

    }
}
