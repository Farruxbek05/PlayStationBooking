namespace Playstation.Application.Models.PlayStationRoomGame;

public class PlayStationRoomGameRM:BaseResponceModel
{
    public Guid PlayStationRoomId { get; set; }
    public Guid GameId { get; set; }
    public decimal PricePerHour { get; set; }
}
