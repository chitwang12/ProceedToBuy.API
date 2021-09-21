using ProceedToBuy.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProceedToBuy.API.Repository
{
    public interface IProceedToBuyRepository<T>
    {
        public List<VendorWishlistModel> GetWishlist(int id);
        bool AddToWishList(VendorWishlistModel vendorWishlistModel);
        public List<CartModel> getCartDetails(int CustomerId);
        bool DeleteCart(int CustomerId, int ProductId);
        bool DeleteCartByIdOnly(int CustomerId);
        //just for testing might delete later .
        List<CartModel> GetCart();

        bool AddProductToCart(SampleModel sampleModel);
    }
}
