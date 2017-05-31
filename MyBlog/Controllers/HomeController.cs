using System.Web.Mvc;
using MyBlog.Features;
using MyBlog.Models.ViewModels;

namespace MyBlog.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Language()
        {
            ViewBag.Title = Name.IsEnglish() ? "Ana Sayfa" : "Home";
            ViewBag.active = "Home";
            if ((string)Session["Lang"] == "English")
                Session["Lang"] = "Turkish";
            else
                Session["Lang"] = "English";

            return RedirectToAction("Index");
        }

        public ActionResult Index()
        {
            ViewBag.Title = Name.IsEnglish() ? "Home" : "Ana Sayfa";
            ViewBag.active = "Home";
            
                var model = new IndexVM
                {
                    MatchBetweenSystemAndtheRealWorldContent = IndexStrings.MatchBetweenSystemAndtheRealWorldContent,
                    MatchBetweenSystemAndtheRealWorldTitle = IndexStrings.MatchBetweenSystemAndtheRealWorldTitle,
                    RecognitionRatherThanRecallContent = IndexStrings.RecognitionRatherThanRecallContent,
                    RecognitionRatherThanRecallTitle = IndexStrings.RecognitionRatherThanRecallTitle,
                    VisibilityOfSystemStatusContent = IndexStrings.VisibilityOfSystemStatusContent,
                    VerificationVsValidationContent = IndexStrings.VerificationVsValidationContent,
                    AvoidCreatingUnnecessaryObjects = IndexStrings.AvoidCreatingUnnecessaryObjects,
                    VerificationVsValidationTitle = IndexStrings.VerificationVsValidationTitle,
                    VisibilityOfSystemStatusTitle = IndexStrings.VisibilityOfSystemStatusTitle,
                    UserControlandFreedomContent = IndexStrings.UserControlandFreedomContent,
                    UserControlandFreedomTitle = IndexStrings.UserControlandFreedomTitle,
                    UseNativeMethodsCarefully = IndexStrings.UseNativeMethodsCarefully,
                    DontDoWorkThatYouDontNeed = IndexStrings.DontDoWorkThatYouDontNeed,
                    PreferStaticOverVirtual = IndexStrings.PreferStaticOverVirtual,
                    ErrorPreventionContent = IndexStrings.ErrorPreventionContent,
                    DesignHeuristicsTitle = IndexStrings.DesignHeuristicsTitle,
                    DesignPatternsContent = IndexStrings.DesignPatternsContent,
                    ErrorPreventionTitle = IndexStrings.ErrorPreventionTitle,
                    DesignPatternsTitle = IndexStrings.DesignPatternsTitle,
                    UseEnhancedForLoop = IndexStrings.UseEnhancedForLoop,
                    SeparationContent = IndexStrings.SeparationContent,
                    VariablesContent = IndexStrings.VariablesContent,
                    SeparationTitle = IndexStrings.SeparationTitle,
                    VariablesTitle = IndexStrings.VariablesTitle,
                    CleanCode = IndexStrings.CleanCode
                };
            if (Name.IsEnglish())
            {
                model.MatchBetweenSystemAndtheRealWorldContent = IndexStrings.MatchBetweenSystemAndtheRealWorldContentEnglish;
                model.MatchBetweenSystemAndtheRealWorldTitle = IndexStrings.MatchBetweenSystemAndtheRealWorldTitleEnglish;
                model.RecognitionRatherThanRecallContent = IndexStrings.RecognitionRatherThanRecallContentEnglish;
                model.RecognitionRatherThanRecallTitle = IndexStrings.RecognitionRatherThanRecallTitleEnglish;
                model.VerificationVsValidationContent = IndexStrings.VerificationVsValidationContentEnglish;
                model.VisibilityOfSystemStatusContent = IndexStrings.VisibilityOfSystemStatusContentEnglish;
                model.AvoidCreatingUnnecessaryObjects = IndexStrings.AvoidCreatingUnnecessaryObjectsEnglish;
                model.VisibilityOfSystemStatusTitle = IndexStrings.VisibilityOfSystemStatusTitleEnglish;
                model.VerificationVsValidationTitle = IndexStrings.VerificationVsValidationTitleEnglish;
                model.UserControlandFreedomContent = IndexStrings.UserControlandFreedomContentEnglish;
                model.UserControlandFreedomTitle = IndexStrings.UserControlandFreedomTitleEnglish;
                model.DontDoWorkThatYouDontNeed = IndexStrings.DontDoWorkThatYouDontNeedEnglish;
                model.UseNativeMethodsCarefully = IndexStrings.UseNativeMethodsCarefullyEnglish;
                model.PreferStaticOverVirtual = IndexStrings.PreferStaticOverVirtualEnglish;
                model.ErrorPreventionContent = IndexStrings.ErrorPreventionContentEnglish;
                model.DesignHeuristicsTitle = IndexStrings.DesignHeuristicsTitleEnglish;
                model.DesignPatternsContent = IndexStrings.DesignPatternsContentEnglish;
                model.ErrorPreventionTitle = IndexStrings.ErrorPreventionTitleEnglish;
                model.DesignPatternsTitle = IndexStrings.DesignPatternsTitleEnglish;
                model.UseEnhancedForLoop = IndexStrings.UseEnhancedForLoopEnglish;
                model.SeparationContent = IndexStrings.SeparationContentEnglish;
                model.VariablesContent = IndexStrings.VariablesContentEnglish;
                model.SeparationTitle = IndexStrings.SeparationTitleEnglish;
                model.VariablesTitle = IndexStrings.VariablesTitleEnglish;
                model.CleanCode = IndexStrings.CleanCodeEnglish;


            }
            return View(model);
        }

             
             
        

    


                    

        public ActionResult Contact()
        {
            ViewBag.Title = Name.IsEnglish() ? "Ana Sayfa" : "Home";
            ViewBag.Message = "Your contact page.";

            if ((string)Session["Lang"] == "English")
                Session["Lang"] = "Turkish";
            else
                Session["Lang"] = "English";

            return View("Index");
        }
    }
}