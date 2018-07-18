namespace BattleForAzeroth.Game.Widget.Condition.Pick
{
    /// <summary>
    /// 挑选方式
    /// </summary>
    public interface IPickType : IGameWidgetCache
    {
        PickType PickType { get; set; }
    }
}
