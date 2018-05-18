namespace MyHearthStoneV2.Game.Widget.Condition.Pick
{
    /// <summary>
    /// 挑选方式
    /// </summary>
    public interface IPickType : IGameCache
    {
        PickType PickType { get; set; }
    }
}
