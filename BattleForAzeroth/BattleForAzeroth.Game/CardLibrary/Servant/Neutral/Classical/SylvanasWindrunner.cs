
using BattleForAzeroth.Game.CardLibrary.CardAbility;
using BattleForAzeroth.Game.CardLibrary.CardAbility.BaseAbility;
using BattleForAzeroth.Game.CardLibrary.CardAbility.Driver;
using BattleForAzeroth.Game.Widget.Filter.Context;
using BattleForAzeroth.Game.Widget.Filter.ParameterFilter.Servant;
using BattleForAzeroth.Game.Widget.Filter.CardLocationFilter;
using System.Collections.Generic;

namespace BattleForAzeroth.Game.CardLibrary.Servant.Neutral.Classical
{
    public class SylvanasWindrunner : BaseServant
    {
        public override int Damage { get; set; }  = 5;
        public override int Life { get; set; }  = 5;
        public override int Cost { get; set; }  = 6;

        public override int InitialDamage => 5;
        public override int InitialLife => 5;
        public override int InitialCost => 6;
        
        public override int BuffLife { get; set; }  = 5;

        public override string Describe => "控制一个随机敌方随从。";

        public override Rarity Rare => Rarity.传说;

        public override List<ICardAbility> Abilities => new List<ICardAbility>()
        {
            new DeathWhisperDriver<Possession<NotPrimaryUserContextFilter,NotPrimaryRandomServantFilter>,InDeskFilter>(),
        };


        public override string Name => "希尔瓦娜斯·风行者";
        public override string BackgroudImage => "W11_218_D_1.png";
        public override Profession Profession => Profession.Neutral;
    }
}
