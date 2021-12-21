using System.Collections.Generic;

namespace TKMaster.ProjetoAulaAdilson.Core.WebApi.ViewModels.Responses
{
    public class ResponseFalha
    {
        public bool Success { get; set; }

        public IEnumerable<string> Errors { get; set; }
    }
}
