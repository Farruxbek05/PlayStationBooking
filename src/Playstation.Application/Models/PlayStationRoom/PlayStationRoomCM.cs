using Playstation.Domain.Entity;

namespace Playstation.Application.Models.Console
{
    public class PlayStationRoomCM
    {
        public string Name { get; set; } = string.Empty;
        public Guid LocationId { get; set; }
    }
    public class PlayStationRoomCMResponce : BaseResponceModel { }
}
