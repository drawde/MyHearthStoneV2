﻿using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Filter;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Filter.Context;
using MyHearthStoneV2.Game.CardLibrary.Filter.Condition.Number;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Filter;
using System.Collections.Generic;
using MyHearthStoneV2.Game.CardLibrary.Filter.Condition.Direction;

namespace MyHearthStoneV2.Game.CardLibrary.Servant.Neutral.BlackrockMountain
{
    public class EmperorThaurissan : BaseServant
    {
        public override int Damage { get; set; } = 5;
        public override int Life { get; set; } = 5;
        public override int Cost { get; set; } = 6;

        public override int InitialDamage { get; set; } = 5;
        public override int InitialLife { get; set; } = 5;
        public override int InitialCost { get; set; } = 6;

        
        public override int BuffLife { get; set; } = 5;
        public override string Describe { get; set; } = "在你的回合结束时候，你的所有手牌费用-1。";

        public override Rarity Rare { get; set; } = Rarity.传说;

        public override List<ICardAbility> Abilities { get; set; } = new List<ICardAbility>()
        {
            new MyTurnEndDriver<UpdateCost<MainUserContextFilter,NoneFilter,ONE,Minus>,InDeskFilter>(),
        };


        public override string Name { get; set; } = "索瑞森大帝";

        public override string BackgroudImage { get; set; } = "BlackrockMountain/EmperorThaurissan.jpg";

        public override Profession Profession { get; set; } = Profession.Neutral;
    }
}
