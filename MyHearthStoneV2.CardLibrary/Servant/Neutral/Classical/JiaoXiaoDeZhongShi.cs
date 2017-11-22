using MyHearthStoneV2.CardEnum;
using MyHearthStoneV2.CardSpecialEffect.WarCry.AlterBody;
using System.Collections.Generic;
using MyHearthStoneV2.CardSpecialEffect;
using MyHearthStoneV2.CardLibrary.Monitor;

namespace MyHearthStoneV2.CardLibrary.Servant.Neutral.Classical
{
    [PropertyChangedNotification]
    public class JiaoXiaoDeZhongShi : BaseServant
    {
        public override int Damage { get; set; } = 2;
        public override int Life { get; set; } = 1;
        public override int Cost { get; set; } = 1;

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
                return Rarity.普通;
            }
        }

        public override List<BaseSpecialEffect> LstBuff { get; set; } = new List<BaseSpecialEffect>() { new SE_JiaoXiaoDeZhongShi() };


        public override string Name
        {
            get
            {
                return "叫嚣的中士";
            }
        }
        
    }
}
