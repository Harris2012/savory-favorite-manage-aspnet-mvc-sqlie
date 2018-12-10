using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Web.Http;

using SavoryFavoriteManage.Controllers.Request;
using SavoryFavoriteManage.Controllers.Response;
using SavoryFavoriteManage.Convertor;
using SavoryFavoriteManage.Repository;
using SavoryFavoriteManage.Repository.Entity;

namespace SavoryFavoriteManage.Controllers
{
    [RoutePrefix("api/favorite")]
    public class FavoriteController : BaseController
    {
        /// <summary>
        /// 分页，每页个数
        /// </summary>
        private static readonly int PAGE_SIZE = 15;

        private IFavoriteRepository favoriteRepository;

        private IFavoriteConvertor favoriteConvertor;

        public FavoriteController(
            IFavoriteRepository favoriteRepository,
            IFavoriteConvertor favoriteConvertor)
        {
            this.favoriteRepository = favoriteRepository;
            this.favoriteConvertor = favoriteConvertor;
        }

        [HttpPost]
        [Route("items")]
        public FavoriteItemsResponse Items([FromBody]FavoriteItemsRequest request)
        {
            FavoriteItemsResponse response = new FavoriteItemsResponse();

            List<FavoriteEntity> entityList = favoriteRepository.GetEntityList(request.PageIndex, PAGE_SIZE);

            response.Items = favoriteConvertor.toLessVoList(entityList);

            response.Status = 1;
            return response;
        }

        [HttpPost]
        [Route("count")]
        public FavoriteCountResponse Count([FromBody]FavoriteCountRequest request)
        {
            FavoriteCountResponse response = new FavoriteCountResponse();

            int count = favoriteRepository.GetCount();

            response.TotalCount = count;

            response.Status = 1;
            return response;
        }

        [HttpPost]
        [Route("item")]
        public FavoriteItemResponse Item([FromBody]FavoriteItemRequest request)
        {
            FavoriteItemResponse response = new FavoriteItemResponse();

            if (request.Id <= 0)
            {
                response.Status = -1;
                return response;
            }

            FavoriteEntity entity = favoriteRepository.GetById(request.Id);
            if (entity == null)
            {
                response.Status = 404;
                return response;
            }

            response.Item = favoriteConvertor.toLessVo(entity);

            response.Status = 1;
            return response;
        }

        [HttpPost]
        [Route("create")]
        public FavoriteCreateResponse Create([FromBody]FavoriteCreateRequest request)
        {
            FavoriteCreateResponse response = new FavoriteCreateResponse();

            favoriteRepository.Create(favoriteConvertor.toEntity(request));

            response.Status = 1;
            return response;
        }

        [HttpPost]
        [Route("empty")]
        public FavoriteEmptyResponse Empty([FromBody]FavoriteEditableRequest request)
        {
            FavoriteEmptyResponse response = new FavoriteEmptyResponse();

            response.Item = favoriteConvertor.toEmptyVo();

            response.Status = 1;
            return response;
        }

        [HttpPost]
        [Route("editable")]
        public FavoriteEditableResponse Editable([FromBody]FavoriteEditableRequest request)
        {

            FavoriteEditableResponse response = new FavoriteEditableResponse();

            if (request.Id <= 0)
            {
                response.Status = -1;
                return response;
            }

            FavoriteEntity entity = favoriteRepository.GetById(request.Id);
            if (entity == null)
            {
                response.Status = 404;
                return response;
            }

            response.Item = favoriteConvertor.toMoreVo(entity);

            response.Status = 1;
            return response;
        }

        [HttpPost]
        [Route("update")]
        public FavoriteUpdateResponse Update([FromBody]FavoriteUpdateRequest request)
        {

            FavoriteUpdateResponse response = new FavoriteUpdateResponse();

            if (request.Id == 0 || request.Id < 0)
            {
                response.Status = -1;
                return response;
            }

            FavoriteEntity entity = favoriteRepository.GetById(request.Id);
            if (entity == null)
            {
                response.Status = 404;
                return response;
            }

            favoriteRepository.Update(favoriteConvertor.toEntity(request, entity));

            response.Status = 1;
            return response;
        }
    }
}
