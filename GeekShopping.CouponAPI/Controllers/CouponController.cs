using GeekShopping.CouponAPI.Data.ValueObjects;
using GeekShopping.CouponAPI.Model;
using GeekShopping.CouponAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.CouponAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CouponController : ControllerBase
    {
        private ICouponRepository _repository;

        public CouponController(ICouponRepository repository)
        {
            _repository = repository ?? throw new ArgumentException(nameof(repository));
        }

        [HttpGet("{couponCode}")]
        public async Task<ActionResult<CouponVO>> FindById(string couponCode)
        {
            var coupon = await _repository.GetCouponByCouponCode(couponCode);
            if (coupon.Id <= 0)
            {
                return NotFound();
            }
            return base.Ok((object)coupon);
        }
    }
}
