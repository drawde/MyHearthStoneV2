using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using System.Collections.Generic;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility;
using MyHearthStoneV2.Game.CardLibrary.Equip.Neutral.Classical;
using MyHearthStoneV2.Game.Widget.Filter.CardLocationFilter;

namespace MyHearthStoneV2.Game.CardLibrary.Servant.Neutral.Classical
{
    public class IllidanStormrage : BaseServant
    {
        public override int Damage => 7;
        public override int Life => 5;
        public override int Cost => 8;

        public override int InitialDamage => 7;
        public override int InitialLife => 5;
        public override int InitialCost => 8;

        
        public override int BuffLife => 5;
        public override string Describe { get; set; }  = "亡语：装备一把埃辛诺斯战刃";

        public override Rarity Rare => Rarity.传说;

        public override List<ICardAbility> Abilities => new List<ICardAbility>()
        {
            new DeathWhisperDriver<LoadEquip<WarglaiveOfAzzinoth>,InDeskFilter>()            
        };
        
        public override string Name => "伊利丹·怒风";
        public override string BackgroudImage => "BlackTemple_D_1.png";

        public override Profession Profession => Profession.Neutral;
    }
}
