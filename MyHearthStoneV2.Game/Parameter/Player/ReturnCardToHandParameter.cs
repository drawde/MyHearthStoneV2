using MyHearthStoneV2.Game.Context;

namespace MyHearthStoneV2.Game.Parameter.Player
{
    internal class ReturnCardToHandParameter : BaseActionParameter
    {
        internal int ReturnCount { get; set; }
        internal UserContext UserContext { get; set; }
    }
}
