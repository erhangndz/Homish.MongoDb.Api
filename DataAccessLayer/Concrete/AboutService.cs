using AutoMapper;
using DataAccessLayer.Abstract;
using DtoLayer.DTOS.AboutDtos;
using DtoLayer.Shared.Dtos;
using EntityLayer.Concrete;
using EntityLayer.Settings.Abstract;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace DataAccessLayer.Concrete
{
    public class AboutService : IAboutService
    {
        private readonly IMongoCollection<About> _aboutCollection;
        private readonly IMapper _mapper;

        public AboutService(IMapper mapper,IDatabaseSettings databaseSettings)
        {
            _mapper = mapper;
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _aboutCollection= database.GetCollection<About>(databaseSettings.AboutCollectionName);
        }

        public async Task<Response<NoContent>> CreateAsync(CreateAboutDto createAboutDto)
        {
            var values = _mapper.Map<About>(createAboutDto);
            await _aboutCollection.InsertOneAsync(values);
            return Response<NoContent>.Success(200);
        }

        public async Task<Response<NoContent>> DeleteAsync(string id)
        {
            var result = await _aboutCollection.DeleteOneAsync(x => x.AboutID == id);
            return Response<NoContent>.Success(200);
        }

        public async Task<Response<List<ResultAboutDto>>> GetAllAsync()
        {
            var values = await _aboutCollection.Find(value => true).ToListAsync();
            return Response<List<ResultAboutDto>>.Success(_mapper.Map<List<ResultAboutDto>>(values), 200);
        }

        public async Task<Response<ResultAboutDto>> GetByIdAsync(string id)
        {
            var value = await _aboutCollection.Find<About>(x => x.AboutID == id).FirstOrDefaultAsync();
            if (value == null)
            {
                return Response<ResultAboutDto>.Fail("Hakkımızda Bilgisi Bulunamadı", 404);

            }

            return Response<ResultAboutDto>.Success(_mapper.Map<ResultAboutDto>(value), 200);
        }

        public async Task<Response<NoContent>> UpdateAsync(UpdateAboutDto updateAboutDto)
        {
            var values = _mapper.Map<About>(updateAboutDto);
            var result = await _aboutCollection.FindOneAndReplaceAsync(x => x.AboutID == updateAboutDto.AboutID, values);
            return Response<NoContent>.Success(200);
        }
    }
}