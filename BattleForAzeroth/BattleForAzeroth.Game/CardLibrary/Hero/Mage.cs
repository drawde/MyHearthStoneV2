using BattleForAzeroth.Game.CardLibrary.CardAbility;
using BattleForAzeroth.Game.CardLibrary.CardAbility.HeroPower;
using BattleForAzeroth.Game.CardLibrary.Hero;
using System.Collections.Generic;

namespace BattleForAzeroth.Game.CardLibrary.Hero
{
    public class Mage : BaseHero
    {
        public override string Name => "法师";
        public override Profession Profession => Profession.Mage;
        public override List<ICardAbility> Abilities => new List<ICardAbility>() { new MageAbility() };
        public override bool IsEnable => false;
    }
}
