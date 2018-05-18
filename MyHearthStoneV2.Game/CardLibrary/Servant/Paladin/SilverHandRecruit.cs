namespace MyHearthStoneV2.Game.CardLibrary.Servant.Paladin
{
    public class SilverHandRecruit : BaseServant
    {
        public override int Damage => 1;
        public override int Life => 1;
        public override int Cost => 1;

        public override int InitialDamage => 1;
        public override int InitialLife => 1;
        public override int InitialCost => 1;

        public override int BuffLife => 1;
        public override string Describe => "";

        public override Rarity Rare => Rarity.普通;

        public override string Name => "白银之手新兵";
        public override Profession Profession => Profession.Paladin;
        public override string BackgroudImage => "WOW_PAR_039_min_D.png";
        public override bool IsDerivative => true;
    }
}
