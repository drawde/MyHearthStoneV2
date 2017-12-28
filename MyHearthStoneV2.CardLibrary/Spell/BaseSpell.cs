
using MyHearthStoneV2.CardLibrary.Base;
using MyHearthStoneV2.CardLibrary.CardAbility;
using MyHearthStoneV2.CardLibrary.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.CardLibrary.Spell
{
    /// <summary>
    /// 法术类卡牌
    /// </summary>
    public abstract class BaseSpell : Card
    {
        public override CardType CardType { get; set; } = CardType.法术;
    }
}
