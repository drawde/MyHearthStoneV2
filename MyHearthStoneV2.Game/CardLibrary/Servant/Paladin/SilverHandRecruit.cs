namespace MyHearthStoneV2.Game.CardLibrary.Servant.Paladin
{
    public class SilverHandRecruit : BaseServant
    {
        public override int Damage { get; set; }  = 1;
        public override int Life { get; set; }  = 1;
        public override int Cost { get; set; }  = 1;

        public override int InitialDamage => 1;
        public override int InitialLife => 1;
        public override int InitialCost => 1;

        public override int BuffLife { get; set; }  = 1;
        public override string Describe => "";

        public override Rarity Rare => Rarity.普通;

        public override string Name => "白银之手新兵";
        public override Profession Profession => Profession.Paladin;
        public override string BackgroudImage => "WOW_PAR_039_min_D.png";
        public override bool IsDerivative => true;
    }
}
