namespace MyHearthStoneV2.Game.CardLibrary.Filter.Condition.ProfessionCondition
{
    public class MagePro : IProfession
    {
        public Game.Profession Profession { get; set; } = Game.Profession.Mage;
        public bool NoCache { get; set; } = false;
    }
}
