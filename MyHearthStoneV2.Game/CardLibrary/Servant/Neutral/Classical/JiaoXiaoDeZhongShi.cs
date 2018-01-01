﻿
using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.CardAction;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.WarCry.AlterBody;
using MyHearthStoneV2.Game.CardLibrary.Servant;
using System.Collections.Generic;

namespace MyHearthStoneV2.Game.CardLibrary.Servant.Neutral.Classical
{
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

        public override List<BaseCardAbility> Abilities { get; set; } = new List<BaseCardAbility>() { new CA_JiaoXiaoDeZhongShi(), new CA_ServantAttack() };

        public override string BackgroudImage { get; set; } = "W2_326_D.png";
        
        public override string Name
        {
            get
            {
                return "叫嚣的中士";
            }
        }
        
    }
}
