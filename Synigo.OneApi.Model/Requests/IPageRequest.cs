using System.Collections.Generic;

namespace Synigo.OneApi.Model.Requests
{
    public interface IPageRequest
    {
        int PageNumber { get; }
        int PageSize { get; }
        List<string> Sort { get; }
    }
}
