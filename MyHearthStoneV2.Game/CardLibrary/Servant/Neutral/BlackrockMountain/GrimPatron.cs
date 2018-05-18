using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver;
using MyHearthStoneV2.Game.Widget.Filter.Context;
using MyHearthStoneV2.Game.Widget.Filter.CardLocationFilter;
using MyHearthStoneV2.Game.Widget.Number;
using MyHearthStoneV2.Game.Widget.Filter.Servant;
using System.Collections.Generic;
using MyHearthStoneV2.Game.Widget.Condition.Assert.Survival;
using MyHearthStoneV2.Game.Widget.Filter.PickCard;

namespace MyHearthStoneV2.Game.CardLibrary.Servant.Neutral.BlackrockMountain
{
    public class GrimPatron : BaseServant
    {
        public override int Damage => 3;
        public override int Life => 3;
        public override int Cost => 5;

        public override int InitialDamage => 3;
        public override int InitialLife => 3;
        public override int InitialCost => 5;

        
        public override int BuffLife => 3;
        public override string Describe => "每当该随从受到伤害并没有死亡，召唤另一个恐怖的奴隶主。";

        public override Rarity Rare => Rarity.精良;

        public override List<ICardAbility> Abilities => new List<ICardAbility>()
        {
            new HurtDriver<
                Assert<PrimaryCardSurvival,
                    Summon<PrimaryUserContextFilter,NullFilter,AssignServantFilter<GrimPatron>,AllPickFilter,ONE>,
                    Null>
                ,InDeskFilter>()
        };
        public override string BackgroudImage => "BlackrockMountain/GrimPatron.jpg"; 

        public override string Name => "恐怖奴隶主";
        public override Profession Profession => Profession.Neutral;
    }
}
