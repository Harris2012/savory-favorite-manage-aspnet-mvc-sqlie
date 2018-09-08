using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SavoryFavorite.Vo
{
    public class TheCategoryVo
    {
        [JsonProperty("categoryId")]
        public int CategoryId { get; set; }

        [JsonProperty("cateoryName")]
        public string CateoryName { get; set; }

        [JsonProperty("selected")]
        public bool Selected { get; set; }
    }
}
