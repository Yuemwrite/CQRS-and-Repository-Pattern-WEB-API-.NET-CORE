using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Core.Constants;
public static class RegularEx
{
    public static bool IsNumeric(string num)
    {
        var regex = new Regex(@"^[0-9]+$");
        return regex.IsMatch(num);
    }

    public static bool IsString(string chr)
    {
        var regex = new Regex(@"^[A-Za-z\s]+$");
        return regex.IsMatch(chr);
    }
}
