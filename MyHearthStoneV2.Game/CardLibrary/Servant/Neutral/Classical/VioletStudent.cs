
using MyHearthStoneV2.Game.CardLibrary.Servant;

namespace MyHearthStoneV2.Game.CardLibrary.Servant.Neutral.Classical
{
    public class VioletStudent : BaseServant
    {
        public override int Damage { get; set; } = 1;
        public override int Life { get; set; } = 1;
        public override int Cost { get; set; } = 1;

        public override bool IsDerivative { get; } = true;
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
        public override string Name
        {
            get
            {
                return "紫罗兰学徒";
            }
        }

        public override string BackgroudImage { get; set; } = "WOW_EQU_050_D.png"; 
    }
}
