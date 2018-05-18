namespace MyHearthStoneV2.Game.CardLibrary.Hero
{
    public class Shaman : BaseHero
    {
        public override string Name => "萨满";
        public override Profession Profession => Profession.Shaman;
        public override bool IsEnable => false;
    }
}
