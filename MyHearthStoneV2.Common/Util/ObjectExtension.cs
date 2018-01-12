using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;
using System.Data;
using System.Web.Script.Serialization;
using System.Reflection;

namespace MyHearthStoneV2.Common.Util
{
    public static class ObjectExtension
    {
        public static int TryParseInt(this object obj)
        {
            return TryParseInt(obj, 0);
        }
        public static int TryParseInt(this object obj, int defaultValue)
        {
            return obj == null ? defaultValue : obj.ToString().TryParseInt(defaultValue);
        }
        public static string ToJsonString(this object obj)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            return js.Serialize(obj);
        }
        public static DateTime TryParseDateTime(this object obj)
        {
            return TryParseDateTime(obj, DateTime.MinValue);
        }
        public static DateTime TryParseDateTime(this object obj, DateTime defaultValue)
        {
            return obj == null ? defaultValue : obj.ToString().TryParseDateTime(defaultValue);
        }

        public static string TryParseString(this object obj)
        {
            return TryParseString(obj, "");
        }
        public static string TryParseString(this object obj, string defaultValue)
        {
            return obj == null ? defaultValue : obj.ToString();
        }

        public static decimal TryParseDecimal(this object obj)
        {
            return TryParseDecimal(obj, 0, 2);
        }
        public static decimal TryParseDecimal(this object obj, int decimals)
        {
            return TryParseDecimal(obj, 0, decimals);
        }
        public static decimal TryParseDecimal(this object obj, decimal defaultValue, int decimals)
        {
            return obj == null ? defaultValue : obj.ToString().TryParseDecimal(defaultValue, decimals);
        }
        public static bool IsNullOrEmpty(this object obj)
        {
            if (obj == null)
                return true;
            return string.IsNullOrEmpty(obj.ToString());
        }

        public static bool TryParseBool(this object obj)
        {
            return TryParseBool(obj, false);
        }
        public static bool TryParseBool(this object obj, bool defaultValue)
        {
            return obj == null ? defaultValue : obj.ToString().TryParseBool(defaultValue);
        }


        /// <summary>
        /// 对象拷贝
        /// </summary>
        /// <param name="obj">被复制对象</param>
        /// <returns>新对象</returns>
        public static object CopyOjbect(this object obj)
        {
            if (obj == null)
            {
                return null;
            }
            Object targetDeepCopyObj;
            Type targetType = obj.GetType();
            //值类型  
            if (targetType.IsValueType == true)
            {
                targetDeepCopyObj = obj;
            }
            //引用类型   
            else
            {
                targetDeepCopyObj = System.Activator.CreateInstance(targetType);   //创建引用对象   
                System.Reflection.MemberInfo[] memberCollection = obj.GetType().GetMembers();

                foreach (System.Reflection.MemberInfo member in memberCollection)
                {
                    //拷贝字段
                    if (member.MemberType == System.Reflection.MemberTypes.Field)
                    {
                        System.Reflection.FieldInfo field = (System.Reflection.FieldInfo)member;
                        Object fieldValue = field.GetValue(obj);
                        if (fieldValue is ICloneable)
                        {
                            field.SetValue(targetDeepCopyObj, (fieldValue as ICloneable).Clone());
                        }
                        else
                        {
                            field.SetValue(targetDeepCopyObj, CopyOjbect(fieldValue));
                        }

                    }//拷贝属性
                    else if (member.MemberType == System.Reflection.MemberTypes.Property)
                    {
                        System.Reflection.PropertyInfo myProperty = (System.Reflection.PropertyInfo)member;

                        MethodInfo info = myProperty.GetSetMethod(false);
                        if (info != null)
                        {
                            try
                            {
                                object propertyValue = myProperty.GetValue(obj, null);
                                if (propertyValue is ICloneable)
                                {
                                    myProperty.SetValue(targetDeepCopyObj, (propertyValue as ICloneable).Clone(), null);
                                }
                                else
                                {
                                    myProperty.SetValue(targetDeepCopyObj, CopyOjbect(propertyValue), null);
                                }
                            }
                            catch (System.Exception ex)
                            {

                            }
                        }
                    }
                }
            }
            return targetDeepCopyObj;
        }
        //public static List<T> GetEntityListByDT<T>(this object srcDT, Hashtable relation)
        //{
        //    return EntityHelper.GetEntityListByDT<T>((DataTable)srcDT, relation);
        //}
        //public static T GetEntityByDT<T>(this object srcDT, Hashtable relation)
        //{
        //    return EntityHelper.GetEntityByDT<T>((DataTable)srcDT, relation);
        //}
        //public static T GetEntityByDT<T>(this object srcDT)
        //{
        //    return EntityHelper.GetEntityByDT<T>((DataTable)srcDT, null);
        //}

    }
}
