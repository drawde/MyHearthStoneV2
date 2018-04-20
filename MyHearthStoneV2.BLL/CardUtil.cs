using MyHearthStoneV2.Game.Card;
using MyHearthStoneV2.Game.Card.Hero;
using MyHearthStoneV2.Game.Card.Spell.Neutral.Classical;
using MyHearthStoneV2.Model;
using MyHearthStoneV2.Redis;
using MyHearthStoneV2.ShortCodeBll;
using System.Collections.Generic;
using MyHearthStoneV2.Game.Card.Equip.Neutral.Classical;
using MyHearthStoneV2.Game.Card.Servant.Warrior;
using MyHearthStoneV2.Game.Card.Servant.Shaman.Classical;
using MyHearthStoneV2.Game.Card.Servant.Neutral.Classical;
using MyHearthStoneV2.Game.Card.Servant.Neutral.NAXX;
using MyHearthStoneV2.Game.Card.Servant.Neutral.BlackrockMountain;
using MyHearthStoneV2.Game.Card.Servant.Neutral.GVG;
using MyHearthStoneV2.Game.Card.Equip.Warrior;
using MyHearthStoneV2.Game.Card.Spell.Warrior;
using MyHearthStoneV2.Game.Card.Servant.Warlock;
using MyHearthStoneV2.Game.Card.Spell.Warlock;
using MyHearthStoneV2.Game.Card.Servant.Rogue;
using MyHearthStoneV2.Game.Card.Equip.Rogue;
using MyHearthStoneV2.Game.Card.Spell.Rogue;
using MyHearthStoneV2.Game.Card.Servant.Neutral.TOC;

namespace MyHearthStoneV2.BLL
{
    public class CardUtil
    {
        /// <summary>
        /// 将卡牌对象添加进缓存
        /// </summary>
        public static void AddToRedis()
        {
            List<Card> lstCard = new List<Card>
            {
                new Hunter(),
                new Warlock(),
                new Al_akir(),//奥拉基
                new JiaoXiaoDeZhongShi(),
                new GuiLingZhiZhu(),
                new XiaoZhiZhu(),
                new LuckyCoin(),
                new DefenderOfArgus(),//阿古斯防御者
                new VioletTeacher(),//紫罗兰教师
                new VioletStudent(),
                new Whirlwind(),//旋风斩
                new FrothingBerserker(),//暴乱狂战士
                new KnifeJuggler(),//飞刀杂耍者
                new Mage(),
                new Paladin(),
                new Priest(),
                new Rogue(),
                new Shaman(),
                new Warlock(),
                new Warrior(),
                new WarglaiveOfAzzinoth(),//埃辛诺斯战刃
                new IllidanStormrage(),//伊利丹
                new GrimPatron(),//恐怖奴隶主
                new Patchwerk(),//帕奇维克
                new WarsongCommander(),//战歌指挥官
                new SylvanasWindrunner(),//希尔瓦娜斯
                new EmperorThaurissan(),//索瑞森大帝
                new DeathBite(),//死亡之咬
                new AcolyteOfPain(),//苦痛恃僧
                new CruelTaskmaster(),//严酷的监工
                new GnomishInventor(),//侏儒发明家
                new LootHoarder(),//战利品贮藏者
                new Armorsmith(),//铸甲师
                new InnerRage(),//怒火中烧
                new BattleRage(),//战斗怒火
                new Execute(),//斩杀
                new ShieldBlock(),//盾牌格挡
                new IronbeakOwl(),//猫头鹰
                new BigGameHunter(),//王牌猎手
                new Slam(),//猛击
                new WildPyromancer(),//狂野炎术师
                new FlameImp(),//烈焰小鬼
                new Doomguard(),//末日守卫
                new FieryWarAxe(),//炽炎战斧
                new DireWolfAlpha(),//恐狼前锋
                new NerubianEgg(),//蛛魔之卵
                new Nerubian(),//蛛魔
                new PowerOverwhelming(),//力量的代价
                new ImpGangBoss(),//小鬼首领
                new Imp(),//小鬼
                new Implosion(),//小鬼爆破
                new PilotedShredder(),//载人收割机
                new Voidwalker(),//虚空行者
                new Loatheb(),//洛欧塞布
                new AntiqueHealbot(),//老式治疗机器人
                new EarthenRingFarseer(),//大地之环先知
                new EdwinVanCleef(),//艾德温·范克里夫
                new SI7Agent(),//军情七处特工
                new WickedKnife(),//邪恶短刀
                new BloodmageThalnos(),//血法师萨尔诺斯
                new Sap(),//闷棍
                new Vanish(),//消失
                new Eviscerate(),//刺骨
                new AzureDrake(),//碧蓝幼龙
                new Preparation(),//伺机待发
                new Sprint(),//疾跑
                new Backstab(),//背刺
                new FanofKnives(),//刀扇
                new Assassin_sBlade(),//刺客之刃
                new DeadlyPoison(),//致命药膏
                new Tinker_sSharpswordOil(),//修补匠的磨刀油
                new BladeFlurry(),//剑刃乱舞
                new LeeroyJenkins(),//火车王里诺艾
                new TombPillager(),//盗墓匪贼
                new KoboldGeomancer(),//狗头人地卜师
                new Doomsayer(),//末日预言者
                new MadBomber(),//疯狂投弹者
                new Whelp(),//雏龙
                new AcidicSwampOoze(),//酸性沼泽软泥怪
            };

            lstCard.ForEach(c => c.CardCode = ShortCodeBusiness.Instance.GetOrCreate(c.GetType().FullName, ShortCodeTypeEnum.卡牌).Code);
            using (var redisClient = RedisManager.GetClient())
            {
                redisClient.Set(RedisKey.GetKey(RedisAppKeyEnum.Alpha, RedisCategoryKeyEnum.CardsInstance), lstCard);
            }
        }

        /// <summary>
        /// 从缓存中加载卡牌对象
        /// </summary>
        /// <returns></returns>
        public static List<Card> GetCardInRedis()
        {
            using (var redisClient = RedisManager.GetClient())
            {
                return redisClient.Get<List<Card>>(RedisKey.GetKey(RedisAppKeyEnum.Alpha, RedisCategoryKeyEnum.CardsInstance));
            }
        }
    }
}
