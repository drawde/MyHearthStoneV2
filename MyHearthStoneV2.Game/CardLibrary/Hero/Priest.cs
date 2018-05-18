namespace MyHearthStoneV2.Game.CardLibrary.Hero
{
    public class Priest : BaseHero
    {
        public override string Name => "牧师";
        public override Profession Profession => Profession.Priest;
        public override bool IsEnable => false;
    }
}
