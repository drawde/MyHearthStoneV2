using MyHearthStoneV2.CardLibrary.Base;
using MyHearthStoneV2.CardLibrary.Servant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.CardAction
{
    /// <summary>
    /// 卡牌行为接口
    /// </summary>
    public interface IAction
    {
        void Attack(IBiology target);
    }
}
