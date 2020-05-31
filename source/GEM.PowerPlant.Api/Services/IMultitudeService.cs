using GEM.PowerPlant.Api.Dtos;
using System.Collections.Generic;

namespace GEM.PowerPlant.Api.Services
{
    public interface IMultitudeService
    {
        IEnumerable<ResponseDetail> SolveUnitCommitment(RequestPayload payload);
    }
}
