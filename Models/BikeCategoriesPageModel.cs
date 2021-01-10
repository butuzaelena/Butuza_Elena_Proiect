using Butuza_Elena_Proiect.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Butuza_Elena_Proiect.Models
{
    public class BikeCategoriesPageModel : PageModel
    {

        public List<AssignedCategoryData> AssignedCategoryDataList;
        public void PopulateAssignedCategoryData(Butuza_Elena_ProiectContext context,
         Bike bike)
        {
            var allCategories = context.Category;
            var bikeCategories = new HashSet<int>(
            bike.BikeCategories.Select(c => c.BikeID));
            AssignedCategoryDataList = new List<AssignedCategoryData>();
            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    CategoryID = cat.ID,
                    Name = cat.CategoryName,
                    Assigned = bikeCategories.Contains(cat.ID)
                });
            }
        }
        public void UpdateBikeCategories(Butuza_Elena_ProiectContext context,
        string[] selectedCategories, Bike bikeToUpdate)
        {
            if (selectedCategories == null)
            {
                bikeToUpdate.BikeCategories = new List<BikeCategory>();
                return;
            }
            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var bikeCategories = new HashSet<int>
            (bikeToUpdate.BikeCategories.Select(c => c.Category.ID));
            foreach (var cat in context.Category)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!bikeCategories.Contains(cat.ID))
                    {
                        bikeToUpdate.BikeCategories.Add(
                        new BikeCategory
                        {
                            BikeID = bikeToUpdate.ID,
                            CategoryID = cat.ID
                        });
                    }
                }
                else
                {
                    if (bikeCategories.Contains(cat.ID))
                    {
                        BikeCategory courseToRemove
                        = bikeToUpdate
                        .BikeCategories
                        .SingleOrDefault(i => i.CategoryID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}

