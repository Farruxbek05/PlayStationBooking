using Playstation.Domain.Entity;

namespace Playstation.Application.Models.Console
{
    public class PlayStationRoomRM:BaseResponceModel
    {
        public string Name { get; set; } = string.Empty;
        public Guid LocationId { get; set; }
    }
}
