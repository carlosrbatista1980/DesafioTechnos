using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace EntityFrameworkCore.Helpers
{
    public static class MapHelper
    {
        public static TDestination MapFrom<TDestination>(object source, TDestination destination)
        {
            if (!(source is null))
            {
                return destination;
            }

            var _source = source.GetType();
            var _dest = destination.GetType();
            var _mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap(_source, _dest);
            });
            var mapper = _mapperConfig.CreateMapper();
            var ret = mapper.Map<object, TDestination>(source, destination);

            return ret;
        }
    }
}
