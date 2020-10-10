using KK.Cookbook.Models.ViewData;
using NUnit.Framework;
using System.Collections.Generic;

namespace CookbookAppUnitTests.ViewData
{
    public class RecipeViewDataTests
    {
        private RecipeViewData recipeViewData;

        [Test]
        public void Correctly_creates_a_new_instance()
        {
            recipeViewData = new RecipeViewData
            {
                Comments = new List<CommentViewData>(),
                Stages = new List<StageViewData>()
            };

            Assert.AreEqual(0, recipeViewData.CommentsCount);
            Assert.AreEqual(0, recipeViewData.StagesCount);
        }
    }
}
