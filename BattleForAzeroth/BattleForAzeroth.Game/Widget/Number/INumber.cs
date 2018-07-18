namespace BattleForAzeroth.Game.Widget.Number
{
    /// <summary>
    /// 数量
    /// </summary>
    public interface INumber: IGameWidgetCache
    {
        int Number { get; set; }
        int GetNumber(Parameter.ActionParameter actionParameter);
    }
}
