using BattleForAzeroth.Game.CardLibrary.CardAbility;
using BattleForAzeroth.Game.CardLibrary.CardAbility.BaseAbility;
using BattleForAzeroth.Game.CardLibrary.CardAbility.Driver;
using BattleForAzeroth.Game.Widget.Filter.ParameterFilter.Servant;
using BattleForAzeroth.Game.Widget.Filter.CardLocationFilter;
using System.Collections.Generic;
using BattleForAzeroth.Game.Widget.Condition.Assert.ServantAssert;
using BattleForAzeroth.Game.Widget.Number;
using BattleForAzeroth.Game.Widget.Filter.Context;

namespace BattleForAzeroth.Game.CardLibrary.Servant.Neutral.Classical
{
    public class AlgalonTheObserver : BaseServant
    {
        public override int Damage { get; set; }  = 5;
        public override int Life { get; set; }  = 5;
        public override int Cost { get; set; }  = 10;

        public override int InitialDamage => 5;
        public override int InitialLife => 5;
        public override int InitialCost => 10;

        public override int BuffLife { get; set; }  = 5;
        public override string Describe => "回合开始时如果你的场上有随从，抽一张牌，否则直接输掉游戏。";

        public override Rarity Rare => Rarity.史诗;

        public override List<ICardAbility> Abilities => new List<ICardAbility>()
        {
            new MyTurnStartDriver<
                Assert<
                    PrimaryUserHasServant,
                    DrawCard<PrimaryUserContextFilter,ONE>,
                    GameOver<PrimaryUserContextFilter>>,
                NullFilter>(),
        };

        public override string Name => "观察者奥尔加隆";
        public override Profession Profession => Profession.Neutral;
        public override string BackgroudImage => "Classical/AlgalonTheObserver.jpg";
    }
}
