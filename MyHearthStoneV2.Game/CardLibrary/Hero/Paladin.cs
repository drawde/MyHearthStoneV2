namespace MyHearthStoneV2.Game.CardLibrary.Hero
{
    public class Paladin : BaseHero
    {
        public virtual new string Name { get; } = "圣骑士";
        public virtual new Profession Profession { get; } = Profession.Paladin;
    }

}
