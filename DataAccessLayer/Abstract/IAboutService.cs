using DtoLayer.DTOS.AboutDtos;
using DtoLayer.Shared.Dtos;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IAboutService
    {
        Task<Response<List<ResultAboutDto>>> GetAllAsync();
        Task<Response<ResultAboutDto>> GetByIdAsync(string id);
        Task<Response<NoContent>> CreateAsync(CreateAboutDto createAboutDto);
        Task<Response<NoContent>> UpdateAsync(UpdateAboutDto updateAboutDto);
        Task<Response<NoContent>> DeleteAsync(string id);
    }
}
