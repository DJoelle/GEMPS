using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GEMPS.BO;

namespace GEMPS.Setting
{
    [Serializable]
    public class SchoolPreferences : SystemStoredObject
    {
        public string SchoolId { get; set; }
        public string PasswordStandartPart { get; set; }
        public string PasswordVariablePart { get; set; }

        public SchoolPreferences() : base()
        {

        }

        public SchoolPreferences(string id, string schoolId, string passwordStandartPart, string passwordVariablePart) : base(id)
        {
            SchoolId = schoolId;
            PasswordStandartPart = passwordStandartPart;
            PasswordVariablePart = passwordVariablePart;
        }

        public SchoolPreferences(SchoolPreferences schoolPreferences) : base(schoolPreferences.Id)
        {
            SchoolId = schoolPreferences.SchoolId;
            PasswordStandartPart = schoolPreferences.PasswordStandartPart;
            PasswordVariablePart = schoolPreferences.PasswordVariablePart;
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return this.Id.Equals((obj as SchoolPreferences)?.Id, StringComparison.OrdinalIgnoreCase);
        }

        public override string ToString()
        {
            return this.Id;
        }
    }
}
