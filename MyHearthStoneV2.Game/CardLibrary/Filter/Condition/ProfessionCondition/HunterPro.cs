﻿namespace MyHearthStoneV2.Game.CardLibrary.Filter.Condition.ProfessionCondition
{
    public class HunterPro : IProfession
    {
        public Game.Profession Profession { get; set; } = Game.Profession.Hunter;
        public bool NoCache { get; set; } = false;
    }
}
