namespace BattleForAzeroth.Game.Widget.Condition.DamageType
{
    public interface IDamageType: IGameWidgetCache
    {
        ActionType ActionType { get; set; }
    }
}
