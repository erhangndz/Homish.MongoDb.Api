using AutoMapper;
using DataAccessLayer.Abstract;
using DtoLayer.DTOS.AboutDtos;
using DtoLayer.DTOS.BannerDtos;
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
    public class BannerService : IBannerService
    {
        private readonly IMongoCollection<Banner> _bannerCollection;
        private readonly IMapper _mapper;

        public BannerService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            _mapper = mapper;
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _bannerCollection = database.GetCollection<Banner>(databaseSettings.BannerCollectionName);
        }

        public async Task<Response<NoContent>> CreateAsync(CreateBannerDto createBannerDto)
        {
            var values= _mapper.Map<Banner>(createBannerDto);
            await _bannerCollection.InsertOneAsync(values);
            return Response<NoContent>.Success(200);

        }

        public async Task<Response<NoContent>> DeleteAsync(string id)
        {
           await _bannerCollection.DeleteOneAsync(x=>x.BannerID==id);
            return Response<NoContent>.Success(200);
        }

        public async Task<Response<List<ResultBannerDto>>> GetAllAsync()
        {
           var values= await _bannerCollection.Find(value=>true).ToListAsync();
            return Response<List<ResultBannerDto>>.Success(_mapper.Map<List<ResultBannerDto>>(values), 200);
        }

        public async Task<Response<ResultBannerDto>> GetByIdAsync(string id)
        {
            var value = await _bannerCollection.Find<Banner>(x => x.BannerID == id).FirstOrDefaultAsync();
            if (value == null)
            {
                return Response<ResultBannerDto>.Fail("Öne Çıkan Bilgisi Bulunamadı", 404);

            }

            return Response<ResultBannerDto>.Success(_mapper.Map<ResultBannerDto>(value), 200);
        }

        public async Task<Response<NoContent>> UpdateAsync(UpdateBannerDto updateBannerDto)
        {
            var values = _mapper.Map<Banner>(updateBannerDto);
            var result = await _bannerCollection.FindOneAndReplaceAsync(x => x.BannerID == updateBannerDto.BannerID, values);
            return Response<NoContent>.Success(200);
        }
    }
}
