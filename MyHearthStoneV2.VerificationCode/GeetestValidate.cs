using GeetestSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MyHearthStoneV2.VerificationCode
{
    public class GeetestValidate
    {
        /// <summary>
        /// 验证验证码是否正确
        /// </summary>
        /// <returns></returns>
        public static bool Validate()
        {
            int result = 0;
            try
            {
                GeetestLib geetest = new GeetestLib(GeetestConfig.publicKey, GeetestConfig.privateKey);
                Byte gt_server_status_code = (Byte)HttpContext.Current.Session[GeetestLib.gtServerStatusSessionKey];
                string userID = (string)HttpContext.Current.Session["userID"];

                string challenge = HttpContext.Current.Request[GeetestLib.fnGeetestChallenge];
                string validate = HttpContext.Current.Request[GeetestLib.fnGeetestValidate];
                string seccode = HttpContext.Current.Request[GeetestLib.fnGeetestSeccode];
                if (gt_server_status_code == 1)
                {
                    result = geetest.enhencedValidateRequest(challenge, validate, seccode, userID);
                }
                else
                {
                    result = geetest.failbackValidateRequest(challenge, validate, seccode);
                }
            }
            catch (Exception)
            {
                
            }
            return result == 1;
        }
    }
}
