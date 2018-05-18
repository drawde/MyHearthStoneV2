using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.CardLibrary;
namespace MyHearthStoneV2.Game.Parameter.CardAbility
{
    /// <summary>
    /// 卡牌行为参数（用于封装触发卡牌技能、卡牌动作的参数）
    /// </summary>
    public class CardAbilityParameter : BaseActionParameter
    {
        /// <summary>
        /// 主体卡牌将要进入的牌桌位置
        /// </summary>
        public int PrimaryCardLocation { get; set; }

    }
}
