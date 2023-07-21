using DtoLayer.DTOS.ContactDtos;
using DtoLayer.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IContactService
    {
        Task<Response<List<ResultContactDto>>> GetAllAsync();
        Task<Response<ResultContactDto>> GetByIdAsync(string id);
        Task<Response<NoContent>> CreateAsync(CreateContactDto createContactDto);
        Task<Response<NoContent>> UpdateAsync(UpdateContactDto updateContactDto);
        Task<Response<NoContent>> DeleteAsync(string id);
    }
}
