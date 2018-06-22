using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver;
using MyHearthStoneV2.Game.Widget.Filter.Context;
using System.Collections.Generic;
using MyHearthStoneV2.Game.Widget.Filter.CardLocationFilter;
using MyHearthStoneV2.Game.Widget.Filter.Servant;
using MyHearthStoneV2.Game.Widget.Filter.PickCard;
using MyHearthStoneV2.Game.Widget.Number;

namespace MyHearthStoneV2.Game.CardLibrary.Servant.Neutral.Classical
{
    public class VioletTeacher : BaseServant
    {
        public override int Damage { get; set; }  = 3;
        public override int Life { get; set; }  = 5;
        public override int Cost { get; set; }  = 4;

        public override int InitialDamage => 3;
        public override int InitialLife => 5;
        public override int InitialCost => 4;
        
        public override int BuffLife { get; set; }  = 5;

        public override string Describe => "每当你施放一个法术时，召唤一个1/1的紫罗兰学徒。";

        public override Rarity Rare => Rarity.精良;

        public override List<ICardAbility> Abilities => new List<ICardAbility>()
        {
            new BeforeICastSpellDriver<Summon<PrimaryUserContextFilter,NullFilter,AssignServantFilter<VioletStudent>,AllPickFilter,ONE>,InDeskFilter>(),            
        };


        public override string Name => "紫罗兰教师";

        public override string BackgroudImage => "W7_064_D.png";
        public override Profession Profession => Profession.Neutral;
    }
}
