using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Net;
using System.IO;
using System.Globalization;
using System.Web.Caching;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Data;
using Newtonsoft.Json.Converters;
using MyHearthStoneV2.Common.Enum;
using MyHearthStoneV2.Common.JsonModel;

namespace MyHearthStoneV2.Common.Common
{
    public class OperateJsonRes
    {
        public static string SerializeToJson(object data, string DateTimeFormats = "yyyy-MM-dd HH:mm:ss")
        {
            var timeConverter = new IsoDateTimeConverter { DateTimeFormat = DateTimeFormats };
            return JsonConvert.SerializeObject(data, Formatting.None, timeConverter);
        }
        public static string VerifyFail()
        {
            IMResultBase result = new IMResultBase();
            result.code = OperateResCodeEnum.内部错误.GetHashCode();
            result.msg = OperateResCodeEnum.内部错误.ToString();
            return JsonConvert.SerializeObject(result);
        }
        public static string Error(OperateResCodeEnum resCodeEnum, string ERR = "")
        {
            IMResultBase result = new IMResultBase();
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
            IMPageResult<T> jsonResult = new IMPageResult<T>();
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
            IMPageResult<T> jsonResult = new IMPageResult<T>();
            jsonResult.code = OperateResCodeEnum.成功.GetHashCode();
            jsonResult.msg = OperateResCodeEnum.成功.ToString();
            jsonResult.data = data;
            return SerializeToJson(jsonResult);
        }

        public static string SuccessResult(string data = "")
        {
            IMTextResult textRes = new IMTextResult();
            textRes.code = OperateResCodeEnum.成功.GetHashCode();
            textRes.msg = OperateResCodeEnum.成功.ToString();
            textRes.data = data;
            return SerializeToJson(textRes);
        }
        public static string SuccessResult<T>(T model)
        {
            IMSingleModelResult<T> textRes = new IMSingleModelResult<T>();
            textRes.code = OperateResCodeEnum.成功.GetHashCode();
            textRes.msg = OperateResCodeEnum.成功.ToString();
            textRes.data = model;
            return SerializeToJson(textRes);
        }
        public static string SerializeDataTableRes<T>(DataTable dt, int count)
        {
            IMPageResult<T> res = new IMPageResult<T>();
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