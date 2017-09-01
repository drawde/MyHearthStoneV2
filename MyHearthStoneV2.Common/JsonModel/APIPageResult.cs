using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.Common.JsonModel
{
    public class APIPageResult<T> : APIResultBase
    {
        public IPagedItemsResult<T> data { get; set; }
    }
}
