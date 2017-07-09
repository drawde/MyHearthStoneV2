using MyHearthStoneV2.CardLibrary.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.CardLibrary.Servant
{
    /// <summary>
    /// 随从基类
    /// </summary>
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
        /// 费用
        /// </summary>
        int Cost { get; set; }

        /// <summary>
        /// 场上位置下标
        /// </summary>
        int ChessboardIndex { get; set; }
        void InChessboard();
        void OutChessboard();
        List<BuffTime> LstBuff { get; set; }
    }
}
