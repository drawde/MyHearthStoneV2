namespace MyHearthStoneV2.Game.Widget.Number
{
    /// <summary>
    /// 数量
    /// </summary>
    public interface INumber: IGameCache
    {
        int Number { get; set; }
        int GetNumber(Parameter.BaseActionParameter actionParameter);
    }
}
