﻿namespace MyHearthStoneV2.Game.CardLibrary.Hero
{
    public class Hunter: BaseHero
    {
        public override string Name { get; } = "猎人";
        public override Profession Profession { get; set; } = Profession.Hunter;
    }
}
