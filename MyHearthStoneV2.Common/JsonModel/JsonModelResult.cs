using MyHearthStoneV2.Common.Enum;
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
    }
}
