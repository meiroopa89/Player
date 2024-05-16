namespace dotnetapp.Models
{
    public class Review
    {
        public int reviewId { get; set; }
        public string movieName { get; set; }
        public string movieDirector { get; set; }
        public string leadCast { get; set; }
        public DateTime movieReleaseDate { get; set; }
        public DateTime movieReviewDate { get; set; }
        public string reviewComments { get; set; }
        public int rating { get; set; }
    }
}
