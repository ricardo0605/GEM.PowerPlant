using Newtonsoft.Json;
using System.Collections.Generic;

namespace GEM.PowerPlant.Api.Dtos
{
    public class ResponsePayload
    {
        public ResponsePayload()
        {
            Multitudes = new List<ResponseDetail>();
        }

        public IList<ResponseDetail> Multitudes { get; set; }
    }

    public class ResponseDetail
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("p")]
        public float Power { get; set; }
    }
}
