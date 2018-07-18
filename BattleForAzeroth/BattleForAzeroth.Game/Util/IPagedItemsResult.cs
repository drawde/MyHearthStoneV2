using System.Collections.Generic;
namespace BattleForAzeroth.Game.Util
{
    public interface IPagedItemsResult<T>
    {
        IEnumerable<T> Items { get; set; }

        int TotalItemsCount { get; set; }


    }
}
