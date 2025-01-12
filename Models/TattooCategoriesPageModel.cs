using Microsoft.AspNetCore.Mvc.RazorPages;
using Proiect.Data;

namespace Proiect.Models
{
    public class TattooCategoriesPageModel :PageModel
    {
        public List<AssignedCategoryData> AssignedCategoryDataList;
        
        public void PopulateAssignedCategoryData(ProiectContext context, Tatuaj tatuaj)
        {
            var allCategories = context.Category;
            var tattooCategories = new HashSet<int>(tatuaj.TattooCategories.Select(c => c.CategoryID));
            AssignedCategoryDataList = new List<AssignedCategoryData>();
            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    CategoryID = cat.ID,
                    Name = cat.CategoryName,
                    Assigned = tattooCategories.Contains(cat.ID)
                });
            }
        }

        public void UpdateTattooCategories(ProiectContext context, string[] selectedCategories, Tatuaj tattooToUpdate)
        {
            if(selectedCategories == null)
            {
                tattooToUpdate.TattooCategories = new List<TattooCategory>();
                return;
            }
            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var tattooCategories = new HashSet<int>(tattooToUpdate.TattooCategories.Select(c => c.CategoryID));
            foreach(var cat in context.Category)
            {
                if(selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if(!tattooCategories.Contains(cat.ID))
                    {
                        tattooToUpdate.TattooCategories.Add(new TattooCategory
                        {
                            TatuajID = tattooToUpdate.ID,
                            CategoryID = cat.ID
                        });
                    }
                }
                else
                {
                    if(tattooCategories.Contains(cat.ID))
                    {
                        TattooCategory tattooToRemove = tattooToUpdate.TattooCategories.SingleOrDefault(i => i.CategoryID == cat.ID);
                        context.Remove(tattooToRemove);
                    }
                }
            }
        }
    }
}
