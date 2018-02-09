﻿using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver;
using MyHearthStoneV2.Game.CardLibrary.CardAction.Controler;
using MyHearthStoneV2.Game.CardLibrary.Spell.Neutral.Classical;
using System.Collections.Generic;

namespace MyHearthStoneV2.Game.CardLibrary.Servant.Neutral.TOC
{
    public class TombPillager : BaseServant
    {
        public override int Damage { get; set; } = 5;
        public override int Life { get; set; } = 4;
        public override int Cost { get; set; } = 4;

        public override int InitialDamage { get; set; } = 5;
        public override int InitialLife { get; set; } = 4;
        public override int InitialCost { get; set; } = 4;

        public override int BuffLife { get; set; } = 4;
        public override string Describe { get; set; } = "亡语：将一个幸运币置入你的手牌。";

        public override Rarity Rare { get; set; } = Rarity.普通;

        public override List<BaseCardAbility> Abilities { get; set; } = new List<BaseCardAbility>() { new DeathWhisperDriver<CreateNewGenericCardInHandAction<LuckyCoin>>() };

        public override string Name { get; set; } = "盗墓匪贼";
        public override Profession Profession { get; set; } = Profession.Rogue;
        public override string BackgroudImage { get; set; } = "TOC/TombPillager.jpg";
    }
}
