using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;

namespace P2FixAnAppDotNetCode.Models.Services
{
    public class LanguageService : ILanguageService
    {
        public void ChangeUiLanguage(HttpContext context, string language)
        {
            var culture = SetCulture(language);
            UpdateCultureCookie(context, culture);
        }
        
        public string SetCulture(string language)
        {
            var culture = language switch
            {
                "English" => "en",
                "French" => "fr",
                "Spanish" => "es",
                _ => ""
            };

            return culture;
        }
        
        public void UpdateCultureCookie(HttpContext context, string culture)
        {
            context.Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions {Expires = System.DateTimeOffset.UtcNow.AddYears(1)}
            );
        }
    }
}
