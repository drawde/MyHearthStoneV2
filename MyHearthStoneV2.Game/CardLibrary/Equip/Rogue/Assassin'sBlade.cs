namespace MyHearthStoneV2.Game.CardLibrary.Equip.Rogue
{
    public class Assassin_sBlade : BaseEquip
    {
        public override string Name { get; set; } = "刺客之刃";
        public override string BackgroudImage { get; set; } = "Classical/Assassin_sBlade.jpg";

        public override int Damage { get; set; } = 3;

        public override int InitialDamege { get; set; } = 3;
        public override int Durable { get; set; } = 4;
        public override int Cost { get; set; } = 5;
        public override int InitialCost { get; set; } = 5;
        public override string Describe { get; set; } = "";

        public override Profession Profession { get; set; } = Profession.Rogue;
    }
}
