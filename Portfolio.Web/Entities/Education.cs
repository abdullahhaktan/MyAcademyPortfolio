namespace Portfolio.Web.Entities
{
    public class Education
    {
        public int EducationId { get; set; }
        public int SchoolName { get; set; }
        public int Department { get; set; }
        public int StartYear { get; set; }
        public int EndYear { get; set; }
        public string? Description { get; set; }
    }
}
