using MyHearthStoneV2.Game.CardLibrary.Servant;

namespace MyHearthStoneV2.Game.CardLibrary.Servant.Neutral.NAXX
{
    public class XiaoZhiZhu : BaseServant
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
                return "鬼灵蜘蛛";
            }
        }        
    }
}
