namespace casman_WEBAPI.Models
{
    public class CreateCaseDto
    {
        public string Surname { get; set; }
        public string FirstName { get; set; }
        public string Initials { get; set; }
        public string Sex { get; set; }
        //public string DefOrg { get; set; }
        public string Role { get; set; }
        public string UserId { get; set; }
    }
}
