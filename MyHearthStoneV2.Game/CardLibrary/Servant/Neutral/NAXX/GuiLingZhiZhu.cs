
using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver;
using MyHearthStoneV2.Game.Widget.Number;
using MyHearthStoneV2.Game.Widget.Filter.Context;
using System.Collections.Generic;
using MyHearthStoneV2.Game.Widget.Filter.CardLocationFilter;
using MyHearthStoneV2.Game.Widget.Filter.Servant;
using MyHearthStoneV2.Game.Widget.Filter.PickCard;

namespace MyHearthStoneV2.Game.CardLibrary.Servant.Neutral.NAXX
{
    public class GuiLingZhiZhu : BaseServant
    {
        public override int Damage => 1;
        public override int Life => 2;
        public override int Cost => 2;

        public override int InitialDamage => 1;
        public override int InitialLife => 2;
        public override int InitialCost => 2;
        
        public override int BuffLife => 2;
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
