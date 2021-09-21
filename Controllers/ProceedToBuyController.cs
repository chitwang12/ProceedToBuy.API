using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProceedToBuy.API.Models;
using ProceedToBuy.API.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProceedToBuy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProceedToBuyController : ControllerBase
    {
        IProceedToBuyRepository<CartModel> _repository;
        public ProceedToBuyController(IProceedToBuyRepository<CartModel> repository)
        {
            _repository = repository;
        }


        [HttpGet("GetWishList/{Customer Id}")]
        public IEnumerable<VendorWishlistModel> GetWishList(int Customerid)
        {
            return _repository.GetWishlist(Customerid);
        }

        [Route("WishList")]
        [HttpPost]
        public IActionResult WishList(VendorWishlistModel vendorWishlistModel)
        {
            _repository.AddToWishList(vendorWishlistModel);
            return Ok("Success");
        }

        //Just for testing purpose might delete it later.
        [HttpGet]
        public IEnumerable<CartModel> getCart()
        {
            return _repository.GetCart();
        }

        [HttpGet("GetCart/{Customer Id}")]
        public IEnumerable<CartModel> GetCartDetails(int Customerid)
        {
            return _repository.getCartDetails(Customerid);
        }


        [HttpPost("AddtoCart")]
        public IActionResult addToCart([FromBody] SampleModel sampleModel)
        {
           var res =  _repository.AddProductToCart(sampleModel);
            if (res)
            {
                return Ok("Success");
            }
            else
                return BadRequest("Request Failed");
        }

        [HttpDelete("DeleteCart/{Customer Id}/{Product Id}")]
        public IActionResult DeleteCart(int CustomerId, int ProductId)
        {
            var res = _repository.DeleteCart(CustomerId, ProductId);
            if (res)
            {
                return Ok("Success");
            }
            else
                return BadRequest("Request Failed");
        }


        [HttpDelete("DeleteCartById/{Customer Id}")]
        public IActionResult DeleteCartById(int CustomerId)
        {
            var res = _repository.DeleteCartByIdOnly(CustomerId);
            if (res)
            {
                return Ok("Success");
            }
            else
                return BadRequest("Request Failed");
        }
    }
}
