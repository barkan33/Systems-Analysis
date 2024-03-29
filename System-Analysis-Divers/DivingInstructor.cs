using System.Text;

namespace Systems_Analysis
{
    public class DivingInstructor : Diver
    {
        private string name;
        private int age;
        private string id;

        public DivingInstructor(string name, int age, string id, DateTime dateOfBirth, string password, string email)
            : base("", "", id, dateOfBirth, password, email)
        {
            SetName(name);
            SetAge(age);
            SetId(id);
        }

        public DivingInstructor(DivingInstructor other)
            : base(other.GetFirstName(), other.GetLastName(), other.GetID(), other.GetDateOfBirth(), other.GetPassword(), other.GetEmail())
        {
            SetName(other.GetName());
            SetAge(other.GetAge());
            SetId(other.GetId());
        }

        public string GetName() { return name; }
        public int GetAge() { return age; }
        public string GetId() { return id; }

        public void SetName(string name) { this.name = name; }
        public void SetAge(int age) { this.age = age; }
        public void SetId(string id) { this.id = id; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Diving Instructor Information");
            sb.Append("Name: ");
            sb.AppendLine(name);
            sb.Append("Age: ");
            sb.AppendLine(age.ToString());
            sb.Append("ID: ");
            sb.AppendLine(id);
            sb.Append('*', 20);
            return sb.ToString();
        }
    }
}