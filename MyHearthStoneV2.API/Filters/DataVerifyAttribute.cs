using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyHearthStoneV2.Common;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using MyHearthStoneV2.Common.Util;
using MyHearthStoneV2.Common.JsonModel;
using MyHearthStoneV2.Common.Enum;
using MyHearthStoneV2.Common.JsonModel;
using MyHearthStoneV2.BLL;
using MyHearthStoneV2.Model;

namespace MyHearthStoneV2.API.Filters
{
    public class DataVerifyAttribute : AuthorizeAttribute
    {
        //LoginToken_L_BLL LoginToken_L_BLL = new LoginToken_L_BLL();

        /// <summary>
        /// 设置加载顺序
        /// </summary>
        public DataVerifyAttribute(bool isValidate = true)
        {
            IsValidate = isValidate;
            Order = 2;
        }

        /// <summary>
        /// 是否需要验证签名
        /// </summary>
        public bool IsValidate { get; set; }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {            
            HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "*");
            HttpContext.Current.Response.ContentType = "text/plain";
            ContentResult contentResult = new ContentResult();
            try
            {
                var Request = filterContext.RequestContext.HttpContext.Request;
                string data = "";
                if (Request.HttpMethod.ToLower() == "post")
                {
                    using (Stream s = System.Web.HttpContext.Current.Request.InputStream)
                    {
                        byte[] b = new byte[s.Length];
                        s.Read(b, 0, (int)s.Length);
                        data = Encoding.UTF8.GetString(b);
                    };

                }
                else
                {
                    data = filterContext.RequestContext.HttpContext.Request["data"].TryParseString();
                }
                if (data.IsNullOrEmpty())
                {
                    data = filterContext.Controller.TempData["fullData"].TryParseString();
                }

                
                if (data.IsNullOrEmpty())
                {                    
                    contentResult.Content = JsonStringResult.Error(OperateResCodeEnum.签名验证失败, "");
                    filterContext.Result = contentResult;
                    return;
                }
                APIReciveData im = JsonConvert.DeserializeObject<APIReciveData>(data);

                //if (IsValidate && im.token.IsNullOrEmpty())
                //{
                //    //签名验证
                //    if (string.IsNullOrEmpty(im.appid))
                //    {
                //        contentResult.Content = OperateJsonRes.Error(OperateResCodeEnum.签名验证失败, "");
                //        filterContext.Result = contentResult;
                //        return;
                //    }
                //    if (string.IsNullOrEmpty(im.apiname))
                //    {
                //        contentResult.Content = OperateJsonRes.Error(OperateResCodeEnum.签名验证失败, "");
                //        filterContext.Result = contentResult;
                //        return;
                //    }
                //}
                //else 
                if(IsValidate)
                {
                    if (im.sign.IsNullOrEmpty() || im.nonce_str.IsNullOrEmpty() || im.usercode.IsNullOrEmpty() || im.apitime.IsNullOrEmpty())
                    {
                        contentResult.Content = JsonStringResult.Error(OperateResCodeEnum.签名验证失败);
                        filterContext.Result = contentResult;
                        return;
                    }
                    HS_Users user = UsersBll.Instance.GetUserByAdmin(im.usercode);
                    if (user == null)
                    {
                        contentResult.Content = JsonStringResult.Error(OperateResCodeEnum.签名验证失败);
                        filterContext.Result = contentResult;
                        return;
                    }
                    if (im.sign != SignUtil.CreateSign(im.apitime + user.SecretCode + im.nonce_str))
                    {
                        contentResult.Content = JsonStringResult.Error(OperateResCodeEnum.签名验证失败);
                        filterContext.Result = contentResult;
                        return;
                    }
                    //var lt = LoginTokenBll.Instance.GetUserInfoByToken(im.token);
                    //if (lt == null)
                    //{
                    //    contentResult.Content = OperateJsonRes.Error(OperateResCodeEnum.登录失败, "");
                    //    filterContext.Result = contentResult;
                    //    return;
                    //}
                    //else if (lt.AddTime < DateTime.Now.AddDays(-1))
                    //{
                    //    LoginTokenBll.Instance.Delete(lt.ID);
                    //    contentResult.Content = OperateJsonRes.Error(OperateResCodeEnum.登录失败, "");
                    //    filterContext.Result = contentResult;
                    //    return;
                    //}
                    //else
                    //{
                    //    filterContext.Controller.TempData["LoginToken"] = lt;
                    //}
                }
                filterContext.Controller.TempData["param"] = im.param.TryParseString();
                filterContext.Controller.TempData["version"] = im.version.TryParseString();
                filterContext.Controller.TempData["fullData"] = JsonConvert.SerializeObject(im);

            }
            catch (Exception ex) {
                contentResult.Content = JsonStringResult.Error(OperateResCodeEnum.内部错误, "内部错误");
                filterContext.Result = contentResult;
            }
            return;
        }
    }

}