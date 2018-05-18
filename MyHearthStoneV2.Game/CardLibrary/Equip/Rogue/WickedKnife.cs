﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.Game.CardLibrary.Equip.Rogue
{
    public class WickedKnife : BaseEquip
    {
        public override string Name => "邪恶短刀";
        public override string BackgroudImage => "W14_a200_D.png";

        public override int Damage => 1;
        
        public override int InitialDamege => 1;
        public override int Durable => 2;
        public override int Cost => 2;
        public override int InitialCost => 2;
        public override string Describe => "";
        public override bool IsDerivative => true;

        public override Profession Profession => Profession.Rogue;
    }
}
