using System.Text;
using System.Text.RegularExpressions;

namespace MarkdownTocApp.Services;

public class TocGeneratorService
{
    public record HeadingInfo(int Level, string Text, string Anchor);

    public List<HeadingInfo> ParseHeadings(string markdown)
    {
        var headings = new List<HeadingInfo>();
        if (string.IsNullOrWhiteSpace(markdown))
            return headings;

        var lines = markdown.Split('\n');
        foreach (var line in lines)
        {
            var trimmedLine = line.TrimStart();
            if (trimmedLine.StartsWith('#'))
            {
                var match = Regex.Match(trimmedLine, @"^(#{1,6})\s+(.+)");
                if (match.Success)
                {
                    var level = match.Groups[1].Value.Length;
                    var text = match.Groups[2].Value.Trim();
                    var anchor = GenerateAnchor(text);
                    headings.Add(new HeadingInfo(level, text, anchor));
                }
            }
        }

        return headings;
    }

    public string GenerateMarkdownToc(List<HeadingInfo> headings)
    {
        if (headings.Count == 0)
            return string.Empty;

        var sb = new StringBuilder();
        var minLevel = headings.Min(h => h.Level);

        foreach (var heading in headings)
        {
            var indent = new string(' ', (heading.Level - minLevel) * 2);
            sb.AppendLine($"{indent}- [{heading.Text}](#{heading.Anchor})");
        }

        return sb.ToString().TrimEnd();
    }

    public string GenerateHtmlToc(List<HeadingInfo> headings)
    {
        if (headings.Count == 0)
            return string.Empty;

        var sb = new StringBuilder();
        var minLevel = headings.Min(h => h.Level);
        var currentLevel = minLevel - 1;

        foreach (var heading in headings)
        {
            while (currentLevel < heading.Level - 1)
            {
                currentLevel++;
                sb.AppendLine($"{new string(' ', (currentLevel - minLevel) * 2)}<ul>");
            }

            while (currentLevel > heading.Level - 1)
            {
                sb.AppendLine($"{new string(' ', (currentLevel - minLevel) * 2)}</ul>");
                currentLevel--;
            }

            if (currentLevel < heading.Level - 1)
            {
                currentLevel++;
                sb.AppendLine($"{new string(' ', (currentLevel - minLevel) * 2)}<ul>");
            }

            var indent = new string(' ', (heading.Level - minLevel) * 2);
            sb.AppendLine($"{indent}<li><a href=\"#{heading.Anchor}\">{System.Net.WebUtility.HtmlEncode(heading.Text)}</a></li>");
            currentLevel = heading.Level - 1;
        }

        while (currentLevel >= minLevel - 1)
        {
            if (currentLevel >= minLevel)
            {
                sb.AppendLine($"{new string(' ', (currentLevel - minLevel) * 2)}</ul>");
            }
            currentLevel--;
        }

        return sb.ToString().TrimEnd();
    }

    private string GenerateAnchor(string text)
    {
        // Convert to lowercase
        var anchor = text.ToLowerInvariant();
        
        // Remove special characters and replace spaces with hyphens
        anchor = Regex.Replace(anchor, @"[^\w\s-]", "");
        anchor = Regex.Replace(anchor, @"\s+", "-");
        anchor = Regex.Replace(anchor, @"-+", "-");
        anchor = anchor.Trim('-');
        
        return anchor;
    }
}
