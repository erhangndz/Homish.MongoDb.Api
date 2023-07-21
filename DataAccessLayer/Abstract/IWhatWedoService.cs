
using DtoLayer.DTOS.WhatWedoDtos;
using DtoLayer.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IWhatWedoService
    {
        Task<Response<List<ResultWhatWedoDto>>> GetAllAsync();
        Task<Response<ResultWhatWedoDto>> GetByIdAsync(string id);
        Task<Response<NoContent>> CreateAsync(CreateWhatWedoDto createWhatWedoDto);
        Task<Response<NoContent>> UpdateAsync(UpdateWhatWedoDto updateWhatWedoDto);
        Task<Response<NoContent>> DeleteAsync(string id);
    }
}
