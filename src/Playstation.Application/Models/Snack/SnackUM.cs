namespace Playstation.Application.Models.Snack
{
    public class SnackUM
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
    public class SnackUMResponce : BaseResponceModel { }
}
