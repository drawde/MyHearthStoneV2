﻿namespace MyHearthStoneV2.Game.CardLibrary.Hero
{
    public class Paladin : BaseHero
    {
        public override string Name { get; } = "圣骑士";
        public override Profession Profession { get; set; } = Profession.Paladin;
    }

}
