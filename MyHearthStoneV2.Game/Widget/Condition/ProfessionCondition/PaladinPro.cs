namespace MyHearthStoneV2.Game.Widget.Condition.ProfessionCondition
{
    public class PaladinPro : IProfession
    {
        public Game.Profession Profession { get; set; } = Game.Profession.Paladin;
        public bool NoCache { get; set; } = false;
    }
}
