using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BUFF.ChangeBody;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Filter;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.PlayCard;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Filter;
using MyHearthStoneV2.Game.CardLibrary.Filter.Condition.Direction;
using MyHearthStoneV2.Game.CardLibrary.Filter.Condition.Number;
using MyHearthStoneV2.Game.Event.GameProcess;
using System.Collections.Generic;

namespace MyHearthStoneV2.Game.CardLibrary.Servant.Rogue
{
    public class EdwinVanCleef : BaseServant
    {
        public override int Damage { get; set; } = 2;
        public override int Life { get; set; } = 2;
        public override int Cost { get; set; } = 3;

        public override int InitialDamage { get; set; } = 2;
        public override int InitialLife { get; set; } = 2;
        public override int InitialCost { get; set; } = 3;

        public override int BuffLife { get; set; } = 2;
        public override string Describe { get; set; } = "连击：在本回合中，每有一张其他牌在该牌前被使用，便获得+2/+2。";

        public override Rarity Rare { get; set; } = Rarity.传说;

        public override List<ICardAbility> Abilities { get; set; } = new List<ICardAbility>()
        {
            new MainPlayerPlayCardDriver<
                    ChangeDamageAndLife<TertiaryFilter,Two,ONE,Plus,InHandFilter,
                    RestoreDamageAndLife<TertiaryFilter,Two,ONE,Minus,InHandFilter,MyTurnEndEvent>>,
                InHandFilter>()
        };

        public override string Name { get; set; } = "艾德温·范克里夫";
        public override Profession Profession { get; set; } = Profession.Rogue;
        public override string BackgroudImage { get; set; } = "Classical/EdwinVanCleef.jpg";
    }
}
