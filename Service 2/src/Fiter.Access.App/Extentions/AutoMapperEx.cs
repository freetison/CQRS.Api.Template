using AutoMapper;

namespace Application.Extentions
{
    public static class AutoMapperEx
    {
        public static TDestination Map<TSource1, TSource2, TDestination>(this IMapper mapper, TSource1 source1, TSource2 source2)
        {
            var destination = mapper.Map<TSource1, TDestination>(source1);
            return mapper.Map(source2, destination);
        }

        public static TDestination Map<TSource1, TSource2, TSource3, TDestination>(this IMapper mapper, TSource1 source1, TSource2 source2, TSource3 source3)
        {
            var destination = mapper.Map<TSource1, TDestination>(source1);
            var destination2 = mapper.Map<TSource2, TDestination>(source2);
            return mapper.Map(source3, destination2);
        }
    }
}