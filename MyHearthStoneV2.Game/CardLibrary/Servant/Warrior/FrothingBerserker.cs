using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Aura;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Observer;
using System.Collections.Generic;

namespace MyHearthStoneV2.Game.CardLibrary.Servant.Warrior
{
    public class FrothingBerserker : BaseServant
    {
        public override int Damage { get; set; } = 2;
        public override int Life { get; set; } = 4;
        public override int Cost { get; set; } = 3;

        public override int InitialDamage { get; set; } = 2;
        public override int InitialLife { get; set; } = 4;
        public override int InitialCost { get; set; } = 3;
        public override string Describe
        {
            get
            {
                return "每当一个随从受到伤害时，便获得+1攻击力。";
            }
        }

        public override Rarity Rare
        {
            get
            {
                return Rarity.精良;
            }
        }

        public override List<BaseCardAbility> Abilities { get; set; } = new List<BaseCardAbility>() { new CA_FrothingBerserker() };


        public override string Name
        {
            get
            {
                return "暴乱狂战士";
            }
        }

        public override string BackgroudImage { get; set; } = "W6_222_D.png";
    }
}
