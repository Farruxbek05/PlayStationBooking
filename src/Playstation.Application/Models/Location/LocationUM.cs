﻿namespace Playstation.Application.Models.Location
{
    public class LocationUM
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
    }
    public class LocationUMResponce : BaseResponceModel { }
}
