using MyHearthStoneV2.CardLibrary.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.CardLibrary.Servant
{
    public interface BaseServant : Card
    {
        /// <summary>
        /// 生命值
        /// </summary>
        int Life { get; set; }

        /// <summary>
        /// 攻击力
        /// </summary>
        int Damage { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        string Name { get; }

        /// <summary>
        /// 费用
        /// </summary>
        int Cost { get; set; }

        void InChessboard();
        void OutChessboard();
    }
}
