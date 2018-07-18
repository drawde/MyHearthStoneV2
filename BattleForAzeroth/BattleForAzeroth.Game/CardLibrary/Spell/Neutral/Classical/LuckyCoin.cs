using BattleForAzeroth.Game.CardLibrary.CardAbility;
using BattleForAzeroth.Game.Widget.Number;
using BattleForAzeroth.Game.Widget.Filter.Context;
using System.Collections.Generic;
using BattleForAzeroth.Game.Widget.Filter.CardLocationFilter;
using BattleForAzeroth.Game.CardLibrary.CardAbility.BaseAbility;
using BattleForAzeroth.Game.CardLibrary.CardAbility.Driver.Spell;

namespace BattleForAzeroth.Game.CardLibrary.Spell.Neutral.Classical
{
    public class LuckyCoin: BaseSpell
    {
        public override Rarity Rare => Rarity.普通;

        public override string Name => "幸运币";
        public override int Cost { get; set; }  = 0;
        
        public override string Describe => "";

        public override List<ICardAbility> Abilities => new List<ICardAbility>()
        {
            new NoneTargetSpellDriver<AddPower<PrimaryUserContextFilter,ONE>>(),
            //new AppendPower()
        };

        public override bool IsDerivative => true;
        public override string BackgroudImage => "coin_D_1.png";

        public override Profession Profession => Profession.Neutral;
    }
}
