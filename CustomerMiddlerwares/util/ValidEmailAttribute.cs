using System.ComponentModel.DataAnnotations;

namespace MVC_Start.CustomerMiddlerwares.util
{
    /// <summary>
    /// 自定义特性
    /// </summary>
    public class ValidEmailAttribute:ValidationAttribute
    {
        private readonly string allowDomain;

        public ValidEmailAttribute(string allowDomain)
        {
            this.allowDomain = allowDomain;
        }
        public override bool IsValid(object value)
        {
            string[] strings = value.ToString().Split('@');
            return strings[1].ToUpper() == allowDomain.ToUpper();
        }
    }
}
