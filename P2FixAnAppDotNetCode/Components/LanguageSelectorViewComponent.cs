using Microsoft.AspNetCore.Mvc;
using P2FixAnAppDotNetCode.Models.Services;
using P2FixAnAppDotNetCode.Models.ViewModels;

namespace P2FixAnAppDotNetCode.Components
{
    public class LanguageSelectorViewComponent : ViewComponent
    {
        private readonly ILanguageService _languageService;

        public LanguageSelectorViewComponent(ILanguageService languageService)
        {
            _languageService = languageService;
        }

        public IViewComponentResult Invoke()
        {
            var model = new LanguageViewModel
            {
                Language = _languageService.SetCulture(HttpContext.Request.Query["language"])
            };

            return View(model);
        }
    }
}