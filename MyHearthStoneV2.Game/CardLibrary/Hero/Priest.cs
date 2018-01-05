namespace MyHearthStoneV2.Game.CardLibrary.Hero
{
    public class Priest : BaseHero
    {
        public override string Name { get; } = "牧师";
        public override Profession Profession { get; set; } = Profession.Priest;
    }
}
