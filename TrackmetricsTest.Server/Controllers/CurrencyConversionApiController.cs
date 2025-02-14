using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Trackmetrics.Controllers;

[ApiController]
[Route("[controller]")]
public class CurrencyConversionApiController : ControllerBase
{
    private readonly ILogger<CurrencyConversionApiController> _logger;
    private readonly DbContext _dbContext;

    public CurrencyConversionApiController(ILogger<CurrencyConversionApiController> logger, DbContext context)
    {
        _logger = logger;
        _dbContext = context;
    }

    [HttpGet(Name = "GetConversions")]
    public IEnumerable<CurrencyConversion> Get()
    {
        return _dbContext.Set<CurrencyConversion>();
    }

    /// <summary>
    /// This should not be ion the controller but done to display some code of it working would 
    // seprate this code out into a service so it can have tests done against it and use repository for the data access
    /// </summary>
    [HttpPost(Name = "DoConversions")]
    public CurrencyConversionDTO Post([FromBody] CurrencyConversionCallDTO conversion)
    {
        try{
            string conversionName = $"GBP-{conversion.ConvertTo}";

            IQueryable<CurrencyConversion> query = _dbContext.Set<CurrencyConversion>();

            CurrencyConversionDTO returnValue = new(conversion.BaseValue * query.Where(c => c.Name.Equals(conversionName)).FirstOrDefault().Conversion);
            return returnValue;
        }
        catch (Exception ex){
            _logger.LogError(ex.Message);
            throw;
        }
    }
}
