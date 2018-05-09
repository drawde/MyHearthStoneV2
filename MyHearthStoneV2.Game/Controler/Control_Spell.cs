using MyHearthStoneV2.Game.Monitor;
using MyHearthStoneV2.Game.CardLibrary.Spell;
using System.Linq;
using MyHearthStoneV2.Game.CardLibrary;
using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.Parameter.CardAbility;
using MyHearthStoneV2.Game.Event.Player;
using MyHearthStoneV2.Game.Action;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Filter;

namespace MyHearthStoneV2.Game.Controler
{
    public partial class Controler_Base
    {
        /// <summary>
        /// 打出一张法术牌
        /// </summary>
        /// <param name="spell"></param>
        /// <param name="target"></param>
        [ControlerMonitor(AttributePriority = 99), PlayerActionMonitor(AttributePriority = 98), UserActionMonitor(AttributePriority = 1)]
        public void CastSpell(BaseSpell spell, int target)
        {
            var currentUserContext = GameContext.GetActivationUserContext();
            //var enenmyUserContext = gameContext.GetNotActivationUserContext();

            currentUserContext.Power -= spell.Cost < 0 ? 0 : spell.Cost;
            currentUserContext.HandCards.Remove(spell);
            currentUserContext.ComboSwitch = true;

            GameContext.CastCardCount++;
            spell.CastIndex = GameContext.CastCardCount;

            GameContext.ParachuteCard = spell;
            spell.CardLocation = CardLocation.降落伞;

            Card triggerCard = null;
            if (target > -1)
            {
                triggerCard = GameContext.DeskCards[target];
            }
            CardAbilityParameter para = new CardAbilityParameter()
            {
                GameContext = GameContext,
                MainCard = spell,
                SecondaryCard = triggerCard,
            };
            GameContext.EventQueue.AddLast(new BeforeICastSpellEvent() { EventCard = spell, Parameter = para }); 

            if (spell.Abilities.Any(c => c is BaseSpellDriver<IGameAction>))
            {
                foreach (ICardAbility abilities in spell.Abilities.Where(c => c is BaseSpellDriver<IGameAction>))
                {                    
                    abilities.Action(para);
                }
            }

            spell.CardLocation = CardLocation.灵车;
            GameContext.HearseCards.AddLast(spell);

            GameContext.EventQueue.AddLast(new MainPlayerPlayCardEvent()
            {
                EventCard = spell,
                Parameter = new CardAbilityParameter()
                {
                    GameContext = GameContext,
                    MainCard = spell,
                    SecondaryCard = triggerCard,
                }
            });

            GameContext.EventQueue.AddLast(new AfterICastSpellEvent() { EventCard = spell, Parameter = para });
        }
    }
}
