using MyHearthStoneV2.Game.CardLibrary;
using MyHearthStoneV2.Game.CardLibrary.Hero;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MyHearthStoneV2.Game.Context
{
    /// <summary>
    /// 棋盘对象（扩展了泛型集合，便于更方便的获取场上的牌）
    /// </summary>
    public class DeskBoard : List<BaseBiology>
    {
        public IEnumerable<BaseBiology> FirstPlayerDeskCards()
        {
            return GetRange(0, 8);
        }

        public IEnumerable<BaseBiology> SecondPlayerDeskCards()
        {
            return GetRange(8, 8);
        }

        public IEnumerable<BaseBiology> GetDeskCardsByIsFirst(bool isFirst = true)
        {
            return GetRange(isFirst ? 0 : 8, 8);
        }

        public IEnumerable<BaseBiology> GetDeskServantsByIsFirst(bool isFirst = true)
        {
            return GetRange(isFirst ? 0 : 8, 8).Where(c => c != null && c.CardType == CardType.随从).ToList();
        }

        public IEnumerable<BaseBiology> GetDeskBiologysByIsFirst(bool isFirst = true)
        {
            return GetRange(isFirst ? 0 : 8, 8).Where(c => c != null).ToList();
        }

        public IEnumerable<BaseBiology> GetServants()
        {
            return this.Where(c => c != null && c.CardType == CardType.随从).ToList();
        }
        public IEnumerable<BaseBiology> GetAllBiology()
        {
            return this.Where(c => c != null);
        }

        public Func<BaseBiology, bool> GetServant(string cardInGameCode)
        {
            return new Func<BaseBiology, bool>(c => c != null && c.CardInGameCode == cardInGameCode);
        }

        public Func<BaseBiology, bool> GetServantsFilter()
        {
            return new Func<BaseBiology, bool>(c => c != null && c.CardType == CardType.随从);
        }

        public BaseHero GetFirstPlayerHero()
        {
            return this.First() as BaseHero;
        }
        public BaseHero GetSecondPlayerHero()
        {
            return this[8] as BaseHero;
        }

        /// <summary>
        /// 根据敌方的牌获取自己站场的对象
        /// </summary>
        /// <param name="context"></param>
        /// <param name="enemyCard"></param>
        /// <returns></returns>
        public IEnumerable<BaseBiology> GetDeskCardsByEnemyCard(BaseBiology biology)
        {
            return GetRange(biology.DeskIndex < 8 ? 8 : 0, 8);
        }

        /// <summary>
        /// 根据自己的牌获取自己站场的对象
        /// </summary>
        /// <param name="context"></param>
        /// <param name="myCard"></param>
        /// <returns></returns>
        public IEnumerable<BaseBiology> GetDeskCardsByMyCard(BaseBiology biology)
        {
            return GetRange(biology.DeskIndex < 8 ? 0 : 8, 8);
        }

        /// <summary>
        /// 根据自己的牌获取自己的英雄
        /// </summary>
        /// <param name="context"></param>
        /// <param name="myCard"></param>
        /// <returns></returns>
        public BaseHero GetHeroByMyCard(BaseBiology biology)
        {
            return this[biology.DeskIndex < 8 ? 0 : 8] as BaseHero;
        }

        /// <summary>
        /// 根据自己的牌获取敌方的英雄
        /// </summary>
        /// <param name="context"></param>
        /// <param name="myCard"></param>
        /// <returns></returns>
        public BaseHero GetEnemyHeroByMyCard(BaseBiology biology)
        {
            return this[biology.DeskIndex < 8 ? 8 : 0] as BaseHero;
        }

        public BaseHero GetHeroByIsFirst(bool isFirst = true)
        {
            return this[isFirst ? 0 : 8] as BaseHero;
        }
    }
}
