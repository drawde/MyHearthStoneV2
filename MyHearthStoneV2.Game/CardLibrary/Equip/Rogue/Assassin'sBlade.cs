namespace MyHearthStoneV2.Game.CardLibrary.Equip.Rogue
{
    public class Assassin_sBlade : BaseEquip
    {
        public override string Name => "刺客之刃";
        public override string BackgroudImage => "Classical/Assassin_sBlade.jpg";

        public override int Damage => 3;

        public override int InitialDamege => 3;
        public override int Durable => 4;
        public override int Cost => 5;
        public override int InitialCost => 5;
        public override string Describe => "";

        public override Profession Profession => Profession.Rogue;
    }
}
