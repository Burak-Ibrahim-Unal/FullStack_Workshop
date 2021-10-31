using Core.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        IDataResult<List<Category>> GetAllCategories();
        IDataResult<Category> GetById(int categoryId);
        IResult Add(Category p);
        IResult Update(Category p);
    }
}
