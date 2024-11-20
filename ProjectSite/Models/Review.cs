namespace ProjectSite.Models
{
    public class Review
    {
        public int id { get; set; }
        public int id_restaurant { get; set; }
        public int id_user { get; set; }
        public int service_assessment { get; set; }
        public int evaluation_of_the_first_courses { get; set; }
        public int evaluation_of_the_second_courses { get; set; }
        public int evaluation_of_snacks { get; set; }
        public int dessert_evaluation { get; set; }
        public int assessment_of_the_atmosphere { get; set; }
        public string? total_review { get; set; }

    }
}
