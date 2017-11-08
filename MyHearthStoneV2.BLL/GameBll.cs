

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyHearthStoneV2.DAL;
using MyHearthStoneV2.DAL.Impl;
using MyHearthStoneV2.Model;
using MyHearthStoneV2.Common;
using MyHearthStoneV2.Common.Util;


namespace MyHearthStoneV2.BLL
{
    public class GameBll : BaseBLL<HS_Game>
    {
        private IRepository<HS_Game> _repository = new Repository<HS_Game>();
        private GameBll()
        {
        }
        public static GameBll Instance = new GameBll();

        public HS_Game CreateGame(string tableCode, string firstUserCode, string secondUserCode,string firstUserCardGroupCode,string secondUserCardGroupCode)
        {
            HS_Game game = new HS_Game();
            using (MyHearthStoneV2Context context = new MyHearthStoneV2Context())
            {                
                game.GameCode = ShortCodeBll.Instance.CreateCode("", ShortCodeTypeEnum.GameCode);
                game.AddTime = DateTime.Now;
                game.CurrentRoundCode = ShortCodeBll.Instance.CreateCode("", ShortCodeTypeEnum.GameRoundCode);
                game.FirstUserCode = firstUserCode;
                game.IsFirstUserWin = false;
                game.NextRoundCode = ShortCodeBll.Instance.CreateCode("", ShortCodeTypeEnum.GameRoundCode);
                game.SecondUserCode = secondUserCode;
                game.FirstUserCardGroupCode = firstUserCardGroupCode;
                game.SecondUserCardGroupCode = secondUserCardGroupCode;
                game.TableCode = tableCode;
                context.hs_game.Add(game);                

                HS_GameRecord record = new HS_GameRecord();
                record.AddTime = game.AddTime;
                record.Chessboard = "";
                record.FirstUserCode = firstUserCode;
                record.GameCode = game.GameCode;
                record.IsFirstUserRound = true;
                record.RoundIndex = 0;
                record.SecondUserCode = secondUserCode;
                record.RoundCode = game.CurrentRoundCode;
                context.hs_gamerecord.Add(record);
                context.SaveChanges();
            }
            return game;
        }

        public HS_Game GetGame(string gameCode)
        {
            return _repository.GetList(c => c.GameCode == gameCode).Result.Items.ToList().First();
        }

        public HS_Game GetGameByTableCode(string tableCode)
        {
            using (MyHearthStoneV2Context context = new MyHearthStoneV2Context())
            {
                return context.hs_game.AsNoTracking().First(c => c.TableCode == tableCode);
            }                
        }
    }
}
