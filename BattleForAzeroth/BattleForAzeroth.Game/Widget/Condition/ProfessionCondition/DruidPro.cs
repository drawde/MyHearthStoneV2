namespace BattleForAzeroth.Game.Widget.Condition.ProfessionCondition
{
    public class DruidPro : IProfession
    {
        public bool NoCache { get; set; } = false;
        public Game.Profession Profession { get; set; } = Game.Profession.Druid;
    }
}
