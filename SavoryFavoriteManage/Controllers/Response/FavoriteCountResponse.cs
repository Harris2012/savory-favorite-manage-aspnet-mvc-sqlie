using SavoryFavoriteManage.Vo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SavoryFavoriteManage.Controllers.Response
{
    public class FavoriteCountResponse : BaseResponse
    {
        [JsonProperty("totalCount")]
        public int TotalCount { get; set; }
    }
}
