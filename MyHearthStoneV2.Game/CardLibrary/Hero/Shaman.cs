namespace MyHearthStoneV2.Game.CardLibrary.Hero
{
    public class Shaman : BaseHero
    {
        public virtual new string Name { get; } = "萨满";
        public virtual new Profession Profession { get; } = Profession.Shaman;
    }
}
