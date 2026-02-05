using BusinessObjects;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository iCatergoryRepository;
        public CategoryService(ICategoryRepository catergoryRepository)
        {
            iCatergoryRepository = catergoryRepository;
        }
        public List<Category> GetCategories() => iCatergoryRepository.GetCategories();
    }
}
