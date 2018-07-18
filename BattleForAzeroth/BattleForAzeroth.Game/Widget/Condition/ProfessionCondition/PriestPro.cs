

namespace BattleForAzeroth.Game.Widget.Condition.ProfessionCondition
{
    public class PriestPro : IProfession
    {
        public Game.Profession Profession { get; set; } = Game.Profession.Priest;
        public bool NoCache { get; set; } = false;
    }
}
