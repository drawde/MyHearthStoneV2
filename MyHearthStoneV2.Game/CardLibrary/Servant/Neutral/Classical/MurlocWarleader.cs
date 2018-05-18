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

namespace MyHearthStoneV2.Game.CardLibrary.Servant.Neutral.Classical
{
    public class MurlocWarleader : BaseServant
    {
        public override int Damage => 3;
        public override int Life => 3;
        public override int Cost => 3;
        public override int InitialDamage => 3;
        public override int InitialLife => 3;
        public override int InitialCost => 3;
        public override int BuffLife => 3;
        public override string Describe => "所有其他鱼人获得+2/+1。";
        public override Rarity Rare => Rarity.史诗;
        public override string Name => "鱼人领军";
        public override string BackgroudImage => "W18_a149_D_1.png";
        public override Profession Profession => Profession.Neutral;
        public override Race Race => Race.鱼人;
        public override List<ICardAbility> Abilities { get; set; }
        public MurlocWarleader()
        {
            Abilities = new List<ICardAbility>()
            {
                new AuraDriver<
                    StandardAura<
                        ChangeDamageAndLife<RaceFilter<Murloc>,Two,ONE,Plus,InDeskFilter,
                            RestoreDamageAndLife<RaceFilter<Murloc>,Two,ONE,Minus,InDeskFilter,NullEvent>
                        >>,
                    InDeskFilter,
                    ServantInDeskEvent>(this)
            };
        }
    }
}
