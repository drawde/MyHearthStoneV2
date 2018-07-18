using System.Collections.Generic;
using Newtonsoft.Json;
using System.Data;
using Newtonsoft.Json.Converters;

namespace BattleForAzeroth.Game.Util
{
    public class JsonStringResult
    {
        public static string SerializeToJson(object data, string DateTimeFormats = "yyyy-MM-dd HH:mm:ss")
        {
            var timeConverter = new IsoDateTimeConverter { DateTimeFormat = DateTimeFormats };
            return JsonConvert.SerializeObject(data, Formatting.None, timeConverter);
        }
        public static string VerifyFail()
        {
            APIResultBase result = new APIResultBase();
            result.code = OperateResCodeEnum.内部错误.GetHashCode();
            result.msg = OperateResCodeEnum.内部错误.ToString();
            return JsonConvert.SerializeObject(result);
        }
        public static string Error(OperateResCodeEnum resCodeEnum, string ERR = "")
        {
            APIResultBase result = new APIResultBase();
            result.code = resCodeEnum.GetHashCode();
            result.msg = string.IsNullOrWhiteSpace(ERR) ? resCodeEnum.ToString() : ERR;
            return JsonConvert.SerializeObject(result);
        }
        /// <summary>
        /// 查询分页列表成功返回json
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string SuccessPageResult<T>(List<T> data, int totalCount)
        {
            APIPageResult<T> jsonResult = new APIPageResult<T>();
            PageResult<T> pr = new PageResult<T>();
            pr.Items = data;
            pr.TotalItemsCount = totalCount;
            jsonResult.code = OperateResCodeEnum.成功.GetHashCode();
            jsonResult.msg = OperateResCodeEnum.成功.ToString();
            jsonResult.data = pr;
            return SerializeToJson(jsonResult);
        }

        /// <summary>
        /// 查询分页列表成功返回json
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string SuccessPageResult<T>(IPagedItemsResult<T> data)
        {
            APIPageResult<T> jsonResult = new APIPageResult<T>();
            jsonResult.code = OperateResCodeEnum.成功.GetHashCode();
            jsonResult.msg = OperateResCodeEnum.成功.ToString();
            jsonResult.data = data;
            return SerializeToJson(jsonResult);
        }

        public static string SuccessResult(string data = "")
        {
            APITextResult textRes = new APITextResult();
            textRes.code = OperateResCodeEnum.成功.GetHashCode();
            textRes.msg = OperateResCodeEnum.成功.ToString();
            textRes.data = data;
            return SerializeToJson(textRes);
        }
        public static string SuccessResult<T>(T model)
        {
            APISingleModelResult<T> textRes = new APISingleModelResult<T>();
            textRes.code = OperateResCodeEnum.成功.GetHashCode();
            textRes.msg = OperateResCodeEnum.成功.ToString();
            textRes.data = model;
            return SerializeToJson(textRes);
        }
        public static string SerializeDataTableRes<T>(DataTable dt, int count)
        {
            APIPageResult<T> res = new APIPageResult<T>();
            try
            {
                if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
                {
                    res.code = (int)OperateResCodeEnum.成功;
                    PageResult<T> pr = new PageResult<T>();
                    pr.Items = JsonConvert.DeserializeObject<List<T>>(SerializeToJson(dt));
                    pr.TotalItemsCount = count;
                    res.data = pr;
                }
                else
                {
                    res.code = (int)OperateResCodeEnum.查询不到需要的数据;
                    res.msg = "查询不到需要的数据";
                }
            }
            catch
            {
                res.code = (int)OperateResCodeEnum.内部错误;
            }

            return JsonConvert.SerializeObject(res);
        }

    }
}