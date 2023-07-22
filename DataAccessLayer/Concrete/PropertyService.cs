using AutoMapper;
using DataAccessLayer.Abstract;
using DtoLayer.DTOS.BannerDtos;
using DtoLayer.DTOS.PropertyDtos;
using DtoLayer.Shared.Dtos;
using EntityLayer.Concrete;
using EntityLayer.Settings.Abstract;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class PropertyService : IPropertyService
    {
        private readonly IMongoCollection<Property> _propertyCollection;
        private readonly IMapper _mapper;

        public PropertyService(IMapper mapper,IDatabaseSettings databaseSettings)
        {
            _mapper = mapper;
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _propertyCollection = database.GetCollection<Property>(databaseSettings.PropertyCollectionName);
        }

        public async Task<Response<NoContent>> CreateAsync(CreatePropertyDto createPropertyDto)
        {
            var values = _mapper.Map<Property>(createPropertyDto);
            await _propertyCollection.InsertOneAsync(values);
            return Response<NoContent>.Success(200);
        }

        public async Task<Response<NoContent>> DeleteAsync(string id)
        {
            await _propertyCollection.DeleteOneAsync(x => x.PropertyID == id);
            return Response<NoContent>.Success(200);
        }

        public async Task<Response<List<ResultPropertyDto>>> GetAllAsync()
        {
            var values = await _propertyCollection.Find(value => true).ToListAsync();
            return Response<List<ResultPropertyDto>>.Success(_mapper.Map<List<ResultPropertyDto>>(values), 200);
        }

        public async Task<Response<ResultPropertyDto>> GetByIdAsync(string id)
        {
            var value = await _propertyCollection.Find<Property>(x => x.PropertyID == id).FirstOrDefaultAsync();
            if (value == null)
            {
                return Response<ResultPropertyDto>.Fail("Emlak Bilgisi Bulunamadı", 404);

            }

            return Response<ResultPropertyDto>.Success(_mapper.Map<ResultPropertyDto>(value), 200);
        }

        public async Task<Response<NoContent>> UpdateAsync(UpdatePropertyDto updatePropertyDto)
        {
            var values = _mapper.Map<Property>(updatePropertyDto);
            var result = await _propertyCollection.FindOneAndReplaceAsync(x => x.PropertyID == updatePropertyDto.PropertyID, values);
            return Response<NoContent>.Success(200);
        }
    }
}
