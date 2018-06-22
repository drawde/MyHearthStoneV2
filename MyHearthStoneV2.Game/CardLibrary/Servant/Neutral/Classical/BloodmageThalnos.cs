﻿using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver;
using MyHearthStoneV2.Game.Widget.Number;
using MyHearthStoneV2.Game.Widget.Filter.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHearthStoneV2.Game.Widget.Filter.CardLocationFilter;

namespace MyHearthStoneV2.Game.CardLibrary.Servant.Neutral.Classical
{
    public class BloodmageThalnos : BaseServant
    {
        public override int Damage { get; set; }  = 1;
        public override int Life { get; set; }  = 1;
        public override int Cost { get; set; }  = 2;

        public override int InitialDamage => 1;
        public override int InitialLife => 1;
        public override int InitialCost => 2;


        public override int BuffLife { get; set; }  = 1;
        public override string Describe => "法术伤害+1，亡语：抽一张牌。";

        public override Rarity Rare => Rarity.传说;

        public override List<ICardAbility> Abilities => new List<ICardAbility>()
        {
            new DeathWhisperDriver<DrawCard<PrimaryUserContextFilter,ONE>,InDeskFilter>(),
        };


        public override string Name => "血法师萨尔诺斯";
        public override string BackgroudImage => "Classical/BloodmageThalnos.jpg";

        public override Profession Profession => Profession.Neutral;
        public override int SpellPower => 1;
    }
}
