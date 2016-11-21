using System.Text;

namespace WFDP
{
    public class HtmlConverter : IConverter
    {
        public string Convert(string input)
        {
            var sb = new StringBuilder(input);
            sb.Replace("<", "&lt;");
            sb.Replace(">", "&ht;");
            return sb.ToString();
        }
    }
}