namespace BattleForAzeroth.Game.Widget.Condition.ExpireTime
{
    public class PrimaryPlayerTurnEnd : IExpireTime
    {
        public bool NoCache { get; set; } = true;
    }
}
