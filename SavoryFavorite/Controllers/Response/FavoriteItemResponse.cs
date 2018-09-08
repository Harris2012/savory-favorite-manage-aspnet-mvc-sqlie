using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SavoryFavorite.Vo;

namespace SavoryFavorite.Controllers.Response
{
    public class FavoriteItemResponse : BaseResponse
    {
        [JsonProperty("item")]
        public FavoriteVo Item { get; set; }
    }
}
