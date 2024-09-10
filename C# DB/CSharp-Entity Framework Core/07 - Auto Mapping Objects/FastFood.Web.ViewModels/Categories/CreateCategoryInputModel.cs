namespace FastFood.Web.ViewModels.Categories
{
    using System.ComponentModel.DataAnnotations;

    using Common.EntityConfiguration;

    public class CreateCategoryInputModel
    {
        [MinLength(ViewModelsValidation.CATEGORY_NAME_MIN_LENGTH)]
        [MaxLength(ViewModelsValidation.CATEGORY_NAME_MAX_LENGTH)]
        public string CategoryName { get; set; } = null!;
    }
}
