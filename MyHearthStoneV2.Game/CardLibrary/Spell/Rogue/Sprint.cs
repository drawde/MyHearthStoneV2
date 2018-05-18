using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility;
using MyHearthStoneV2.Game.Widget.Number;
using MyHearthStoneV2.Game.Widget.Filter.Context;
using System.Collections.Generic;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Spell;

namespace MyHearthStoneV2.Game.CardLibrary.Spell.Rogue
{
    public class Sprint : BaseSpell
    {
        public override Rarity Rare => Rarity.普通;

        public override string Name => "疾跑";
        public override int Cost => 7;
        public override int InitialCost => 7;
        public override string Describe => "抽4张牌。";

        public override List<ICardAbility> Abilities => new List<ICardAbility>()
        {
            new NoneTargetSpellDriver<DrawCard<PrimaryUserContextFilter,Four>>()
        };

        public override string BackgroudImage => "Classical/Sprint.jpg";
        public override Profession Profession => Profession.Rogue;
    }
}
