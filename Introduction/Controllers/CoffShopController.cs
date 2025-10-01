using Introduction.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Introduction.Controllers
{

    [ApiController]
    [Route("api/[Controller]")]
    public class CoffeeShopController : ControllerBase
    {

        private readonly ISingletonCoffee _singleton1;
        private readonly ISingletonCoffee _singleton2;

        private readonly IScopedCoffee _scopedCoffee1;
        private readonly IScopedCoffee _scopedCoffee2;

        private readonly ITransientCoffee _transientCoffee1;
        private readonly ITransientCoffee _transientCoffee2;


        public CoffeeShopController(
           ISingletonCoffee singleton1,
           ISingletonCoffee singleton2,
           IScopedCoffee scopedCoffee1,
           IScopedCoffee scopedCoffee2,
           ITransientCoffee transientCoffee1,
           ITransientCoffee transientCoffee2)
        {
            _singleton1 = singleton1;
            _singleton2 = singleton2;

            _scopedCoffee1 = scopedCoffee1;
            _scopedCoffee2 = scopedCoffee2;

            _transientCoffee1 = transientCoffee1;
            _transientCoffee2 = transientCoffee2;
        }

        //

        [HttpGet]
        [Route("GetCoffee")]
        public IActionResult GetCoffee()
        {
            var SingleTonresult = new CoffeeType { cup1 = _singleton1.GetCoffeeId(), cup2 = _singleton2.GetCoffeeId() };

            var Scopedresult = new CoffeeType { cup1 = _scopedCoffee1.GetCoffeeId(), cup2 = _scopedCoffee2.GetCoffeeId() };

            var Transtitent = new CoffeeType { cup1 = _transientCoffee1.GetCoffeeId(), cup2 = _transientCoffee2.GetCoffeeId() };

            var FinalResult = new { SingleTonresult, Scopedresult, Transtitent };
            return Ok(new { FinalResult });
        }

    }


    public class CoffeeType
    {

        public string cup1 { get; set; }
        public string cup2 { get; set; }
    }


}