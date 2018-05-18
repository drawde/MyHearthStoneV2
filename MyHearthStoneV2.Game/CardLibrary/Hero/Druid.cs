using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.HeroPower;
using MyHearthStoneV2.Game.CardLibrary.Hero;
using System.Collections.Generic;

namespace MyHearthStoneV2.Game.CardLibrary.Hero
{
    public class Druid : BaseHero
    {
        public override string Name => "德鲁伊";
        public override Profession Profession => Profession.Druid;
        public override List<ICardAbility> Abilities => new List<ICardAbility>() { new DruidAbility() };
        public override bool IsEnable => false;
    }
}
