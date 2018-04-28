﻿namespace MyHearthStoneV2.Game.CardLibrary.Filter.Condition.Number
{
    public class Two : INumber
    {
        public bool NoCache { get; set; } = false;
        public int Number { get; set; } = 2;
        public int GetNumber(Parameter.BaseActionParameter actionParameter)
        {
            return 2;
        }
    }
}
