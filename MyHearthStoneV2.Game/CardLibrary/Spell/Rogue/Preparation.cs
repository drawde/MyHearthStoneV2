using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BUFF.ChangeBody;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Filter;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Filter.Spell;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Spell;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Filter;

using MyHearthStoneV2.Game.CardLibrary.Filter.Condition.Direction;
using MyHearthStoneV2.Game.CardLibrary.Filter.Condition.Number;
using MyHearthStoneV2.Game.Event.GameProcess;
using System.Collections.Generic;

namespace MyHearthStoneV2.Game.CardLibrary.Spell.Rogue
{
    public class Preparation : BaseSpell
    {
        public override Rarity Rare { get; set; } = Rarity.普通;

        public override string Name { get; set; } = "伺机待发";
        public override int Cost { get; set; } = 0;
        public override int InitialCost { get; set; } = 0;
        public override string Describe { get; set; } = "在本回合中，你所施放的下一个法术的法力值消耗减少（3）点。";

        public override List<ICardAbility> Abilities { get; set; } = new List<ICardAbility>()
        {
            new NoneTargetSpellDriver<
                    ChangeCost<MainHandSpell,Three,ONE,Minus,InHandFilter,
                        RestoreCost<MainHandSpell,Three,ONE,Plus,InHandFilter,MyTurnEndEvent>>>()
        };

        public override string BackgroudImage { get; set; } = "Classical/Preparation.jpg";
        public override Profession Profession { get; set; } = Profession.Rogue;
    }
}
