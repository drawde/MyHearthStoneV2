﻿using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver;
using MyHearthStoneV2.Game.Widget.Number;
using MyHearthStoneV2.Game.Widget.Filter.Context;
using System.Collections.Generic;
using MyHearthStoneV2.Game.Widget.Filter.CardLocationFilter;

namespace MyHearthStoneV2.Game.CardLibrary.Servant.Neutral.Classical
{
    public class AcolyteOfPain : BaseServant
    {
        public override int Damage { get; set; }  = 1;
        public override int Life { get; set; }  = 3;
        public override int Cost { get; set; }  = 3;

        public override int InitialDamage => 1;
        public override int InitialLife => 3;
        public override int InitialCost => 3;

        
        public override int BuffLife { get; set; }  = 3;
        public override string Describe => "每当该随从受到伤害时，抽一张牌。";

        public override Rarity Rare => Rarity.史诗;

        public override List<ICardAbility> Abilities => new List<ICardAbility>()
        {
            new HurtDriver<DrawCard<PrimaryUserContextFilter,ONE>,InDeskFilter>()
        };


        public override string Name => "苦痛侍僧";
        public override string BackgroudImage => "W10_A031_D.png";

        public override Profession Profession => Profession.Neutral;
    }
}
