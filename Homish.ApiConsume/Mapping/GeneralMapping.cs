using AutoMapper;
using DtoLayer.DTOS.AboutDtos;
using DtoLayer.DTOS.BannerDtos;
using DtoLayer.DTOS.CityDtos;
using DtoLayer.DTOS.ContactDtos;
using DtoLayer.DTOS.MessageDtos;
using DtoLayer.DTOS.PropertyDtos;
using DtoLayer.DTOS.ServiceBannerDtos;
using DtoLayer.DTOS.ServiceWedoDtos;
using DtoLayer.DTOS.SubscribeDtos;
using DtoLayer.DTOS.TeamDtos;
using DtoLayer.DTOS.TestimonialDtos;
using DtoLayer.DTOS.VideoDtos;
using DtoLayer.DTOS.WhatWedoDtos;
using DtoLayer.DTOS.WhyusDtos;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace Homish.ApiConsume.Mapping
{
    public class GeneralMapping:Profile
    {
        public GeneralMapping()
        {
            CreateMap<About, ResultAboutDto>().ReverseMap();
            CreateMap<About, UpdateAboutDto>().ReverseMap();
            CreateMap<About, CreateAboutDto>().ReverseMap();

            CreateMap<Banner, CreateBannerDto>().ReverseMap();
            CreateMap<Banner, UpdateBannerDto>().ReverseMap();
            CreateMap<Banner, ResultBannerDto>().ReverseMap();

            CreateMap<City, ResultCityDto>().ReverseMap();
            CreateMap<City, UpdateCityDto>().ReverseMap();
            CreateMap<City, CreateCityDto>().ReverseMap();

            CreateMap<Contact, ResultContactDto>().ReverseMap();
            CreateMap<Contact, UpdateContactDto>().ReverseMap();
            CreateMap<Contact, CreateContactDto>().ReverseMap();

            CreateMap<Message, ResultMessageDto>().ReverseMap();
            CreateMap<Message, UpdateMessageDto>().ReverseMap();
            CreateMap<Message, CreateMessageDto>().ReverseMap();

            CreateMap<Property, ResultPropertyDto>().ReverseMap();
            CreateMap<Property, UpdatePropertyDto>().ReverseMap();
            CreateMap<Property, CreatePropertyDto>().ReverseMap();

            CreateMap<ServiceBanner, ResultServiceBannerDto>().ReverseMap();
            CreateMap<ServiceBanner, UpdateServiceBannerDto>().ReverseMap();
            CreateMap<ServiceBanner, CreateServiceBannerDto>().ReverseMap();

            CreateMap<ServiceWedo, ResultServiceWedoDto>().ReverseMap();
            CreateMap<ServiceWedo, UpdateServiceWedoDto>().ReverseMap();
            CreateMap<ServiceWedo, CreateServiceWedoDto>().ReverseMap();

            CreateMap<Subscribe, ResultSubscribeDto>().ReverseMap();
            CreateMap<Subscribe, UpdateSubscribeDto>().ReverseMap();
            CreateMap<Subscribe, CreateSubscribeDto>().ReverseMap();

            CreateMap<Team, ResultTeamDto>().ReverseMap();
            CreateMap<Team, UpdateTeamDto>().ReverseMap();
            CreateMap<Team, CreateTeamDto>().ReverseMap();

            CreateMap<Testimonial, ResultTestimonialDto>().ReverseMap();
            CreateMap<Testimonial, UpdateTestimonialDto>().ReverseMap();
            CreateMap<Testimonial, CreateTestimonialDto>().ReverseMap();

            CreateMap<Video, ResultVideoDto>().ReverseMap();
            CreateMap<Video, UpdateVideoDto>().ReverseMap();
            CreateMap<Video, CreateVideoDto>().ReverseMap();

            CreateMap<WhatWedo, ResultWhatWedoDto>().ReverseMap();
            CreateMap<WhatWedo, UpdateWhatWedoDto>().ReverseMap();
            CreateMap<WhatWedo, CreateWhatWedoDto>().ReverseMap();

            CreateMap<Whyus, ResultWhyusDto>().ReverseMap();
            CreateMap<Whyus, UpdateWhyusDto>().ReverseMap();
            CreateMap<Whyus, CreateWhyusDto>().ReverseMap();
        }

    }
}
