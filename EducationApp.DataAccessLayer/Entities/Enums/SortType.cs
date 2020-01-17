using System.ComponentModel;

namespace EducationApp.DataAccessLayer.Entities.Enums
{
    public partial class Enum
    {
        public enum SortType
        {
            [Description("ASC")]
            Asc = 0,
            [Description("DESC")]
            Desc = 1
        }
    }
}
