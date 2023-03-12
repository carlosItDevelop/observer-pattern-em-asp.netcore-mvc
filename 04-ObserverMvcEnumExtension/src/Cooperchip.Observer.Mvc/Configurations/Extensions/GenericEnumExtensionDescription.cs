using System.Reflection;
using System;
using System.Linq;

namespace Cooperchip.Observer.Mvc.Configurations.Extensions
{
    public static class GenericEnumExtensionDescription
    {
        public static string ObterDescricao(this Enum _enum)
        {
            Type genericEnumType = _enum.GetType();
            MemberInfo[] memberInfo = genericEnumType.GetMember(_enum.ToString());
            if ((memberInfo.Length <= 0)) return _enum.ToString();

            var attribs = memberInfo[0].GetCustomAttributes(typeof(System.ComponentModel
                .DescriptionAttribute), false);

            return attribs.Any() ? ((System.ComponentModel.DescriptionAttribute)attribs
                .ElementAt(0)).Description : _enum.ToString();

        }
    }
}
