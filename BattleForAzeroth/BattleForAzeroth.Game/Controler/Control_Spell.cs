
using BattleForAzeroth.Game.CardLibrary.Spell;
using System.Linq;
using BattleForAzeroth.Game.CardLibrary;
using BattleForAzeroth.Game.CardLibrary.CardAbility;
using BattleForAzeroth.Game.Context;

using BattleForAzeroth.Game.Event.Player;
using BattleForAzeroth.Game.Action;
using BattleForAzeroth.Game.CardLibrary.CardAbility.Driver;
using BattleForAzeroth.Game.Widget.Filter.CardLocationFilter;
using BattleForAzeroth.Game.Parameter;

namespace BattleForAzeroth.Game.Controler
{
    public partial class Controler_Base
    {
        /// <summary>
        /// 打出一张法术牌
        /// </summary>
        /// <param name="spell"></param>
        /// <param name="target"></param>
        public void CastSpell(BaseSpell spell, int target)
        {
            var currentUserContext = GameContext.GetActivationUserContext();
            //var enenmyUserContext = gameContext.GetNotActivationUserContext();

            currentUserContext.Power -= spell.Cost < 0 ? 0 : spell.Cost;
            //currentUserContext.HandCards.Remove(spell);
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
            var para = new ActionParameter()
            {
                GameContext = GameContext,
                PrimaryCard = spell,
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

            GameContext.EventQueue.AddLast(new PrimaryPlayerPlayCardEvent()
            {
                EventCard = spell,
                Parameter = new ActionParameter()
                {
                    GameContext = GameContext,
                    PrimaryCard = spell,
                    SecondaryCard = triggerCard,
                }
            });

            GameContext.EventQueue.AddLast(new AfterICastSpellEvent() { EventCard = spell, Parameter = para });
            Settlement();
        }
    }
}
