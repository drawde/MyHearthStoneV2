using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using System.Collections.Generic;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility;
using MyHearthStoneV2.Game.CardLibrary.Equip.Neutral.Classical;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Filter;

namespace MyHearthStoneV2.Game.CardLibrary.Servant.Neutral.Classical
{
    public class IllidanStormrage : BaseServant
    {
        public override int Damage { get; set; } = 7;
        public override int Life { get; set; } = 5;
        public override int Cost { get; set; } = 8;

        public override int InitialDamage { get; set; } = 7;
        public override int InitialLife { get; set; } = 5;
        public override int InitialCost { get; set; } = 8;

        
        public override int BuffLife { get; set; } = 5;
        public override string Describe { get; set; }  = "亡语：装备一把埃辛诺斯战刃";

        public override Rarity Rare => Rarity.传说;

        public override List<ICardAbility> Abilities { get; set; } = new List<ICardAbility>()
        {
            new DeathWhisperDriver<LoadEquip<WarglaiveOfAzzinoth>,InDeskFilter>()            
        };
        
        public override string Name { get; set; } = "伊利丹·怒风";
        public override string BackgroudImage { get; set; } = "BlackTemple_D_1.png";

        public override Profession Profession { get; set; } = Profession.Neutral;
    }
}
