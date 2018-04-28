using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using System.Collections.Generic;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver;
using MyHearthStoneV2.Game.CardLibrary.Filter.Condition.Number;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Filter.Context;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Filter;

namespace MyHearthStoneV2.Game.CardLibrary.Spell.Warrior
{
    public class ShieldBlock : BaseSpell
    {
        public override Rarity Rare { get; set; } = Rarity.普通;

        public override string Name { get; set; } = "盾牌格挡";
        public override int Cost { get; set; } = 3;
        public override int InitialCost { get; set; } = 3;
        public override string Describe { get; set; } = "获得5点护甲。抽1张牌。";

        public override List<ICardAbility> Abilities { get; set; } = new List<ICardAbility>()
        {
            new SpellDriver
                <
                    DoubleActionDriver
                    <
                        AddAmmo<Five>,
                        DrawCard<MainUserContextFilter,ONE>,
                        NullFilter
                    >,NullFilter
                >(),
            //new CA_ShieldBlock()
        };

        public override string BackgroudImage { get; set; } = "WOW_MISC_021_D_1.png";
        public override Profession Profession { get; set; } = Profession.Warrior;
    }
}
