using System.Threading.Tasks;
using AliexpressItemsParser.Out;

namespace AliexpressItemsParser.Interfaces;

public interface IAliParser
{
    Task<AliexpressItem> Parse(string itemId);
}