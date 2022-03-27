using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace MVC_Start.Extension
{
    public static class EnumExtension
    {
        public static string GetDisplayName(Enum en)
        {

            Type type = en.GetType();
            MemberInfo[] memberInfo = type.GetMember(en.ToString());
            if (memberInfo != null && memberInfo.Length > 0)
            { 
                object[] attrs = memberInfo[0].GetCustomAttributes(typeof(DisplayAttribute), true);
                if (attrs.Length > 0 && attrs != null)
                {
                    return ((DisplayAttribute)attrs[0]).Name;
                }
               

            }
            return en.ToString();   
        }
    }
}
