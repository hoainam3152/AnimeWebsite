namespace AnimeService.Entities
{
    public class Anime
    {
        public int AnimeId { get; set; }
        public string? Title { get; set; }
        public string? AlternateTitle { get; set; }
        public string? CoverImage { get; set; }
        public string? Synopsis { get; set; }
    }
}
