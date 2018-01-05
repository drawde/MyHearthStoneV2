namespace MyHearthStoneV2.Game.CardLibrary.Hero
{
    public class Warrior : BaseHero
    {
        public override string Name { get; } = "战士";
        public override Profession Profession { get; set; } = Profession.Warrior;
    }
}
