namespace MyHearthStoneV2.Game.CardLibrary.Filter.Condition.Number
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
