using API.Interfaces;
using API.Repository;
using API.Services;
using Excalibur4.IBIS.Models.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace API.Controllers
{
    /// <summary>
    /// PiggyBank Controller to Add US Coins to a jar, get the value of money in the jar and empty the jar
    /// </summary>
    [ApiController]
    [Route("[controller]")]    
    public class PiggyBank : ControllerBase
    {
        private readonly IBusinessLogic _businessLogic;
        private readonly ILogger<PiggyBank> _logger;

        /// <summary>
        /// Dependancy Injection to add logger and Business Logic Layer
        /// </summary>
        /// <param name="businessLogic">Services layer to handle all logic</param>
        /// <param name="logger"></param>
        public PiggyBank(IBusinessLogic businessLogic, ILogger<PiggyBank> logger)
        {
            _businessLogic = businessLogic;
            _logger = logger;
        }


        /// <summary>
        /// Add a coin to the coinJar by accepting the type of coin which it is
        /// </summary>
        /// <param name="request">Envelope and The actual Type of coin</param>
        /// <returns>EnvelopeFooter</returns>
        /// <response code="200">Coin Added</response>
        [HttpPost]
        public ActionResult<EnvelopeFooter> AddCoin(Envelope<Enums.Type> request)
        {
            //Validate Request
            EnvelopeFooter result = new EnvelopeFooter();
            result.ExceptionThrown = false;

            try
            {
                if (request != null)
                {
                    if (request.EnvelopeHeader.EnableLogging)
                    {
                        _logger.LogInformation("Logging Enabled for Request");
                        _logger.LogInformation("Adding coin to jar");
                    }
                    _businessLogic.AddCoin(request.EnvelopeBody.FirstOrDefault());

                    result.ResponseMessage = $"Success, {request.EnvelopeBody.FirstOrDefault()} Added";
                }
                else
                {
                    result.ResponseMessage = "Request Cannot be NULL";
                }
            }
            catch (Exception ex)
            {
                result.ExceptionThrown = true;
                result.ExceptionMessage = ex.Message;

                if (ex.InnerException != null)
                {
                    if (!string.IsNullOrEmpty(ex.InnerException.Message))
                    {
                        result.ExceptionMessage += "\n Inner Exception: " + ex.InnerException.Message;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Gets the total ammount of money currently in the jar denoted in US dollars
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<EnvelopeFooter> GetValueInJar()
        {
            EnvelopeFooter result = new EnvelopeFooter();
            result.ExceptionThrown = false;

            try
            {
                var ammount = _businessLogic.GetTotalAmount();
                result.ResponseMessage = "Ammount in Jar: $" + ammount.ToString();
            }
            catch (Exception ex)
            {
                result.ExceptionThrown = true;
                result.ExceptionMessage = ex.Message;

                if (ex.InnerException != null)
                {
                    if (!string.IsNullOrEmpty(ex.InnerException.Message))
                    {
                        result.ExceptionMessage += "\n Inner Exception: " + ex.InnerException.Message;
                    }
                }
            }
            return result;

        }

        /// <summary>
        /// Reset the Jar back to zero and remove all coins
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public ActionResult<EnvelopeFooter> EmptyJar()
        {
            EnvelopeFooter result = new EnvelopeFooter();
            result.ExceptionThrown = false;

            try
            {
                _businessLogic.Reset();
                result.ResponseMessage = "Success, Jar Empty.";
            }
            catch (Exception ex)
            {
                result.ExceptionThrown = true;
                result.ExceptionMessage = ex.Message;

                if (ex.InnerException != null)
                {
                    if (!string.IsNullOrEmpty(ex.InnerException.Message))
                    {
                        result.ExceptionMessage += "\n Inner Exception: " + ex.InnerException.Message;
                    }
                }
            }
            return result;
        }
    }
}
