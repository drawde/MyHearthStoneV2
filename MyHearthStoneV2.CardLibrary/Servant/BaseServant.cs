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
    public abstract class BaseServant : IBiology
    {
        

        /// <summary>
        /// 场上位置下标
        /// </summary>
        public int ChessboardIndex { get; set; }
    }
}
