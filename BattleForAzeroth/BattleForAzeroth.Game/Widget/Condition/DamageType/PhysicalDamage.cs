namespace BattleForAzeroth.Game.Widget.Condition.DamageType
{
    public class PhysicalDamage : IDamageType
    {
        public bool NoCache { get; set; } = false;
        ActionType IDamageType.ActionType { get; set; } = ActionType.受到伤害;
    }
}
