using AutoMapper;
using DataAccessLayer.Abstract;
using DtoLayer.DTOS.TestimonialDtos;
using DtoLayer.DTOS.WhatWedoDtos;
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
    public class WhatWedoService : IWhatWedoService
    {
        private readonly IMongoCollection<WhatWedo> _whatWedoCollection;
        private readonly IMapper _mapper;

        public WhatWedoService(IMapper mapper,IDatabaseSettings databaseSettings)
        {
            _mapper = mapper;
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database= client.GetDatabase(databaseSettings.DatabaseName);
            _whatWedoCollection = database.GetCollection<WhatWedo>(databaseSettings.WhatWedoCollectionName);
        }

        public async Task<Response<NoContent>> CreateAsync(CreateWhatWedoDto createWhatWedoDto)
        {
            var values = _mapper.Map<WhatWedo>(createWhatWedoDto);
            await _whatWedoCollection.InsertOneAsync(values);
            return Response<NoContent>.Success(200);
        }

        public async Task<Response<NoContent>> DeleteAsync(string id)
        {
            await _whatWedoCollection.DeleteOneAsync(x => x.WhatwedoID == id);
            return Response<NoContent>.Success(200);
        }

        public async Task<Response<List<ResultWhatWedoDto>>> GetAllAsync()
        {
            var values = await _whatWedoCollection.Find(value => true).ToListAsync();
            return Response<List<ResultWhatWedoDto>>.Success(_mapper.Map<List<ResultWhatWedoDto>>(values), 200);
        }

        public async Task<Response<ResultWhatWedoDto>> GetByIdAsync(string id)
        {
            var value = await _whatWedoCollection.Find(x => x.WhatwedoID == id).FirstOrDefaultAsync();
            if (value == null)
            {
                return Response<ResultWhatWedoDto>.Fail("Yaptıklarımız Bilgisi Bulunamadı", 404);

            }

            return Response<ResultWhatWedoDto>.Success(_mapper.Map<ResultWhatWedoDto>(value), 200);
        }

        public async Task<Response<NoContent>> UpdateAsync(UpdateWhatWedoDto updateWhatWedoDto)
        {
            var values = _mapper.Map<WhatWedo>(updateWhatWedoDto);
            var result = await _whatWedoCollection.FindOneAndReplaceAsync(x => x.WhatwedoID == updateWhatWedoDto.WhatwedoID, values);
            return Response<NoContent>.Success(200);
        }
    }
}
