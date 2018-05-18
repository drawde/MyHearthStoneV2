namespace MyHearthStoneV2.Game.Widget.Condition.DamageType
{
    public interface IDamageType: IGameCache
    {
        ActionType ActionType { get; set; }
    }
}
