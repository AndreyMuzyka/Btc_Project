using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DAL.Interfaces;
using DAL.Model.Dto;
using DAL.Model.Entity;
using NLog;
using RestSharp;

namespace BittrexApi
{
    public class BittrexService
    {
        private IRepository<Bittrex> _bittrexRepository;
        private Logger _logger = LogManager.GetCurrentClassLogger();

        public BittrexService(IRepository<Bittrex> bittrexRepository)
        {
            _bittrexRepository = bittrexRepository;
        }

        public async Task<Rootobject> GetOrdersBySendBgs()
        {
            var client = new RestClient
            {
                BaseUrl = new Uri("https://bittrex.com/"),
                Encoding = Encoding.UTF8
            };
            var request = new RestRequest("api/v1.1/public/getmarketsummaries", Method.GET)
            {
                RequestFormat = DataFormat.Json
            };
            var response = await client.ExecuteTaskAsync<Rootobject>(request);
            return response.Data;
        }

        public async Task<bool> Worker()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var result = false;
            try
            {
                var bittrixResult = await GetOrdersBySendBgs();
                if (bittrixResult.success)
                {
                    var bittrix = Mapper.Map<IEnumerable<Result>, IEnumerable<Bittrex>>(bittrixResult.result);
                    await _bittrexRepository.InsertBatch(bittrix);
                }
                else
                {
                    _logger.Error("Ошибка получения данных с апи Bittrex !!!");
                }
                stopwatch.Stop();
                _logger.Info("Время: {0} ms.", stopwatch.ElapsedMilliseconds);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return result;
        }
    }
}
