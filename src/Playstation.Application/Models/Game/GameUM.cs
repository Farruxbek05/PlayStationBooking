namespace Playstation.Application.Models.Game
{
    public class GameUM
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
    public class GameUMResponce : BaseResponceModel { }
}
