using BattleForAzeroth.Game.CardLibrary.CardAbility;
using BattleForAzeroth.Game.CardLibrary.CardAbility.BaseAbility;
using BattleForAzeroth.Game.CardLibrary.CardAbility.Driver;
using BattleForAzeroth.Game.Widget.Filter.ParameterFilter.Servant;
using BattleForAzeroth.Game.CardLibrary.CardAbility.Driver.Spell;
using BattleForAzeroth.Game.Widget.Filter.CardLocationFilter;
using BattleForAzeroth.Game.CardLibrary.Spell;
using System.Collections.Generic;

namespace BattleForAzeroth.Game.CardLibrary.Spell.Rogue
{
    public class Vanish : BaseSpell
    {
        public override Rarity Rare => Rarity.普通;

        public override string Name => "消失";
        public override int Cost { get; set; }  = 6;
        public override int InitialCost => 6;
        public override string Describe => "将所有随从移回其拥有者的手牌。";

        public override List<ICardAbility> Abilities => new List<ICardAbility>()
        {
            new NoneTargetSpellDriver<Recover<AllServantFilter>>(),
            //new CA_Vanish()
        };

        public override string BackgroudImage => "Classical/Vanish.jpg";
        public override Profession Profession => Profession.Rogue;
    }
}
