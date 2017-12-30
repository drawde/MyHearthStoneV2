namespace MyHearthStoneV2.Game.CardLibrary.Hero
{
    public class Rogue : BaseHero
    {
        public virtual new string Name { get; } = "盗贼";
        public virtual new Profession Profession { get; } = Profession.Rogue;
    }
}
