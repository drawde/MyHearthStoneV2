namespace BattleForAzeroth.Game.CardLibrary.Hero
{
    public class Hunter: BaseHero
    {
        public override string Name => "猎人";
        public override Profession Profession => Profession.Hunter;
        public override bool IsEnable => false;
    }
}
