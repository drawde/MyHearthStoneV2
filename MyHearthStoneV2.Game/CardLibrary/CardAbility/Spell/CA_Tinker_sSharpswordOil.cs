using MyHearthStoneV2.Common.Util;
using MyHearthStoneV2.Game.CardLibrary.Hero;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.Parameter;
using System.Linq;
namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Spell
{
    public class CA_Tinker_sSharpswordOil : BaseCardAbility
    {
        public override IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            UserContext user = actionParameter.GameContext.GetUserContextByMyCard(actionParameter.MainCard);
            BaseHero hero = actionParameter.GameContext.DeskCards.GetHeroByIsFirst(user.IsFirst);
            if (hero.Equip != null)
            {                
                hero.Equip.Damage += 3;
            }
            if (user.ComboSwitch)
            {
                var servants = actionParameter.GameContext.DeskCards.GetDeskServantsByIsFirst(user.IsFirst);
                int idx = RandomUtil.CreateRandomInt(0, servants.Count() - 1);
                var servant = servants[idx];
                servant.Damage += 3;
            }
            return null;
        }
    }
}
