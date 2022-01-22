using AliexpressItemsParser.Out;
using Mapster;

namespace AliexpressItemsParser.Mapping;

internal class MappingProfile : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Props.Props, AliexpressItem>()
            .Map(x => x.Rating, src => src.Rating.Middle)
            .Map(x => x.ReviewsCount, src => src.Reviews)
            .Ignore(x => x.Reviews)
            ;
    }
}