namespace MyHearthStoneV2.Game.CardLibrary.Hero
{
    public class Hunter: BaseHero
    {
        public virtual new string Name { get; } = "猎人";
        public virtual new Profession Profession { get; } = Profession.Hunter;
    }
}
