using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SavoryFavoriteManage.Vo;

namespace SavoryFavoriteManage.Controllers.Response
{
    public class FavoriteItemResponse : BaseResponse
    {
        [JsonProperty("item")]
        public FavoriteVo Item { get; set; }
    }
}
