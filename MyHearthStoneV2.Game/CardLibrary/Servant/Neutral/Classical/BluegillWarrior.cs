namespace MyHearthStoneV2.Game.CardLibrary.Servant.Neutral.Classical
{
    public class BluegillWarrior : BaseServant
    {
        public override int Damage => 2;
        public override int Life => 1;
        public override int Cost => 2;

        public override int InitialDamage => 2;
        public override int InitialLife => 1;
        public override int InitialCost => 2;


        public override int BuffLife => 1;
        public override string Describe => "冲锋。";

        public override Rarity Rare => Rarity.普通;

        public override string Name => "蓝腮战士";

        public override string BackgroudImage => "Classical/BluegillWarrior.jpg";

        public override Profession Profession => Profession.Neutral;
        public override bool HasCharge => true;
        public override Race Race => Race.鱼人;

    }
}
