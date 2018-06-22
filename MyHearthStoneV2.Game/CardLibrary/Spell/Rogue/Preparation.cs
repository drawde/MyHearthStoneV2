using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BUFF.ChangeBody;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Spell;
using MyHearthStoneV2.Game.Widget.Filter.CardLocationFilter;

using MyHearthStoneV2.Game.Widget.Direction;
using MyHearthStoneV2.Game.Widget.Number;
using MyHearthStoneV2.Game.Event.GameProcess;
using System.Collections.Generic;
using MyHearthStoneV2.Game.Widget.Filter.ParameterFilter.Spell;

namespace MyHearthStoneV2.Game.CardLibrary.Spell.Rogue
{
    public class Preparation : BaseSpell
    {
        public override Rarity Rare => Rarity.普通;

        public override string Name => "伺机待发";
        public override int Cost { get; set; }  = 0;
        public override int InitialCost => 0;
        public override string Describe => "在本回合中，你所施放的下一个法术的法力值消耗减少（3）点。";

        public override List<ICardAbility> Abilities => new List<ICardAbility>()
        {
            new NoneTargetSpellDriver<
                    ChangeCost<PrimaryHandSpell,Three,ONE,Minus,InHandFilter,
                        RestoreCost<PrimaryHandSpell,Three,ONE,Plus,InHandFilter,MyTurnEndEvent>>>()
        };

        public override string BackgroudImage => "Classical/Preparation.jpg";
        public override Profession Profession => Profession.Rogue;
    }
}
