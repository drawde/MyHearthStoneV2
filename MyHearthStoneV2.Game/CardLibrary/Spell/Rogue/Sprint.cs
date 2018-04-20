using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver;
using MyHearthStoneV2.Game.CardLibrary.Filter.Condition.Quantity;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Filter.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Filter;

namespace MyHearthStoneV2.Game.CardLibrary.Spell.Rogue
{
    public class Sprint : BaseSpell
    {
        public override Rarity Rare { get; set; } = Rarity.普通;

        public override string Name { get; set; } = "疾跑";
        public override int Cost { get; set; } = 7;
        public override int InitialCost { get; set; } = 7;
        public override string Describe { get; set; } = "抽4张牌。";

        public override List<IBaseCardAbility> Abilities { get; set; } = new List<IBaseCardAbility>()
        {
            new SpellDriver<DrawCard<MainUserContextFilter,Four>,NullFilter>()
        };

        public override string BackgroudImage { get; set; } = "Classical/Sprint.jpg";
        public override Profession Profession { get; set; } = Profession.Rogue;
    }
}
