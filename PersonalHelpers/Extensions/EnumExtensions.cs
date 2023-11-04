using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PersonalHelpers.Enums;

public static class EnumExtensions
{

    public static string GetDescriptionElseName(this Enum? value)
    {
        var desc = value.GetDescription();
        if (desc is not null)
            return desc;

        if (value is null)
            return "";

        return value.ToString();
    }

    public static string? GetDescription(this Enum? value)
    {
        if(value is null)
            return null;

        var field = value.GetType()
            .GetField(value.ToString());

        if (field is null)
            return null;

        if (Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is not DescriptionAttribute descAttr)
            return null;
        return descAttr.Description;
    }
}
