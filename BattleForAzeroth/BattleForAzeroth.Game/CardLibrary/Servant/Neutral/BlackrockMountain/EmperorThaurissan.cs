using BattleForAzeroth.Game.CardLibrary.CardAbility;
using BattleForAzeroth.Game.CardLibrary.CardAbility.BaseAbility;
using BattleForAzeroth.Game.CardLibrary.CardAbility.Driver;
using BattleForAzeroth.Game.Widget.Filter.ParameterFilter;
using BattleForAzeroth.Game.Widget.Filter.Context;
using BattleForAzeroth.Game.Widget.Number;
using BattleForAzeroth.Game.Widget.Filter.CardLocationFilter;
using System.Collections.Generic;
using BattleForAzeroth.Game.Widget.Direction;

namespace BattleForAzeroth.Game.CardLibrary.Servant.Neutral.BlackrockMountain
{
    public class EmperorThaurissan : BaseServant
    {
        public override int Damage { get; set; }  = 5;
        public override int Life { get; set; }  = 5;
        public override int Cost { get; set; }  = 6;

        public override int InitialDamage => 5;
        public override int InitialLife => 5;
        public override int InitialCost => 6;

        
        public override int BuffLife { get; set; }  = 5;
        public override string Describe => "在你的回合结束时候，你的所有手牌费用-1。";

        public override Rarity Rare => Rarity.传说;

        public override List<ICardAbility> Abilities => new List<ICardAbility>()
        {
            new MyTurnEndDriver<UpdateCost<PrimaryUserContextFilter,NoneFilter,ONE,Minus>,InDeskFilter>(),
        };


        public override string Name => "索瑞森大帝";

        public override string BackgroudImage => "BlackrockMountain/EmperorThaurissan.jpg";

        public override Profession Profession => Profession.Neutral;
    }
}
