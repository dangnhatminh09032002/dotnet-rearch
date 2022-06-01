using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using System.Text.RegularExpressions;

namespace aspNetCore_cs46.module
{
    public class HtmlModule
    {
        private string _html = "";

        public string Html { get => _html; }

        public HtmlModule(string fileName)
        {
            string path = Path.GetFullPath($"src/views/{fileName}");
            string html = File.ReadAllText(path);
            _html = html;
        }

        public string AddProp(string key, object value)
        {
            // match với {{name}}, {{   name }}, {{name  }} -> Nghĩa là bất kỳ khoảng trắng nào đều khớp
            string pattern = @"({{)(\s){0,}(" + key + @")(\s){0,}(}})";
            Regex rx = new Regex(pattern);
            _html = rx.Replace(_html, value.ToString());
            return _html;
        }

        public string AddRangeProp(List<KeyValuePair<string, object>> props)
        {
            props.ForEach(kvp => AddProp(kvp.Key, kvp.Value));
            return _html;
        }
    }
}
