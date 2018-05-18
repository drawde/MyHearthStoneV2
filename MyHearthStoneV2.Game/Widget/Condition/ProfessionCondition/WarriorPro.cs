namespace MyHearthStoneV2.Game.Widget.Condition.ProfessionCondition
{
    public class WarriorPro : IProfession
    {
        public Game.Profession Profession { get; set; } = Game.Profession.Warrior;
        public bool NoCache { get; set; } = false;
    }
}
