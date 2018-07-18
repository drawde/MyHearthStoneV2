
namespace BattleForAzeroth.Game.Widget.Condition.ProfessionCondition
{
    public class WarlockPro : IProfession
    {
        public Game.Profession Profession { get; set; } = Game.Profession.Warlock;
        public bool NoCache { get; set; } = false;
    }
}
