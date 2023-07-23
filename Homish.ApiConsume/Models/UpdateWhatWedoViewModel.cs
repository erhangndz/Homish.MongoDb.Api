using DtoLayer.DTOS.ContactDtos;
using DtoLayer.DTOS.WhatWedoDtos;

namespace Homish.ApiConsume.Models
{
    public class UpdateWhatWedoViewModel
    {
        public UpdateWhatWedoDto Data { get; set; }
        public int StatusCode { get; set; }
        public bool IsSuccessful { get; set; }
        public object Errors { get; set; }
    }
}
