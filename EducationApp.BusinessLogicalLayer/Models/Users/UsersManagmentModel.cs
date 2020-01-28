using static EducationApp.BusinessLogicalLayer.Models.Enum;

namespace EducationApp.BusinessLogicalLayer.Models.Users
{
    public class UsersManagmentModel
    {
        public SortType SortType { get; set; }
        public ApplicationUserSortColumn SortColumn { get; set; }
        public long Start { get; set; }
        public long Count { get; set; }
    }
}
