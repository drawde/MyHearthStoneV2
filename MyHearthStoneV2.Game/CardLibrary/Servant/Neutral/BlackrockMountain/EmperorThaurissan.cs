using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver;
using MyHearthStoneV2.Game.Widget.Filter.ParameterFilter;
using MyHearthStoneV2.Game.Widget.Filter.Context;
using MyHearthStoneV2.Game.Widget.Number;
using MyHearthStoneV2.Game.Widget.Filter.CardLocationFilter;
using System.Collections.Generic;
using MyHearthStoneV2.Game.Widget.Direction;

namespace MyHearthStoneV2.Game.CardLibrary.Servant.Neutral.BlackrockMountain
{
    public class EmperorThaurissan : BaseServant
    {
        public override int Damage => 5;
        public override int Life => 5;
        public override int Cost => 6;

        public override int InitialDamage => 5;
        public override int InitialLife => 5;
        public override int InitialCost => 6;

        
        public override int BuffLife => 5;
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
