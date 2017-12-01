
using MyHearthStoneV2.CardLibrary.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.CardLibrary.Hero
{
    /// <summary>
    /// 英雄牌基类
    /// </summary>
    public abstract class BaseHero: BaseBiology
    {
        /// <summary>
        /// 护甲值
        /// </summary>
        public virtual int Ammo { get; set; }

        public virtual Profession profession { get; set; }

        public virtual int ProfessionSkillTimes { get; set; }

        public override int Life { get; set; } = 30;
    }
}
