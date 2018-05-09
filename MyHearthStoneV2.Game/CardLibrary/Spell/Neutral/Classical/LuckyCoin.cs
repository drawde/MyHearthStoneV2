using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.Filter.Condition.Number;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Filter.Context;
using System.Collections.Generic;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Filter;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Spell;

namespace MyHearthStoneV2.Game.CardLibrary.Spell.Neutral.Classical
{
    public class LuckyCoin: BaseSpell
    {
        public override Rarity Rare { get; set; } = Rarity.普通;

        public override string Name { get; set; } = "幸运币";
        public override int Cost { get; set; } = 0;
        
        public override string Describe { get; set; } = "";

        public override List<ICardAbility> Abilities { get; set; } = new List<ICardAbility>()
        {
            new NoneTargetSpellDriver<AddPower<MainUserContextFilter,ONE>>(),
            //new AppendPower()
        };

        public override bool IsDerivative { get; set; } = true;
        public override string BackgroudImage { get; set; } = "coin_D_1.png";

        public override Profession Profession { get; set; } = Profession.Neutral;
    }
}
