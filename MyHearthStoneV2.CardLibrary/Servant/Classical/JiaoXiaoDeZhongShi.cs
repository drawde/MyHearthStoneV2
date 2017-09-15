using MyHearthStoneV2.CardEnum;
using MyHearthStoneV2.CardSpecialEffect.WarCry.AlterBody;
using MyHearthStoneV2.CardMonitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHearthStoneV2.CardSpecialEffect;

namespace MyHearthStoneV2.CardLibrary.Servant.Classical
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

        public override List<ISpecialEffect> LstBuff { get; set; } = new List<ISpecialEffect>() { new SE_JiaoXiaoDeZhongShi() };


        public override string Name
        {
            get
            {
                return "叫嚣的中士";
            }
        }
        
    }
}
