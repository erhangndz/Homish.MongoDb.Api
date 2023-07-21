using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Settings.Abstract
{
    public interface IDatabaseSettings
    {
        public string BannerCollectionName { get; set; }
        public string AboutCollectionName { get; set; }
        public string WhatWedoCollectionName { get; set; }
        public string CityCollectionName { get; set; }
        public string TestimonialCollectionName { get; set; }
        public string VideoCollectionName { get; set; }
        public string WhyusCollectionName { get; set; }
        public string TeamCollectionName { get; set; }
        public string ServiceBannerCollectionName { get; set; }
        public string ServiceWedoCollectionName { get; set; }
        public string PropertyCollectionName { get; set; }
        public string ContactCollectionName { get; set; }
        public string MessageCollectionName { get; set; }
        public string SubscribeCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
