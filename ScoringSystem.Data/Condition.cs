namespace ScoringSystem.Data
{
    public class Condition
    {
        public string Column { get; set; }

        public object Value { get; set; }

        public static Condition Create(string column,  object value)
        {
            return new Condition
            {
                Column = column,
                Value = value
            };
        }

        public static Condition IdentityCondition(int id)
        {
            return new Condition
            {
                Column = "Id",
                Value = id
            };
        }
    }
}