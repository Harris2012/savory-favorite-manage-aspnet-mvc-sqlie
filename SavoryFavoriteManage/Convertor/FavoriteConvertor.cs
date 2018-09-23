using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SavoryFavoriteManage.Meta;
using SavoryFavoriteManage.Controllers.Request;
using SavoryFavoriteManage.Repository.Entity;
using SavoryFavoriteManage.Vo;

namespace SavoryFavoriteManage.Convertor
{
    public class FavoriteConvertor : IFavoriteConvertor
    {

        private ITheCategoryMeta theCategoryMeta;
        private ITheCategoryConvertor theCategoryConvertor;

        public FavoriteConvertor(
            ITheCategoryMeta theCategoryMeta,
            ITheCategoryConvertor theCategoryConvertor
        )
        {
            this.theCategoryMeta = theCategoryMeta;
            this.theCategoryConvertor = theCategoryConvertor;
        }

        public FavoriteEntity toEntity(FavoriteCreateRequest request)
        {
            FavoriteEntity entity = new FavoriteEntity();

            entity.Host = request.Host;
            entity.Title = request.Title;
            entity.CategoryId = request.CategoryId != null ? request.CategoryId.Value : 0;

            return entity;
        }

        public FavoriteEntity toEntity(FavoriteUpdateRequest request)
        {
            FavoriteEntity entity = new FavoriteEntity();

            entity.Id = request.Id;
            entity.Host = request.Host;
            entity.Title = request.Title;
            entity.CategoryId = request.CategoryId != null ? request.CategoryId.Value : 0;

            return entity;
        }

        public FavoriteVo toEmptyVo()
        {
            FavoriteVo vo = new FavoriteVo();

            List<TheCategoryEntity> theCategoryEntityList = theCategoryMeta.GetEntityList();
            vo.CategoryId = theCategoryConvertor.getVoList(theCategoryEntityList);

            return vo;
        }

        public FavoriteVo toLessVo(FavoriteEntity entity)
        {
            FavoriteVo vo = toVo(entity);

            List<TheCategoryEntity> theCategoryEntityList = theCategoryMeta.GetEntityList();
            vo.CategoryId = theCategoryConvertor.getLessVoList(theCategoryEntityList, entity.CategoryId);

            return vo;
        }

        public FavoriteVo toMoreVo(FavoriteEntity entity)
        {
            FavoriteVo vo = toVo(entity);

            List<TheCategoryEntity> theCategoryEntityList = theCategoryMeta.GetEntityList();
            vo.CategoryId = theCategoryConvertor.getMoreVoList(theCategoryEntityList, entity.CategoryId);

            return vo;
        }

        public List<FavoriteVo> toLessVoList(List<FavoriteEntity> entityList)
        {
            if (entityList == null || entityList.Count == 0)
            {
                return null;
            }

            List<FavoriteVo> voList = new List<FavoriteVo>();
            foreach (FavoriteEntity entity in entityList) {
                voList.Add(toLessVo(entity));
            }

            return voList;
        }

        /// <summary>
        /// 将entity转换为vo。不包括来自元数据的属性
        /// </summary>
        private FavoriteVo toVo(FavoriteEntity entity)
        {
            FavoriteVo vo = new FavoriteVo();

            vo.Id = entity.Id;
            vo.Host = entity.Host;
            vo.Title = entity.Title;

            return vo;
        }
    }
}
