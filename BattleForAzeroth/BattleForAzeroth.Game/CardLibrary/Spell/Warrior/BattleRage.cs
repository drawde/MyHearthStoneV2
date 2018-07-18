using BattleForAzeroth.Game.CardLibrary.CardAbility;
using BattleForAzeroth.Game.CardLibrary.CardAbility.BaseAbility;
using BattleForAzeroth.Game.Widget.Filter.ParameterFilter;
using BattleForAzeroth.Game.Widget.Filter.Context;
using BattleForAzeroth.Game.CardLibrary.CardAbility.Driver.Spell;
using BattleForAzeroth.Game.Widget.Number.DynamicNumber;
using System.Collections.Generic;
using BattleForAzeroth.Game.Widget.Filter.Biology;

namespace BattleForAzeroth.Game.CardLibrary.Spell.Warrior
{
    public class BattleRage : BaseSpell
    {
        public override Rarity Rare => Rarity.普通;

        public override string Name => "战斗怒火";
        public override int Cost { get; set; }  = 2;
        public override int InitialCost => 2;
        public override string Describe => "每有一个受到伤害的友方角色，便抽一张牌。";

        public override List<ICardAbility> Abilities => new List<ICardAbility>()
        {
            //InjuredCardsFilter
            new NoneTargetSpellDriver<DrawCard<PrimaryUserContextFilter,GetDynamicNumber<InjuredCardsFilter<MyBiologyFilter>>>>()
            //new CA_BattleRage()
        };

        public override string BackgroudImage => "WOW_ACT_056_D_1.png";
        public override Profession Profession => Profession.Warrior;
    }
}
