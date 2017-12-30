namespace MyHearthStoneV2.Game.CardLibrary.Hero
{
    public class Priest : BaseHero
    {
        public virtual new string Name { get; } = "牧师";
        public virtual new Profession Profession { get; } = Profession.Priest;
    }
}
