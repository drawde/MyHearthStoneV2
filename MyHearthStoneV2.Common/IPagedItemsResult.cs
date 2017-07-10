using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.Common
{
    public interface IPagedItemsResult<T>
    {
        IEnumerable<T> Items { get; set; }

        int TotalItemsCount { get; set; }


    }
}
