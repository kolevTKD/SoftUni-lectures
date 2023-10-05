namespace CommandPattern.Models
{
    using Contracts;

    public class ProductCommand : ICommand
    {
        private readonly Product product;
        private readonly PriceAction priceAction;
        private readonly int amount;

        public ProductCommand(Product product, PriceAction priceAction, int amount)
        {
            this.product = product;
            this.priceAction = priceAction;
            this.amount = amount;
        }

        public void ExecuteAction()
        {
            if (priceAction == PriceAction.Increase)
            {
                product.IncreasePrice(amount);
            }
            else
            {
                product.DecreasePrice(amount);
            }
        }
    }
}
