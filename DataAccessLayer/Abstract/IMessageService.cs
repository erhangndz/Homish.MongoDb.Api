using DtoLayer.DTOS.MessageDtos;
using DtoLayer.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IMessageService
    {
        Task<Response<List<ResultMessageDto>>> GetAllAsync();
        Task<Response<ResultMessageDto>> GetByIdAsync(string id);
        Task<Response<NoContent>> CreateAsync(CreateMessageDto createMessageDto);
        Task<Response<NoContent>> UpdateAsync(UpdateMessageDto updateMessageDto);
        Task<Response<NoContent>> DeleteAsync(string id);
    }
}
