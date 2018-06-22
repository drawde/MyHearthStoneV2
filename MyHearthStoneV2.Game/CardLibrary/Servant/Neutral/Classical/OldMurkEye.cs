using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Aura;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BUFF.ChangeBody;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver;
using MyHearthStoneV2.Game.Widget.Filter.ParameterFilter.Servant;
using MyHearthStoneV2.Game.Widget.Filter.CardLocationFilter;
using MyHearthStoneV2.Game.Widget.Direction;
using MyHearthStoneV2.Game.Widget.Number;
using MyHearthStoneV2.Game.Event;
using MyHearthStoneV2.Game.Event.Servant;
using System.Collections.Generic;
using MyHearthStoneV2.Game.Widget.Condition.RaceCondition;
using MyHearthStoneV2.Game.Widget.Extract.Card;
using MyHearthStoneV2.Game.Widget.Filter.ParameterFilter;

namespace MyHearthStoneV2.Game.CardLibrary.Servant.Neutral.Classical
{
    public class OldMurkEye : BaseServant
    {
        public override int Damage { get; set; }  = 2;
        public override int Life { get; set; }  = 4;
        public override int Cost { get; set; }  = 4;
        public override int InitialDamage => 2;
        public override int InitialLife => 4;
        public override int InitialCost => 4;
        public override int BuffLife { get; set; }  = 4;
        public override string Describe => "冲锋，在战场上每有一个其他鱼人便获得+1攻击力。";
        public override Rarity Rare => Rarity.传说;
        public override string Name => "老瞎眼";
        public override string BackgroudImage => "Bestiary_final2_D.png";
        public override Profession Profession => Profession.Neutral;
        public override Race Race => Race.鱼人;
        public override bool HasCharge => true;
        public OldMurkEye()
        {
            Abilities = new List<ICardAbility>()
            {
                new AuraDriver<
                    StandardAura<
                        ChangeDamage<TertiaryFilter,ExtractCardDamage<RaceFilter<Murloc>,InDeskFilter>,Plus,InDeskFilter,
                            RestoreDamage<TertiaryFilter,ExtractCardDamage<RaceFilter<Murloc>,InDeskFilter>,Minus,InDeskFilter,NullEvent>
                        >>,
                    InDeskFilter,
                    ServantInDeskEvent>(this)
            };
        }
    }
}
