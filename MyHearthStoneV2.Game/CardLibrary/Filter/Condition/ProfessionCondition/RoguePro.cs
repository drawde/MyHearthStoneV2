
namespace MyHearthStoneV2.Game.CardLibrary.Filter.Condition.ProfessionCondition
{
    public class RoguePro : IProfession
    {
        public Game.Profession Profession { get; set; } = Game.Profession.Rogue;
        public bool NoCache { get; set; } = false;
    }
}
