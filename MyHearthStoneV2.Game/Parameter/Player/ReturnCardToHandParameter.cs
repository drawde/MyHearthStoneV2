using MyHearthStoneV2.Game.Context;

namespace MyHearthStoneV2.Game.Parameter.Player
{
    public class ReturnCardToHandParameter : BaseActionParameter
    {
        public int ReturnCount { get; set; }
        public UserContext UserContext { get; set; }
    }
}
