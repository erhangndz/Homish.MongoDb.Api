using AutoMapper;
using DataAccessLayer.Abstract;
using DtoLayer.DTOS.BannerDtos;
using DtoLayer.DTOS.CityDtos;
using DtoLayer.Shared.Dtos;
using EntityLayer.Concrete;
using EntityLayer.Settings.Abstract;
using EntityLayer.Settings.Concrete;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class CityService : ICityService
    {
        private readonly IMongoCollection<City> _cityCollection;
        private readonly IMapper _mapper;

        public CityService(IMapper mapper,IDatabaseSettings databaseSettings)
        {
            _mapper = mapper;
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _cityCollection = database.GetCollection<City>(databaseSettings.CityCollectionName);
        }

        public async Task<Response<NoContent>> CreateAsync(CreateCityDto createCityDto)
        {
            var values = _mapper.Map<City>(createCityDto);
            await _cityCollection.InsertOneAsync(values);
            return Response<NoContent>.Success(200);
        }

        public async Task<Response<NoContent>> DeleteAsync(string id)
        {
            await _cityCollection.DeleteOneAsync(x => x.CityID == id);
            return Response<NoContent>.Success(200);
        }

        public async Task<Response<List<ResultCityDto>>> GetAllAsync()
        {
            var values = await _cityCollection.Find(value => true).ToListAsync();
            return Response<List<ResultCityDto>>.Success(_mapper.Map<List<ResultCityDto>>(values), 200);
        }

        public async Task<Response<ResultCityDto>> GetByIdAsync(string id)
        {
            var value = await _cityCollection.Find<City>(x => x.CityID == id).FirstOrDefaultAsync();
            if (value == null)
            {
                return Response<ResultCityDto>.Fail("Şehir Bilgisi Bulunamadı", 404);

            }

            return Response<ResultCityDto>.Success(_mapper.Map<ResultCityDto>(value), 200);
        }

        public async Task<Response<NoContent>> UpdateAsync(UpdateCityDto updateCityDto)
        {
            var values = _mapper.Map<City>(updateCityDto);
            var result = await _cityCollection.FindOneAndReplaceAsync(x => x.CityID == updateCityDto.CityID, values);
            return Response<NoContent>.Success(200);
        }
    }
}
