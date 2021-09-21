using ProceedToBuy.API.Data;
using ProceedToBuy.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProceedToBuy.API.Repository
{//final
    public class ProceedToBuyRepository : IProceedToBuyRepository<CartModel>
    {
        ProceedToBuyContext _context;
        public ProceedToBuyRepository(ProceedToBuyContext context)
        {
            _context = context;
        }

        //Cart Wale Methods 
        /*getWishlist(customerId)------> wishlistModel
         *addProductToWishlist(wishlistModel)------>return status;
         *addProductToCart(CartModel) ------> return status;
         *GetCartDetails(customerId) --------> return CartModel
         *DeleteCart(customerId,ProductId)-----> return Record;
         *DeleteCart(CustomerId) -------> CartModelkiEnteries
         *
         */
        public List<VendorWishlistModel> GetWishlist(int CustomerId)
        {
            return _context.VendorWishlists.Where(v => v.CustomerId == CustomerId).ToList();
        }
        public bool AddToWishList(VendorWishlistModel vendorWishlistModel)
        {
            VendorWishlistModel vendorWishlist = new VendorWishlistModel();
            vendorWishlist.CustomerId = vendorWishlistModel.CustomerId;
            vendorWishlist.ProductId = vendorWishlistModel.ProductId;
            vendorWishlist.DateAddedToWishlist = DateTime.Now;
            _context.VendorWishlists.Add(vendorWishlist);
            _context.SaveChanges();
            return true;
        }
        public bool AddProductToCart(SampleModel sampleModel)
        {
            CartModel sample1= new CartModel();
            sample1.CartId = sampleModel.Carts.CartId;
            sample1.CustomerId = sampleModel.Carts.CustomerId;
            sample1.ProductId = sampleModel.Carts.ProductId;
            sample1.DeliveryDate = sampleModel.Carts.DeliveryDate;
            sample1.Zipcode = sampleModel.Carts.Zipcode;
            sample1.vendors.Id = sampleModel.Vendors.Id;
            sample1.vendors.Name = sampleModel.Vendors.Name;
            sample1.vendors.Rating = sampleModel.Vendors.Rating;
            sample1.vendors.DeliveryCharge = sampleModel.Vendors.DeliveryCharge;
            _context.Carts.Add(sample1);
            _context.SaveChanges();
            return true;

        }
        //This method is only for backend purpose just to fetch the records that's it for further processing.
        public List<CartModel> GetCart()
        {

            return _context.Carts.ToList();
        }

        public List<CartModel> getCartDetails(int CustomerId)
        {
            return _context.Carts.Where(v => v.CustomerId == CustomerId).ToList();
        }

        public bool DeleteCart(int CustomerId,int ProductId)
        {
            List<CartModel> cart = GetCart();
            foreach (CartModel item in cart)
            {
                if (item.CustomerId == CustomerId)
                    _context.Carts.Remove(item);
            }

            _context.SaveChanges();

            return true;
        }
        public bool DeleteCartByIdOnly(int CustomerId)
        {

            CartModel cart = GetCart().SingleOrDefault(x => x.CustomerId == CustomerId);
            _context.Carts.Remove(cart);
            _context.SaveChanges();
            return true;
        }


    }

    }

