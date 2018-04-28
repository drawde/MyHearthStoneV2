namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.DamageType
{
    public class PhysicalDamage : IDamageType
    {
        public bool NoCache { get; set; } = false;
        ActionType IDamageType.ActionType { get; set; } = ActionType.受到伤害;
    }
}
