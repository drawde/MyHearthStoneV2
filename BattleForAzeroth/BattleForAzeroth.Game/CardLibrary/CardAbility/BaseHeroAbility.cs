using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleForAzeroth.Game.CardLibrary.CardAbility
{
    public interface IHeroAbility : ICardAbility
    {
        /// <summary>
        /// 技能背景图片
        /// </summary>
        string PowerImage { get; }

        /// <summary>
        /// 技能费用
        /// </summary>
        int Cost { get; set; }
    }
}
