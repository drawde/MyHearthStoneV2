namespace MyHearthStoneV2.Game.CardLibrary.Hero
{
    public class Shaman : BaseHero
    {
        public override string Name { get; } = "萨满";
        public override Profession Profession { get; set; } = Profession.Shaman;
    }
}
