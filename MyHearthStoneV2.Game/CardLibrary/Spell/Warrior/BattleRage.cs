using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Filter;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Filter.Context;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Spell;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Filter;
using MyHearthStoneV2.Game.CardLibrary.Filter.Biology;
using MyHearthStoneV2.Game.CardLibrary.Filter.Condition.DynamicNumber;
using MyHearthStoneV2.Game.CardLibrary.Filter.Condition.Number;
using System.Collections.Generic;

namespace MyHearthStoneV2.Game.CardLibrary.Spell.Warrior
{
    public class BattleRage : BaseSpell
    {
        public override Rarity Rare { get; set; } = Rarity.普通;

        public override string Name { get; set; } = "战斗怒火";
        public override int Cost { get; set; } = 2;
        public override int InitialCost { get; set; } = 2;
        public override string Describe { get; set; } = "每有一个受到伤害的友方角色，便抽一张牌。";

        public override List<ICardAbility> Abilities { get; set; } = new List<ICardAbility>()
        {
            //InjuredCardsFilter
            new NoneTargetSpellDriver<DrawCard<MainUserContextFilter,GetDynamicNumber<InjuredCardsFilter<MyBiologyFilter>>>>()
            //new CA_BattleRage()
        };

        public override string BackgroudImage { get; set; } = "WOW_ACT_056_D_1.png";
        public override Profession Profession { get; set; } = Profession.Warrior;
    }
}
