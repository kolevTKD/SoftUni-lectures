namespace HighQualityMistakes
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

        public string AnalyzeAccessModifiers(string className)
        {
            Type type = Type.GetType($"HighQualityMistakes.{className}");
            FieldInfo[] fieldsInfo = type.GetFields();
            //object objType = Activator.CreateInstance(type);

            foreach (FieldInfo field in fieldsInfo)
            {
                sb.AppendLine($"{field.Name} must be private!");
            }

            MethodInfo[] nonPublicGetters = type.GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic);

            foreach (MethodInfo methodGet in nonPublicGetters.Where(m => m.Name.StartsWith("get")))
            {
                sb.AppendLine($"{methodGet.Name} have to be public!");
            }

            MethodInfo[] publicSetters = type.GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);

            foreach (MethodInfo methodSet in publicSetters.Where(m => m.Name.StartsWith("set")))
            {
                sb.AppendLine($"{methodSet.Name} have to be private!");
            }

            return sb.ToString().Trim();
        }
    }
}
