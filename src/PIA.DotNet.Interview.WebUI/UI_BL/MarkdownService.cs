using Markdig;
using System.IO;

namespace PIA.DotNet.Interview.WebUI.UI_BL
{
    public class MarkdownService : IMarkdownService
    {
        public  string Parse(string markdownPath)
        {
            string markdown = File.ReadAllText(markdownPath);

            var pipeline = new MarkdownPipelineBuilder()
                .UseAdvancedExtensions()
                .Build();

            return Markdown.ToHtml(markdown, pipeline);
        }
    }
}
