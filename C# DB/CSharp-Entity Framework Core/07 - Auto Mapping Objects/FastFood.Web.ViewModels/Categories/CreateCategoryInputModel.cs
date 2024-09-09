using FastFood.Common.EntityConfiguration;
using System.ComponentModel.DataAnnotations;

namespace FastFood.Web.ViewModels.Categories
{
    public class CreateCategoryInputModel
    {
        [MinLength(ViewModelsValidation.CATEGORY_NAME_MIN_LENGTH)]
        [MaxLength(ViewModelsValidation.CATEGORY_NAME_MAX_LENGTH)]
        public string CategoryName { get; set; } = null!;
    }
}
