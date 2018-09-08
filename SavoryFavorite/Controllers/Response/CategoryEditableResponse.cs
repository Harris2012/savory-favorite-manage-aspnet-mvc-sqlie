using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SavoryFavorite.Vo;

namespace SavoryFavorite.Controllers.Response
{
    public class CategoryEditableResponse : BaseResponse
    {
        [JsonProperty("item")]
        public CategoryVo Item { get; set; }
    }
}
