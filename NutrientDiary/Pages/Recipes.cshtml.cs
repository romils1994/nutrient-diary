using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

namespace NutrientDiary.Pages
{
    public class RecipesModel : PageModel
    {
        public List<Recipes.MostViewedRecipe> MostViewedRecipes;

        public string Error;
        public void OnGet()
        {
            String url = "https://momsspaghetti.azurewebsites.net/?getMostSearched=true";

            using (var webClient = new WebClient())
            {
                try
                {
                    string mostViewedRecipeString = webClient.DownloadString(url);
                    JSchema mostViewedRecipeSchema = JSchema.Parse(System.IO.File.ReadAllText("MostViewedRecipeSchema.json"));
                    JArray mostViewedRecipeArr = JArray.Parse(mostViewedRecipeString);
                    IList<string> validationEvents = new List<string>();
                    if (mostViewedRecipeArr.IsValid(mostViewedRecipeSchema))
                    {
                        MostViewedRecipes = Recipes.MostViewedRecipe.FromJson(mostViewedRecipeString);
                    }
                }
                catch (Exception ex)
                {
                    Error = "Something went wrong! Could not reach the API Servers";
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.StackTrace.ToString());
                }
            }
        }
    }
}
