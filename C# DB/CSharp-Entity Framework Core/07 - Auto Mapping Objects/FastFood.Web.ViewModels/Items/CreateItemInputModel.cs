namespace FastFood.Web.ViewModels.Items
{
    using System.ComponentModel.DataAnnotations;

    using Common.EntityConfiguration;

    public class CreateItemInputModel
    {
        [MinLength(ViewModelsValidation.ITEM_NAME_MIN_LENGTH)]
        [MaxLength(ViewModelsValidation.ITEM_NAME_MAX_LENGTH)]
        public string Name { get; set; } = null!;

        [Range(typeof(decimal), "0.01", "79228162514264337593543950335")]
        public decimal Price { get; set; }

        public int CategoryId { get; set; }
    }
}
