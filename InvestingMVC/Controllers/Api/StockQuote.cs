using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using static InvestingMVC.Controllers.Api.AlphaVantageApiWrapper;

namespace InvestingMVC.Controllers.Api
{
    public class StockQuote
    {
        public static async Task<AlphaVantageRootObject> GetTheQuoteAsync(string tickerName, int _type)
        {
            var parameters = new List<AlphaVantageApiWrapper.ApiParam>
                {
                    new AlphaVantageApiWrapper.ApiParam("function", AlphaVantageApiWrapper.AvFuncationEnum.Sma.ToDescription()),
                    new AlphaVantageApiWrapper.ApiParam("symbol", tickerName),
                    new AlphaVantageApiWrapper.ApiParam("interval", AlphaVantageApiWrapper.AvIntervalEnum.Daily.ToDescription()),
                    new AlphaVantageApiWrapper.ApiParam("time_period", "5"),
                    new AlphaVantageApiWrapper.ApiParam("series_type", AlphaVantageApiWrapper.AvSeriesType.Open.ToDescription()),
                };

            //Start Collecting SMA values

            //var SMA_5 = await AlphaVantageApiWrapper.GetTechnicalAsync(parameters, Constants.Values.AlphaAPIKey);
            //parameters.FirstOrDefault(x => x.ParamName == "time_period").ParamValue = "20";
            //var SMA_20 = await AlphaVantageApiWrapper.GetTechnicalAsync(parameters, Constants.Values.AlphaAPIKey);
            //parameters.FirstOrDefault(x => x.ParamName == "time_period").ParamValue = "50";
            //var SMA_50 = await AlphaVantageApiWrapper.GetTechnicalAsync(parameters, Constants.Values.AlphaAPIKey);
            //parameters.FirstOrDefault(x => x.ParamName == "time_period").ParamValue = "200";
            //var SMA_200 = await AlphaVantageApiWrapper.GetTechnicalAsync(parameters, Constants.Values.AlphaAPIKey);

            //Change function to EMA
            parameters.FirstOrDefault(x => x.ParamName == "function").ParamValue = AlphaVantageApiWrapper.AvFuncationEnum.Ema.ToDescription();

            parameters.FirstOrDefault(x => x.ParamName == "time_period").ParamValue = "5";
            var EMA_5 = await AlphaVantageApiWrapper.GetTechnicalAsync(parameters, Constants.Values.AlphaAPIKey);
            parameters.FirstOrDefault(x => x.ParamName == "time_period").ParamValue = "20";
            var EMA_20 = await AlphaVantageApiWrapper.GetTechnicalAsync(parameters, Constants.Values.AlphaAPIKey);
            parameters.FirstOrDefault(x => x.ParamName == "time_period").ParamValue = "50";
            var EMA_50 = await AlphaVantageApiWrapper.GetTechnicalAsync(parameters, Constants.Values.AlphaAPIKey);
            parameters.FirstOrDefault(x => x.ParamName == "time_period").ParamValue = "200";
            var EMA_200 = await AlphaVantageApiWrapper.GetTechnicalAsync(parameters, Constants.Values.AlphaAPIKey);

            //Change function to RSI
            parameters.FirstOrDefault(x => x.ParamName == "function").ParamValue = AlphaVantageApiWrapper.AvFuncationEnum.Rsi.ToDescription();

            parameters.FirstOrDefault(x => x.ParamName == "time_period").ParamValue = "7";
            var RSI_7 = await AlphaVantageApiWrapper.GetTechnicalAsync(parameters, Constants.Values.AlphaAPIKey);
            parameters.FirstOrDefault(x => x.ParamName == "time_period").ParamValue = "14";
            var RSI_14 = await AlphaVantageApiWrapper.GetTechnicalAsync(parameters, Constants.Values.AlphaAPIKey);
            parameters.FirstOrDefault(x => x.ParamName == "time_period").ParamValue = "24";
            var RSI_24 = await AlphaVantageApiWrapper.GetTechnicalAsync(parameters, Constants.Values.AlphaAPIKey);
            parameters.FirstOrDefault(x => x.ParamName == "time_period").ParamValue = "50";
            var RSI_50 = await AlphaVantageApiWrapper.GetTechnicalAsync(parameters, Constants.Values.AlphaAPIKey);

            //Change function to MACD
            parameters.FirstOrDefault(x => x.ParamName == "function").ParamValue = AlphaVantageApiWrapper.AvFuncationEnum.Macd.ToDescription();
            //Remove time period to use default values (slow 12, fast 26)
            var itemToRemove = parameters.FirstOrDefault(x => x.ParamName == "time_period");
            parameters.Remove(itemToRemove);
            var MACD = await AlphaVantageApiWrapper.GetTechnicalAsync(parameters, Constants.Values.AlphaAPIKey);

            //Change function to STOCK
            parameters.FirstOrDefault(x => x.ParamName == "function").ParamValue = AlphaVantageApiWrapper.AvFuncationEnum.Stoch.ToDescription();
            var STOCH = await AlphaVantageApiWrapper.GetTechnicalAsync(parameters, Constants.Values.AlphaAPIKey);

            return EMA_20;
        }
    }
}