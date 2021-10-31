using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public IResult Add(Category p)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Category>> GetAllCategories()
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll(), Messages.CategorysListed);
        }

        public IDataResult<Category> GetById(int categoryId)
        {
            return new SuccessDataResult<Category>(_categoryDal.Get(p => p.CategoryId == categoryId));
        }

        public IResult Update(Category p)
        {
            throw new NotImplementedException();
        }
    }
}


