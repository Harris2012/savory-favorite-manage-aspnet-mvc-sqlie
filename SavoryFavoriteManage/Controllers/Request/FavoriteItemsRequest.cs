using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SavoryFavoriteManage.Controllers.Request
{
    public class FavoriteItemsRequest : FavoriteCountRequest
    {
        public int PageIndex { get; set; }
    }
}
