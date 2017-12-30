namespace MyHearthStoneV2.Game.CardLibrary.Hero
{
    public class Warrior : BaseHero
    {
        public virtual new string Name { get; } = "战士";
        public virtual new Profession Profession { get; } = Profession.Warrior;
    }
}
