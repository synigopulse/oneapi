using System.Collections.Generic;

namespace Synigo.OneApi.Model.Requests
{
    public interface IPageRequest
    {
        int Index { get; }
        int Size { get; }
        List<string> OrderBy { get; }
    }
}
