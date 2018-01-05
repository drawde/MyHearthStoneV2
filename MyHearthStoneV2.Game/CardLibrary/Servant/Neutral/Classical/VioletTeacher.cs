﻿using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Aura;

using MyHearthStoneV2.Game.CardLibrary.Servant;
using System.Collections.Generic;

namespace MyHearthStoneV2.Game.CardLibrary.Servant.Neutral.Classical
{
    public class VioletTeacher : BaseServant
    {
        public override int Damage { get; set; } = 3;
        public override int Life { get; set; } = 5;
        public override int Cost { get; set; } = 4;

        public override int InitialDamage { get; set; } = 3;
        public override int InitialLife { get; set; } = 5;
        public override int InitialCost { get; set; } = 4;

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

        public override List<BaseCardAbility> Abilities { get; set; } = new List<BaseCardAbility>() { new CA_VioletTeacher() };


        public override string Name
        {
            get
            {
                return "紫罗兰教师";
            }
        }

        public override string BackgroudImage { get; set; } = "W7_064_D.png";
    }
}
