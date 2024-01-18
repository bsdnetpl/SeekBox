using FluentValidation;

namespace SeekBox.DTOs
{
    public class ClientDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string email { get; set; }
    }
    public class ValidationClientDto :AbstractValidator<ClientDto>
    {
        public ValidationClientDto() 
        {
            RuleFor(x => x.email).NotEmpty().EmailAddress().WithMessage("Wrong address email !");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("You must add the phone number correctly");

        }
    }
}
