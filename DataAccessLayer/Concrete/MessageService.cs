using AutoMapper;
using DataAccessLayer.Abstract;
using DtoLayer.DTOS.BannerDtos;
using DtoLayer.DTOS.MessageDtos;
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
    public class MessageService : IMessageService
    {
        private readonly IMongoCollection<Message> _messageCollection;
        private readonly IMapper _mapper;

        public MessageService(IMapper mapper,IDatabaseSettings databaseSettings)
        {
            _mapper = mapper;
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database= client.GetDatabase(databaseSettings.DatabaseName);
            _messageCollection = database.GetCollection<Message>(databaseSettings.MessageCollectionName);
        }

        public async Task<Response<NoContent>> CreateAsync(CreateMessageDto createMessageDto)
        {
            var values = _mapper.Map<Message>(createMessageDto);
            await _messageCollection.InsertOneAsync(values);
            return Response<NoContent>.Success(200);
        }

        public async Task<Response<NoContent>> DeleteAsync(string id)
        {
            await _messageCollection.DeleteOneAsync(x => x.MessageID == id);
            return Response<NoContent>.Success(200);
        }

        public async Task<Response<List<ResultMessageDto>>> GetAllAsync()
        {
            var values = await _messageCollection.Find(value => true).ToListAsync();
            return Response<List<ResultMessageDto>>.Success(_mapper.Map<List<ResultMessageDto>>(values), 200);
        }

        public async Task<Response<ResultMessageDto>> GetByIdAsync(string id)
        {
            var value = await _messageCollection.Find<Message>(x => x.MessageID == id).FirstOrDefaultAsync();
            if (value == null)
            {
                return Response<ResultMessageDto>.Fail("Mesaj Bilgisi Bulunamadı", 404);

            }

            return Response<ResultMessageDto>.Success(_mapper.Map<ResultMessageDto>(value), 200);
        }

        public async Task<Response<NoContent>> UpdateAsync(UpdateMessageDto updateMessageDto)
        {
            var values = _mapper.Map<Message>(updateMessageDto);
            var result = await _messageCollection.FindOneAndReplaceAsync(x => x.MessageID == updateMessageDto.MessageID, values);
            return Response<NoContent>.Success(200);
        }
    }
}
