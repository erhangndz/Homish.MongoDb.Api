using AutoMapper;
using DataAccessLayer.Abstract;
using DtoLayer.DTOS.AboutDtos;
using DtoLayer.DTOS.TeamDtos;
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
    public class TeamService : ITeamService
    {
        private readonly IMongoCollection<Team> _teamCollection;
        private readonly IMapper _mapper;

        public TeamService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            _mapper = mapper;
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _teamCollection = database.GetCollection<Team>(databaseSettings.TeamCollectionName);
        }

        public async Task<Response<NoContent>> CreateAsync(CreateTeamDto createTeamDto)
        {
            var values = _mapper.Map<Team>(createTeamDto);
            await _teamCollection.InsertOneAsync(values);
            return Response<NoContent>.Success(200);
        }

        public async Task<Response<NoContent>> DeleteAsync(string id)
        {
            var result = await _teamCollection.DeleteOneAsync(x => x.TeamID == id);
            return Response<NoContent>.Success(200);
        }

        public async Task<Response<List<ResultTeamDto>>> GetAllAsync()
        {
            var values = await _teamCollection.Find(value => true).ToListAsync();
            return Response<List<ResultTeamDto>>.Success(_mapper.Map<List<ResultTeamDto>>(values), 200);
        }

        public async Task<Response<ResultTeamDto>> GetByIdAsync(string id)
        {
            var value = await _teamCollection.Find<Team>(x => x.TeamID == id).FirstOrDefaultAsync();
            if (value == null)
            {
                return Response<ResultTeamDto>.Fail("Ekibimiz Bilgisi Bulunamadı", 404);

            }

            return Response<ResultTeamDto>.Success(_mapper.Map<ResultTeamDto>(value), 200);
        }


        public async Task<Response<NoContent>> UpdateAsync(UpdateTeamDto updateTeamDto)
        {
            var values = _mapper.Map<Team>(updateTeamDto);
            var result = await _teamCollection.FindOneAndReplaceAsync(x => x.TeamID == updateTeamDto.TeamID, values);
            return Response<NoContent>.Success(200);
        }

    }
}
    

