﻿namespace Playstation.Application.Models.Console
{
    public class PlayStationRoomUM
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Guid LocationId { get; set; }
    }

    public class PlayStationRoomUMResponce : BaseResponceModel { }
}
