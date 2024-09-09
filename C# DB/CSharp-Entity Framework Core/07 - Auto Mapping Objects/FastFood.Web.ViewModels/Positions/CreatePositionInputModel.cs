namespace FastFood.Web.ViewModels.Positions
{
    using Common.EntityConfiguration;
    using System.ComponentModel.DataAnnotations;

    public class CreatePositionInputModel
    {
        //[StringLength(ViewModelsValidation.POSITION_NAME_MAX_LENGTH, MinimumLength = ViewModelsValidation.POSITION_NAME_MIN_LENGTH, ErrorMessage = ErrorMessages.POSITION_NAME_ERROR_MESSAGE)]/* - Error message can be raised if validation is not successful.*/
        [MinLength(ViewModelsValidation.POSITION_NAME_MIN_LENGTH)]
        [MaxLength(ViewModelsValidation.POSITION_NAME_MAX_LENGTH)]
        public string PositionName { get; set; } = null!;
    }
}