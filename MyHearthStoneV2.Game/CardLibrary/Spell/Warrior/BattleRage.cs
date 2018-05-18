using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility;
using MyHearthStoneV2.Game.Widget.Filter.ParameterFilter;
using MyHearthStoneV2.Game.Widget.Filter.Context;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Spell;
using MyHearthStoneV2.Game.Widget.Number.DynamicNumber;
using System.Collections.Generic;
using MyHearthStoneV2.Game.Widget.Filter.Biology;

namespace MyHearthStoneV2.Game.CardLibrary.Spell.Warrior
{
    public class BattleRage : BaseSpell
    {
        public override Rarity Rare => Rarity.普通;

        public override string Name => "战斗怒火";
        public override int Cost => 2;
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
