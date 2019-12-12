using EducationApp.BusinessLogicalLayer.Models.Base;

namespace EducationApp.BusinessLogicalLayer.Models
{
    public class LoginView : BaseModel
    {
        public string UserId { get; set; }
        public bool Confirmed { get; set; }
        public string Token { get; set; }
    }
}
