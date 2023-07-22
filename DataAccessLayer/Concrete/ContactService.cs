using AutoMapper;
using DataAccessLayer.Abstract;
using DtoLayer.DTOS.BannerDtos;
using DtoLayer.DTOS.ContactDtos;
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
    public class ContactService : IContactService
    {
        private readonly IMongoCollection<Contact> _contactCollection;
        private readonly IMapper _mapper;

        public ContactService(IMapper mapper,IDatabaseSettings databaseSettings)
        {
            _mapper = mapper;
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _contactCollection = database.GetCollection<Contact>(databaseSettings.ContactCollectionName);
        }

        public async Task<Response<NoContent>> CreateAsync(CreateContactDto createContactDto)
        {
            var values = _mapper.Map<Contact>(createContactDto);
            await _contactCollection.InsertOneAsync(values);
            return Response<NoContent>.Success(200);
        }

        public async Task<Response<NoContent>> DeleteAsync(string id)
        {
            await _contactCollection.DeleteOneAsync(x => x.ContactID == id);
            return Response<NoContent>.Success(200);
        }

        public async Task<Response<List<ResultContactDto>>> GetAllAsync()
        {
            var values = await _contactCollection.Find(value => true).ToListAsync();
            return Response<List<ResultContactDto>>.Success(_mapper.Map<List<ResultContactDto>>(values), 200);
        }

        public async Task<Response<ResultContactDto>> GetByIdAsync(string id)
        {
            var value = await _contactCollection.Find<Contact>(x => x.ContactID == id).FirstOrDefaultAsync();
            if (value == null)
            {
                return Response<ResultContactDto>.Fail("İletişim Bilgisi Bulunamadı", 404);

            }

            return Response<ResultContactDto>.Success(_mapper.Map<ResultContactDto>(value), 200);
        }

        public async Task<Response<NoContent>> UpdateAsync(UpdateContactDto updateContactDto)
        {
            var values = _mapper.Map<Contact>(updateContactDto);
            var result = await _contactCollection.FindOneAndReplaceAsync(x => x.ContactID == updateContactDto.ContactID, values);
            return Response<NoContent>.Success(200);
        }
    }
}
