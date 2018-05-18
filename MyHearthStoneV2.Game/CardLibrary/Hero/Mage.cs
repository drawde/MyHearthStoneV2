using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.HeroPower;
using MyHearthStoneV2.Game.CardLibrary.Hero;
using System.Collections.Generic;

namespace MyHearthStoneV2.Game.CardLibrary.Hero
{
    public class Mage : BaseHero
    {
        public override string Name => "法师";
        public override Profession Profession => Profession.Mage;
        public override List<ICardAbility> Abilities => new List<ICardAbility>() { new MageAbility() };
        public override bool IsEnable => false;
    }
}
