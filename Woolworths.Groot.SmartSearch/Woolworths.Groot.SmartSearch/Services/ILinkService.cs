using Woolworths.Groot.SmartSearch.Model;

namespace Woolworths.Groot.SmartSearch.Services
{
    public interface ILinkService
    {
        Task SaveLinkClickedInfo(LinkClickedInfo info);
        Task UpdateTermHash();
    }
}