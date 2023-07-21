
using DtoLayer.DTOS.TestimonialDtos;
using DtoLayer.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface ITestimonialService
    {
        Task<Response<List<ResultTestimonialDto>>> GetAllAsync();
        Task<Response<ResultTestimonialDto>> GetByIdAsync(string id);
        Task<Response<NoContent>> CreateAsync(CreateTestimonialDto createTestimonialDto);
        Task<Response<NoContent>> UpdateAsync(UpdateTestimonialDto updateTestimonialDto);
        Task<Response<NoContent>> DeleteAsync(string id);
    }
}
