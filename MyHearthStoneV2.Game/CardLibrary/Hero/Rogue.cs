﻿namespace MyHearthStoneV2.Game.CardLibrary.Hero
{
    public class Rogue : BaseHero
    {
        public override string Name { get; } = "盗贼";
        public override Profession Profession { get; set; } = Profession.Rogue;
    }
}
