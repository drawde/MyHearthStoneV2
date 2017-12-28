using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.CardLibrary.CardAbility
{
    public abstract class BaseHeroAbility : BaseCardAbility
    {
        /// <summary>
        /// 技能背景图片
        /// </summary>
        public virtual string PowerImage { get; } = "";
    }
}
