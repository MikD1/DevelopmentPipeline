namespace DemoApp.WebApi.Dto
{
    public class ContactDto
    {
        public string FirstName { get; set; }
        
        public string SecondName { get; set; }

        public string FullName => $"{FirstName} {SecondName}";
        
        public string Phone { get; set; }
    }
}
