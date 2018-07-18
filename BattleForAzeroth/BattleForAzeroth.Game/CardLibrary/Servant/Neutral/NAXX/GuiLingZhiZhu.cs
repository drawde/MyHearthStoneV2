
using BattleForAzeroth.Game.CardLibrary.CardAbility;
using BattleForAzeroth.Game.CardLibrary.CardAbility.BaseAbility;
using BattleForAzeroth.Game.CardLibrary.CardAbility.Driver;
using BattleForAzeroth.Game.Widget.Number;
using BattleForAzeroth.Game.Widget.Filter.Context;
using System.Collections.Generic;
using BattleForAzeroth.Game.Widget.Filter.CardLocationFilter;
using BattleForAzeroth.Game.Widget.Filter.Servant;
using BattleForAzeroth.Game.Widget.Filter.PickCard;

namespace BattleForAzeroth.Game.CardLibrary.Servant.Neutral.NAXX
{
    public class GuiLingZhiZhu : BaseServant
    {
        public override int Damage { get; set; }  = 1;
        public override int Life { get; set; }  = 2;
        public override int Cost { get; set; }  = 2;

        public override int InitialDamage => 1;
        public override int InitialLife => 2;
        public override int InitialCost => 2;
        
        public override int BuffLife { get; set; }  = 2;
        public override string Describe => "";

        public override Rarity Rare => Rarity.精良;

        public override List<ICardAbility> Abilities => new List<ICardAbility>()
        {
            new DeathWhisperDriver
            <
                Summon<PrimaryUserContextFilter,NullFilter,AssignServantFilter<XiaoZhiZhu>,AllPickFilter,Two>
            ,InDeskFilter>()
        };

        public override string Name => "鬼灵爬行者";
        public override Profession Profession => Profession.Neutral;

        public override Race Race => Race.野兽;
        public override string BackgroudImage => "NAXX/GuiLingZhiZhu.jpg";
    }
}
