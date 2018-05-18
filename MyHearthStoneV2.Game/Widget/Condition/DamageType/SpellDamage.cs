namespace MyHearthStoneV2.Game.Widget.Condition.DamageType
{
    public class SpellDamage :IDamageType
    {
        public bool NoCache { get; set; } = false;
        ActionType IDamageType.ActionType { get; set; } = ActionType.受到法术伤害;
    }
}
