using MyHearthStoneV2.CardEnum;
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
    public abstract class BaseHero: IBiology
    {
        /// <summary>
        /// 护甲值
        /// </summary>
        public int Ammo { get; set; }

        public Profession profession { get; set; }

        public int ProfessionSkillTimes { get; set; }
    }
}
