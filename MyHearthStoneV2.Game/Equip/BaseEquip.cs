using MyHearthStoneV2.CardLibrary.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.CardLibrary.Equip
{
    public class BaseEquip : Card
    {
        public override CardType CardType { get; set; } = CardType.装备;

        /// <summary>
        /// 耐久度
        /// </summary>
        public virtual int Durable { get; set; }

        /// <summary>
        /// 攻击力
        /// </summary>
        public virtual int Damege { get; set; }
    }
}
