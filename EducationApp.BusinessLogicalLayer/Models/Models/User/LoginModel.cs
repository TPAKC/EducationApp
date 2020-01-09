using EducationApp.BusinessLogicalLayer.Models.Base;

namespace EducationApp.BusinessLogicalLayer.Models
{
    public class LoginModel : BaseModel
    {
        public long UserId { get; set; }
        public bool Confirmed { get; set; }
        public string Token { get; set; }
    }
}
