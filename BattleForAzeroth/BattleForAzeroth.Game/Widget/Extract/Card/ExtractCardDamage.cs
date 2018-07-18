using BattleForAzeroth.Game.Parameter;
using BattleForAzeroth.Game.Util;
using System;
using System.Linq;
using BattleForAzeroth.Game.CardLibrary.Servant;
using BattleForAzeroth.Game.CardLibrary.Spell;
using BattleForAzeroth.Game.CardLibrary.Hero;
using BattleForAzeroth.Game.CardLibrary.Equip;
using BattleForAzeroth.Game.Widget.Number.DynamicNumber;
using BattleForAzeroth.Game.Widget.Filter.ParameterFilter;
using BattleForAzeroth.Game.Widget.Filter.CardLocationFilter;

namespace BattleForAzeroth.Game.Widget.Extract.Card
{
    public class ExtractCardDamage<F,Location> : IExtract<F>, IDynamicNumber where F : IParameterFilter where Location : ICardLocationFilter
    {
        public int Number { get; set; }
        public bool NoCache { get; set; }

        public string Extract(ActionParameter actionParameter)
        {
            F filter = Activator.CreateInstance<F>();
            Location loc = Activator.CreateInstance<Location>();
            string value = "0";
            var card = actionParameter.GameContext.AllCard.Where(filter.Filter(actionParameter)).Where(c => loc.Filter(c)).First();
            if (card.CardType == CardType.随从)
            {
                value = (card as BaseServant).Damage.ToString();
            }
            else if (card.CardType == CardType.法术)
            {
                value = (card as BaseSpell).Damage.ToString();
            }
            else if (card.CardType == CardType.英雄)
            {
                BaseHero hero = card as BaseHero;
                value = hero.Damage.ToString();
                if (hero.Equip != null)
                    value = (hero.Equip.Damage + hero.Damage).ToString();
            }
            else if (card.CardType == CardType.装备)
            {
                value = (card as BaseEquip).Damage.ToString();
            }
            return value;
        }

        public int GetNumber(ActionParameter actionParameter)
        {
            Number = Extract(actionParameter).TryParseInt();
            return Number;
        }
    }
}
