﻿
using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.CardAction;
using MyHearthStoneV2.Game.CardLibrary.Servant;
using System.Collections.Generic;

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
        public override List<BaseCardAbility> Abilities { get; set; } = new List<BaseCardAbility>() { new CA_ServantAttack() };
        public override string BackgroudImage { get; set; } = "WOW_EQU_050_D.png"; 
    }
}
