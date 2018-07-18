using BattleForAzeroth.Game.CardLibrary.CardAbility;
using System.Collections.Generic;
using BattleForAzeroth.Game.CardLibrary.CardAbility.Driver;
using BattleForAzeroth.Game.CardLibrary.CardAbility.BaseAbility;
using BattleForAzeroth.Game.CardLibrary.Equip.Neutral.Classical;
using BattleForAzeroth.Game.Widget.Filter.CardLocationFilter;

namespace BattleForAzeroth.Game.CardLibrary.Servant.Neutral.Classical
{
    public class IllidanStormrage : BaseServant
    {
        public override int Damage { get; set; }  = 7;
        public override int Life { get; set; }  = 5;
        public override int Cost { get; set; }  = 8;

        public override int InitialDamage => 7;
        public override int InitialLife => 5;
        public override int InitialCost => 8;

        
        public override int BuffLife { get; set; }  = 5;
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
