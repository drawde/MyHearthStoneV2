using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility
{
    public abstract class BaseHeroAbility : BaseCardAbility
    {
        /// <summary>
        /// 技能背景图片
        /// </summary>
        public virtual string PowerImage { get; } = "";

        /// <summary>
        /// 技能费用
        /// </summary>
        public virtual int Cost { get; set; } = 2;
    }
}
