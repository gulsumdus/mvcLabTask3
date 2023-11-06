using Microsoft.AspNetCore.Razor.TagHelpers;
namespace MVClab3.TagHelpers
{
    [HtmlTargetElement("item-link")]
    public class ItemLinkTagHelper : TagHelper
    {

        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public int ItemId { get; set; }
        public string DisplayText { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            output.Attributes.SetAttribute("href", $"/{ControllerName}/{ActionName}/{ItemId}");
            output.Content.SetContent(DisplayText);
        }
    }
}
