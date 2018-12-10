using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SavoryFavoriteManage.Vo;

namespace SavoryFavoriteManage.Controllers.Response
{
    public class CategoryEditableResponse : BaseResponse
    {
        [JsonProperty("item")]
        public CategoryVo Item { get; set; }
    }
}
