namespace Playstation.Application.Models.PlayStationRoomGame;

public class PlayStationRoomGameCM
{
    public Guid PlayStationRoomId { get; set; }
    public Guid GameId { get; set; }
    public decimal PricePerHour { get; set; }
}
public class PlayStationRoomGameCMResponc : BaseResponceModel { }
