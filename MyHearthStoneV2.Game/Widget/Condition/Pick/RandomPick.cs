namespace MyHearthStoneV2.Game.Widget.Condition.Pick
{
    public class RandomPick : IPickType
    {
        public bool NoCache { get; set; } = false;
        PickType IPickType.PickType { get; set; } = PickType.随机;
    }
}
