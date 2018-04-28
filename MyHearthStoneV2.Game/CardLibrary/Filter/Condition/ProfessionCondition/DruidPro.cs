namespace MyHearthStoneV2.Game.CardLibrary.Filter.Condition.ProfessionCondition
{
    public class DruidPro : IProfession
    {
        public bool NoCache { get; set; } = false;
        public Game.Profession Profession { get; set; } = Game.Profession.Druid;
    }
}
