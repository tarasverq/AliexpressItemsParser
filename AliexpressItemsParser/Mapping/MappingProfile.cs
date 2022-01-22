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
            
            //fix ali's "storeUrl": "//www.aliexpress.ru/store/5085293", without scheme
            .Map(x => x.StoreUrl, src => "https:" + src.StoreUrl)
            
            //These fields will be filled manually after map
            .Ignore(x => x.Reviews)
            .Ignore(x => x.ItemUrl)
            ;
    }
}