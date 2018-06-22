using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility;
using MyHearthStoneV2.Game.Widget.Number;
using System.Collections.Generic;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Spell;
using MyHearthStoneV2.Game.Widget.Filter.Context;
using MyHearthStoneV2.Game.Widget.Filter.Servant;
using MyHearthStoneV2.Game.Widget.Condition.RaceCondition;
using MyHearthStoneV2.Game.Widget.Filter.PickCard;
using MyHearthStoneV2.Game.Widget.Filter.CardLocationFilter;

namespace MyHearthStoneV2.Game.CardLibrary.Spell.Paladin
{
    public class AnyfinCanHappen : BaseSpell
    {
        public override Rarity Rare => Rarity.精良;

        public override string Name => "亡者归来";
        public override int Cost { get; set; }  = 10;
        public override int InitialCost => 10;
        public override string Describe => "召唤七个在本局对战中死亡的鱼人。";

        public override List<ICardAbility> Abilities => new List<ICardAbility>()
        {
            new NoneTargetSpellDriver
            <
                Summon<PrimaryUserContextFilter,InGraveyardFilter,RaceCardFilter<Murloc>,RandomCardPickFilter<Seven>,ONE>
            >(),
        };

        public override string BackgroudImage => "Paladin/AnyfinCanHappen.jpg";
        public override Profession Profession => Profession.Paladin;
    }
}
