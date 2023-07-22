
using DtoLayer.DTOS.WhatWedoDtos;
using System.Collections.Generic;

namespace Homish.ApiConsume.Models
{
    public class WhatWedoViewModel
    {
        public List<ResultWhatWedoDto> Data { get; set; }
        public int StatusCode { get; set; }
        public bool IsSuccessful { get; set; }
        public object Errors { get; set; }
    }
}
