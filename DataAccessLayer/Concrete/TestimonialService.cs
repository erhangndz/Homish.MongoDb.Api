using AutoMapper;
using DataAccessLayer.Abstract;
using DtoLayer.DTOS.BannerDtos;
using DtoLayer.DTOS.TestimonialDtos;
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
    public class TestimonialService : ITestimonialService
    {
        private readonly IMongoCollection<Testimonial> _testimonialCollection;
        private readonly IMapper _mapper;

        public TestimonialService(IMapper mapper,IDatabaseSettings databaseSettings)
        {
            _mapper = mapper;
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database= client.GetDatabase(databaseSettings.DatabaseName);
            _testimonialCollection = database.GetCollection<Testimonial>(databaseSettings.TestimonialCollectionName);
        }

        public async Task<Response<NoContent>> CreateAsync(CreateTestimonialDto createTestimonialDto)
        {
            var values = _mapper.Map<Testimonial>(createTestimonialDto);
            await _testimonialCollection.InsertOneAsync(values);
            return Response<NoContent>.Success(200);
        }

        public async Task<Response<NoContent>> DeleteAsync(string id)
        {
            await _testimonialCollection.DeleteOneAsync(x => x.TestimonialID == id);
            return Response<NoContent>.Success(200);
        }

        public async Task<Response<List<ResultTestimonialDto>>> GetAllAsync()
        {
            var values = await _testimonialCollection.Find(value => true).ToListAsync();
            return Response<List<ResultTestimonialDto>>.Success(_mapper.Map<List<ResultTestimonialDto>>(values), 200);
        }

        public async Task<Response<ResultTestimonialDto>> GetByIdAsync(string id)
        {
            var value = await _testimonialCollection.Find(x => x.TestimonialID == id).FirstOrDefaultAsync();
            if (value == null)
            {
                return Response<ResultTestimonialDto>.Fail("Referans Bilgisi Bulunamadı", 404);

            }

            return Response<ResultTestimonialDto>.Success(_mapper.Map<ResultTestimonialDto>(value), 200);
        }

        public async Task<Response<NoContent>> UpdateAsync(UpdateTestimonialDto updateTestimonialDto)
        {
            var values = _mapper.Map<Testimonial>(updateTestimonialDto);
            var result = await _testimonialCollection.FindOneAndReplaceAsync(x => x.TestimonialID == updateTestimonialDto.TestimonialID, values);
            return Response<NoContent>.Success(200);
        }
    }
}
