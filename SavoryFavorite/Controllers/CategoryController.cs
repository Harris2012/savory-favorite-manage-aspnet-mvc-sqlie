using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Web.Http;

using SavoryFavorite.Controllers.Request;
using SavoryFavorite.Controllers.Response;
using SavoryFavorite.Convertor;
using SavoryFavorite.Repository;
using SavoryFavorite.Repository.Entity;
using SavoryFavorite.Meta;

namespace SavoryFavorite.Controllers
{
    [RoutePrefix("api/category")]
    public class CategoryController : BaseController
    {
        /// <summary>
        /// 分页，每页个数
        /// </summary>
        private static readonly int PAGE_SIZE = 15;

        private ICategoryRepository categoryRepository;

        private ICategoryConvertor categoryConvertor;

        private ITheCategoryMeta theCategoryMeta;

        public CategoryController(
            ITheCategoryMeta theCategoryMeta,
            ICategoryRepository categoryRepository,
            ICategoryConvertor categoryConvertor)
        {
            this.categoryRepository = categoryRepository;
            this.categoryConvertor = categoryConvertor;
            this.theCategoryMeta = theCategoryMeta;
        }

        [HttpPost]
        [Route("items")]
        public CategoryItemsResponse Items([FromBody]CategoryItemsRequest request)
        {
            CategoryItemsResponse response = new CategoryItemsResponse();

            List<CategoryEntity> entityList = categoryRepository.GetEntityList(request.PageIndex, PAGE_SIZE);

            response.Items = categoryConvertor.toLessVoList(entityList);

            response.Status = 1;
            return response;
        }

        [HttpPost]
        [Route("count")]
        public CategoryCountResponse Count([FromBody]CategoryCountRequest request)
        {
            CategoryCountResponse response = new CategoryCountResponse();

            int count = categoryRepository.GetCount();

            response.TotalCount = count;

            response.Status = 1;
            return response;
        }

        [HttpPost]
        [Route("item")]
        public CategoryItemResponse Item([FromBody]CategoryItemRequest request)
        {
            CategoryItemResponse response = new CategoryItemResponse();

            if (request.Id <= 0)
            {
                response.Status = -1;
                return response;
            }

            CategoryEntity entity = categoryRepository.GetById(request.Id);
            if (entity == null)
            {
                response.Status = 404;
                return response;
            }

            response.Item = categoryConvertor.toLessVo(entity);

            response.Status = 1;
            return response;
        }

        [HttpPost]
        [Route("create")]
        public CategoryCreateResponse Create([FromBody]CategoryCreateRequest request)
        {
            CategoryCreateResponse response = new CategoryCreateResponse();

            categoryRepository.Create(categoryConvertor.toEntity(request));

            theCategoryMeta.Refresh();

            response.Status = 1;
            return response;
        }

        [HttpPost]
        [Route("empty")]
        public CategoryEmptyResponse Empty([FromBody]CategoryEditableRequest request)
        {
            CategoryEmptyResponse response = new CategoryEmptyResponse();

            response.Item = categoryConvertor.toEmptyVo();

            response.Status = 1;
            return response;
        }

        [HttpPost]
        [Route("editable")]
        public CategoryEditableResponse Editable([FromBody]CategoryEditableRequest request)
        {

            CategoryEditableResponse response = new CategoryEditableResponse();

            if (request.Id <= 0)
            {
                response.Status = -1;
                return response;
            }

            CategoryEntity entity = categoryRepository.GetById(request.Id);
            if (entity == null)
            {
                response.Status = 404;
                return response;
            }

            response.Item = categoryConvertor.toMoreVo(entity);

            response.Status = 1;
            return response;
        }

        [HttpPost]
        [Route("update")]
        public CategoryUpdateResponse Update([FromBody]CategoryUpdateRequest request)
        {

            CategoryUpdateResponse response = new CategoryUpdateResponse();

            if (request.Id == 0 || request.Id < 0)
            {
                response.Status = -1;
                return response;
            }

            CategoryEntity entity = categoryRepository.GetById(request.Id.Value);
            if (entity == null)
            {
                response.Status = 404;
                return response;
            }

            categoryRepository.Update(categoryConvertor.toEntity(request));

            theCategoryMeta.Refresh();

            response.Status = 1;
            return response;
        }
    }
}
