using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver;
using MyHearthStoneV2.Game.CardLibrary.Equip;
using MyHearthStoneV2.Game.CardLibrary.Filter.Condition.DynamicNumber;
using MyHearthStoneV2.Game.CardLibrary.Hero;
using MyHearthStoneV2.Game.CardLibrary.Servant;
using MyHearthStoneV2.Game.CardLibrary.Spell;
using MyHearthStoneV2.Game.Parameter;
using MyHearthStoneV2.Common.Util;
using System;
using System.Linq;
namespace MyHearthStoneV2.Game.CardLibrary.Filter.Extract.Card
{
    public class ExtractCardDamage<F> : IExtract<F>, IDynamicNumber where F : IFilter
    {
        public int Number { get; set; }
        public bool NoCache { get; set; }

        public string Extract(BaseActionParameter actionParameter)
        {
            F filter = Activator.CreateInstance<F>();
            string value = "0";
            var card = actionParameter.GameContext.AllCard.First(filter.Filter(actionParameter));
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

        public int GetNumber(BaseActionParameter actionParameter)
        {
            Number = Extract(actionParameter).TryParseInt();
            return Number;
        }
    }
}
