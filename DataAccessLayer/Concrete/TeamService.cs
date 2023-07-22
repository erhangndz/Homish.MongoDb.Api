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

        public TeamService(IMapper mapper,IDatabaseSettings databaseSettings)
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

        public Task<Response<List<ResultTeamDto>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Response<ResultTeamDto>> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Response<NoContent>> UpdateAsync(UpdateTeamDto updateTeamDto)
        {
            throw new NotImplementedException();
        }
    }
}
