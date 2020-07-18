using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WPFApiParser.Model
{
    public static class ExtensionMethods
    {
        public static string RemoveQuotes(this string text)
        {
             return text.Replace("\"", "");             
        }
    }
}
