namespace Playstation.Application.Models.PlayStationRoomGame;

public class PlayStationRoomGameUM
{
    public Guid Id { get; set; }
    public Guid PlayStationRoomId { get; set; }
    public Guid GameId { get; set; }
    public decimal PricePerHour { get; set; }
}
public class PlayStationRoomGameUMResponce : BaseResponceModel { }
