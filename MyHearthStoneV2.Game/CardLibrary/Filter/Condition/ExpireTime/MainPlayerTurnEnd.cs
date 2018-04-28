namespace MyHearthStoneV2.Game.CardLibrary.Filter.Condition.ExpireTime
{
    public class MainPlayerTurnEnd : IExpireTime
    {
        public bool NoCache { get; set; } = true;
    }
}
