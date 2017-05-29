using System.Web.Mvc;

//Your Project Namespace here
namespace LoggerPortal.HtmlHelpers
{
    //Example of a Static class
    public static class HtmlHelpers
    {
        public static string ActivePage(this HtmlHelper helper, string controller)
        {
            string classValue = "";
            string currentController = helper.ViewContext.Controller.ValueProvider.GetValue("controller").RawValue.ToString();
            if (currentController == controller)
                classValue = "active";
            return classValue;
        }
    }
}