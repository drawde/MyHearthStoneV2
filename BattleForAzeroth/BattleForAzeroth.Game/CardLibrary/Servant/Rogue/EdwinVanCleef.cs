using BattleForAzeroth.Game.CardLibrary.CardAbility;
using BattleForAzeroth.Game.CardLibrary.CardAbility.BUFF;
using BattleForAzeroth.Game.CardLibrary.CardAbility.BUFF.ChangeBody;
using BattleForAzeroth.Game.Widget.Filter.ParameterFilter;
using BattleForAzeroth.Game.CardLibrary.CardAbility.Driver.PlayCard;
using BattleForAzeroth.Game.Widget.Filter.CardLocationFilter;
using BattleForAzeroth.Game.Widget.Direction;
using BattleForAzeroth.Game.Widget.Number;
using BattleForAzeroth.Game.Event;
using BattleForAzeroth.Game.Event.GameProcess;
using System.Collections.Generic;

namespace BattleForAzeroth.Game.CardLibrary.Servant.Rogue
{
    public class EdwinVanCleef : BaseServant
    {
        public override int Damage { get; set; } = 2;
        public override int Life { get; set; } = 2;
        public override int Cost { get; set; } = 3;

        public override int InitialDamage => 2;
        public override int InitialLife => 2;
        public override int InitialCost => 3;

        public override int BuffLife { get; set; } = 2;
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
