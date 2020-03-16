using freecodecampapi.Domain.Models;

namespace freecodecampapi.Services.Communication
{
    public class ProductResponse : BaseResponse
    {

        public Product Product { get; private set; }

        private ProductResponse(bool Success, string Message, Product product) : base(Success, Message)
        {
            Product = product;
        }

        public ProductResponse(Product product) : this(true, string.Empty, product) { }

        public ProductResponse(string Message) : this(false, Message, null) { }
    }
}