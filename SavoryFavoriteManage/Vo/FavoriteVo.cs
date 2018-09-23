using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SavoryFavoriteManage.Vo
{
    public class FavoriteVo
    {

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("host")]
        public string Host { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("categoryId")]
        public List<TheCategoryVo> CategoryId { get; set; }
    }
}
