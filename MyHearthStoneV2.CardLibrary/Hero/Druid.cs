
using MyHearthStoneV2.CardLibrary.CardAbility;
using MyHearthStoneV2.CardLibrary.CardAbility.HeroPower;
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
        public virtual new Profession Profession { get; } = Profession.Druid;
        public override List<BaseCardAbility> Abilities { get; set; } = new List<BaseCardAbility>() { new DruidAbility() };
    }
}
