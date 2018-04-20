﻿using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Filter.Context;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Filter;
using MyHearthStoneV2.Game.CardLibrary.Filter.Condition.Quantity;
using MyHearthStoneV2.Game.CardLibrary.Filter.Servant;
using System.Collections.Generic;

namespace MyHearthStoneV2.Game.CardLibrary.Servant.Neutral.GVG
{
    public class PilotedShredder : BaseServant
    {
        public override int Damage { get; set; } = 4;
        public override int Life { get; set; } = 3;
        public override int Cost { get; set; } = 4;

        public override int InitialDamage { get; set; } = 4;
        public override int InitialLife { get; set; } = 3;
        public override int InitialCost { get; set; } = 4;
        
        public override int BuffLife { get; set; } = 3;

        public override string Describe { get; set; } = "亡语：增加召唤一个法力值消耗为（2）点的随从。";

        public override Rarity Rare { get; set; } = Rarity.精良;

        public override List<IBaseCardAbility> Abilities { get; set; } = new List<IBaseCardAbility>() {
            new DeathWhisperDriver<Summon<MainUserContextFilter,RandomServantOfCostFilter<Two>,ONE>, InDeskFilter>()
        };

        public override string BackgroudImage { get; set; } = "GVG/PilotedShredder.jpg";

        public override string Name { get; set; } = "载人收割机";
        public override Profession Profession { get; set; } = Profession.Neutral;
        public override Race Race { get; set; } = Race.机械;

    }
}
