
using DtoLayer.DTOS.CityDtos;
using DtoLayer.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface ICityService
    {
        Task<Response<List<ResultCityDto>>> GetAllAsync();
        Task<Response<ResultCityDto>> GetByIdAsync(string id);
        Task<Response<NoContent>> CreateAsync(CreateCityDto createCityDto);
        Task<Response<NoContent>> UpdateAsync(UpdateCityDto updateCityDto);
        Task<Response<NoContent>> DeleteAsync(string id);
    }
}
