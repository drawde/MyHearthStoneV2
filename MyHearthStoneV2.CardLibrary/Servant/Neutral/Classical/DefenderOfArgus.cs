using MyHearthStoneV2.CardEnum;
using MyHearthStoneV2.CardLibrary.CardAbility;
using MyHearthStoneV2.CardLibrary.CardAbility.WarCry.AlterBody;
using System.Collections.Generic;

namespace MyHearthStoneV2.CardLibrary.Servant.Neutral.Classical
{
    public class DefenderOfArgus : BaseServant
    {
        public override int Damage { get; set; } = 2;
        public override int Life { get; set; } = 3;
        public override int Cost { get; set; } = 4;

        public override string Describe
        {
            get
            {
                return "";
            }
        }

        public override Rarity Rare
        {
            get
            {
                return Rarity.精良;
            }
        }

        public override List<BaseSpecialEffect> LstBuff { get; set; } = new List<BaseSpecialEffect>() { new SE_DefenderOfArgus() };


        public override string Name
        {
            get
            {
                return "阿古斯防御者";
            }
        }
    }
}
