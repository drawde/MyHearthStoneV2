using MyHearthStoneV2.CardEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.CardLibrary.Hero
{
    public class Druid : BaseHero
    {
        public virtual new string Name { get; } = "德鲁伊";
        public virtual new Profession profession { get; } = Profession.德鲁伊;
    }
}
