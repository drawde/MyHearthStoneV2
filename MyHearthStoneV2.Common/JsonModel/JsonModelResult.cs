using MyHearthStoneV2.Common.Enum;
using MyHearthStoneV2.Common.JsonModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.Common.JsonModel
{
    public class JsonModelResult
    {
        public static APITextResult PackageFail(OperateResCodeEnum code)
        {
            return Package(code, code.ToString(), "");
        }
        public static APITextResult PackageSuccess(string data = "")
        {
            return Package(OperateResCodeEnum.成功, OperateResCodeEnum.成功.ToString(), data);
        }
        public static APITextResult Package500()
        {
            return Package(OperateResCodeEnum.内部错误, OperateResCodeEnum.内部错误.ToString(), "");
        }

        public static APITextResult Package(OperateResCodeEnum code, string msg, string data)
        {
            APITextResult textRes = new APITextResult();
            textRes.code = code.GetHashCode();
            textRes.msg = msg;
            textRes.data = data;
            return textRes;
        }

        public static APIPageResult<T> PackageSuccess<T>(List<T> data, int totalCount = -1)
        {
            APIPageResult<T> jsonResult = new APIPageResult<T>();
            PageResult<T> pr = new PageResult<T>();
            pr.Items = data;
            pr.TotalItemsCount = totalCount < 0 ? data.Count : totalCount;
            jsonResult.code = OperateResCodeEnum.成功.GetHashCode();
            jsonResult.msg = OperateResCodeEnum.成功.ToString();
            jsonResult.data = pr;
            return jsonResult;
        }

        public static APISingleModelResult<T> PackageSuccess<T>(T model)
        {
            APISingleModelResult<T> textRes = new APISingleModelResult<T>();
            textRes.code = OperateResCodeEnum.成功.GetHashCode();
            textRes.msg = OperateResCodeEnum.成功.ToString();
            textRes.data = model;
            return textRes;
        }
    }
}
