using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using System.Collections.Generic;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Deathwhisper;

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


        public override int BuffDamage { get; set; } = 7;
        public override int BuffLife { get; set; } = 5;
        public override int BuffCost { get; set; } = 8;
        public override string Describe { get; set; }  = "亡语：装备一把埃辛诺斯战刃";

        public override Rarity Rare => Rarity.传说;

        public override List<BaseCardAbility> Abilities { get; set; } = new List<BaseCardAbility>() { new CA_EquipWarglaiveOfAzzinoth() };
        
        public override string Name { get; set; } = "伊利丹·怒风";
        public override string BackgroudImage { get; set; } = "BlackTemple_D_1.png";

        public override Profession Profession { get; set; } = Profession.Neutral;
    }
}
