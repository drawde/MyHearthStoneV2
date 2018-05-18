
namespace MyHearthStoneV2.Game.Widget.Condition.ProfessionCondition
{
    public class ShamanPro : IProfession
    {
        public Game.Profession Profession { get; set; } = Game.Profession.Shaman;
        public bool NoCache { get; set; } = false;
    }
}
