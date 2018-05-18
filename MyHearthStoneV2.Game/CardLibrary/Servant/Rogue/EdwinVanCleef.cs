using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BUFF;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BUFF.ChangeBody;
using MyHearthStoneV2.Game.Widget.Filter.ParameterFilter;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.PlayCard;
using MyHearthStoneV2.Game.Widget.Filter.CardLocationFilter;
using MyHearthStoneV2.Game.Widget.Direction;
using MyHearthStoneV2.Game.Widget.Number;
using MyHearthStoneV2.Game.Event;
using MyHearthStoneV2.Game.Event.GameProcess;
using System.Collections.Generic;

namespace MyHearthStoneV2.Game.CardLibrary.Servant.Rogue
{
    public class EdwinVanCleef : BaseServant
    {
        public override int Damage => 2;
        public override int Life => 2;
        public override int Cost => 3;

        public override int InitialDamage => 2;
        public override int InitialLife => 2;
        public override int InitialCost => 3;

        public override int BuffLife => 2;
        public override string Describe => "连击：在本回合中，每有一张其他牌在该牌前被使用，便获得+2/+2。";

        public override Rarity Rare => Rarity.传说;

        public override List<ICardAbility> Abilities => new List<ICardAbility>()
        {
            new PrimaryPlayerPlayCardDriver<
                    ChangeDamageAndLife<TertiaryFilter,Two,Two,Plus,InHandFilter,
                    RestoreDamageAndLife<TertiaryFilter,Two,Two,Minus,InHandFilter,MyTurnEndEvent>>,
                InHandFilter>()
        };

        public override string Name => "艾德温·范克里夫";
        public override Profession Profession => Profession.Rogue;
        public override string BackgroudImage => "Classical/EdwinVanCleef.jpg";
    }
}
