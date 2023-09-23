namespace Stealer
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    public class Spy
    {
        private StringBuilder sb;

        public Spy()
        {
            sb = new StringBuilder();
        }
        public string StealFieldInfo(string investigatedClassName, params string[] fieldsToInvestigates)
        {
            Type type = Type.GetType(investigatedClassName);
            FieldInfo[] fieldsInfo = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            object objType = Activator.CreateInstance(type);

            sb.AppendLine($"Class under investigation: {type.Name}");

            foreach (FieldInfo field in fieldsInfo.Where(f => fieldsToInvestigates.Contains(f.Name)))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(objType)}");
            }

            return sb.ToString().Trim();
        }
    }
}
