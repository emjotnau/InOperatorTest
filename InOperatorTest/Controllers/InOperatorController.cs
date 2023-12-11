using InOperatorTest.Dto;
using InOperatorTest.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Attributes;

namespace InOperatorTest.Controllers
{
    [ApiController]
    [Route("/cr")]
    public class InOperatorController : ControllerBase
    {
        [EnableQuery()]
        [ODataAttributeRouting]
        [HttpGet("countries")]

        public  IQueryable<CountryListDto> GetCountries([FromServices] CountryRepository countryRepository) 
        {
            return countryRepository.GetCountries();
        }
    }
}
