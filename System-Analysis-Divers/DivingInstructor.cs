using System.Text;

namespace Systems_Analysis
{
    public class DivingInstructor : Diver
    {
        private int age;

        public DivingInstructor(string firstName, string lastName, int age, string id, DateTime dateOfBirth, string password, string email)
            : base(firstName, lastName, id, dateOfBirth, password, email)
        {
            SetAge(age);
        }

        public DivingInstructor(DivingInstructor other)
            : base(other.GetFirstName(), other.GetLastName(), other.GetID(), other.GetDateOfBirth(), other.GetPassword(), other.GetEmail())
        {
            SetAge(other.GetAge());
        }

        public int GetAge() { return age; }

        public void SetAge(int age) { this.age = age; }

        public string GetName() { return FirstName + " " + LastName; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Diving Instructor Information");
            sb.Append("Name: ");
            sb.AppendLine(GetName());
            sb.Append("Age: ");
            sb.AppendLine(age.ToString());
            sb.Append("ID: ");
            sb.AppendLine(Id);
            sb.Append('*', 20);
            return sb.ToString();
        }
    }
}