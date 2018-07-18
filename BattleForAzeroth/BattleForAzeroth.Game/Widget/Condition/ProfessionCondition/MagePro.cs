namespace BattleForAzeroth.Game.Widget.Condition.ProfessionCondition
{
    public class MagePro : IProfession
    {
        public Game.Profession Profession { get; set; } = Game.Profession.Mage;
        public bool NoCache { get; set; } = false;
    }
}
