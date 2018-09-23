using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SavoryFavoriteManage.Repository;
using SavoryFavoriteManage.Repository.Entity;

namespace SavoryFavoriteManage.Meta
{
    public class TheCategoryMeta : ITheCategoryMeta
    {
        ITheCategoryRepository theCategoryRepository;

        public TheCategoryMeta(ITheCategoryRepository theCategoryRepository)
        {
            this.theCategoryRepository = theCategoryRepository;
        }

        public List<TheCategoryEntity> GetEntityList()
        {
            return theCategoryRepository.GetEntityList();
        }

        public void Refresh()
        {
            //throw new NotImplementedException();
        }
    }
}
