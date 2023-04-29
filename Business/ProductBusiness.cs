using webApi.Data;

namespace webApi.Business
{
    public class ProductBusiness
    {
        private readonly ContextDb _context;

        public ProductBusiness(ContextDb context)
        {
            _context = context;
        }

        public bool UpdateStock(int quantity, int id)
        {
            var product = _context.Products.Find(id);

            if (product == null)
            {
                return false;
            }

            if (quantity <= product.Stock)
            {
                product.Stock -= quantity;
                _context.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
