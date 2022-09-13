namespace Assignment1;

using System.Text.RegularExpressions;

public static class RegExpr
{
    public static IEnumerable<string> SplitLine(IEnumerable<string> lines)
    {
        var splitPattern = @"\W";
        var matchPattern = @"[\w*]";

        foreach (var s in lines)
        {
            foreach (var w in Regex.Split(s, splitPattern))
            {
                if (Regex.Match(w, matchPattern).Success)
                {
                    yield return w;
                }
            }
        }
    }

    public static IEnumerable<(int width, int height)> Resolution(IEnumerable<string> resolutions)
    {
        var matchPattern = @"((?<width>\d+)x(?<height>\d+))";

        foreach (var res in resolutions)
        {
            foreach (Match match in Regex.Matches(res, matchPattern))
            {
                yield return (int.Parse(match.Groups["width"].Value), int.Parse(match.Groups["height"].Value));
            }
        }
    }

    public static IEnumerable<string> InnerText(string html, string tag)
    {
        var pattern = $@"<(?<tag>{tag}).*?>(?<text>.*?)<\/\1>";
        var patternNested = @"<.*?>";

        foreach (Match m in Regex.Matches(html, pattern))
        {
            var text = m.Groups["text"].Value;

            yield return Regex.Replace(text, patternNested, "");
        }
    }

    public static IEnumerable<(Uri url, string title)> Urls(string html) 
    {
        var pattern = @"href=""(?<link>.*?)"" title=""(?<title>.*?)""";

        foreach (Match m in Regex.Matches(html, pattern))
        {
            Uri link = new Uri(m.Groups["link"].Value);
            string title = m.Groups["title"].Value;

            yield return (link, title);
        }
    }
}