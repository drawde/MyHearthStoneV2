namespace MyHearthStoneV2.Game.CardLibrary.Servant.Neutral.NAXX
{
    public class Slime : BaseServant
    {
        public override int Damage => 1;
        public override int Life => 2;
        public override int Cost => 2;

        public override int InitialDamage => 1;
        public override int InitialLife => 2;
        public override int InitialCost => 2;

        public override int BuffLife => 2;

        public override string Describe => "嘲讽。";

        public override Rarity Rare => Rarity.普通;

        public override bool HasTaunt => true;
        public override string BackgroudImage => "NAXX/SludgeBelcher.png";

        public override string Name => "淤泥怪";
        public override bool IsDerivative => true;
        public override bool CanAttack => false;
        public override Profession Profession => Profession.Neutral;
    }
}
