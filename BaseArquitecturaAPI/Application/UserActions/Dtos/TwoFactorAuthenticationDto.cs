
namespace Application.UserActions.Dtos
{
    public class TwoFactorAuthenticationDto
    {
        public int Attempts { get; set; }

        public string Message { get; set; }

        public int Id { get; set; }

        public int UserId { get; set; }

        public string Token { get; set; }

        public bool Validated { get; set; } 
    }
}
