using BattleForAzeroth.Game.CardLibrary.CardAbility;
using BattleForAzeroth.Game.CardLibrary.CardAbility.BaseAbility;
using BattleForAzeroth.Game.CardLibrary.CardAbility.Driver;
using BattleForAzeroth.Game.Widget.Filter.Context;
using BattleForAzeroth.Game.Widget.Filter.CardLocationFilter;
using BattleForAzeroth.Game.Widget.Number;
using BattleForAzeroth.Game.Widget.Filter.Servant;
using System.Collections.Generic;
using BattleForAzeroth.Game.Widget.Condition.Assert.Survival;
using BattleForAzeroth.Game.Widget.Filter.PickCard;

namespace BattleForAzeroth.Game.CardLibrary.Servant.Neutral.BlackrockMountain
{
    public class GrimPatron : BaseServant
    {
        public override int Damage { get; set; }  = 3;
        public override int Life { get; set; }  = 3;
        public override int Cost { get; set; }  = 5;

        public override int InitialDamage => 3;
        public override int InitialLife => 3;
        public override int InitialCost => 5;

        
        public override int BuffLife { get; set; }  = 3;
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
