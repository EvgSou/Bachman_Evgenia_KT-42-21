namespace BachmanEvgeniaKT_42_21.Database.Helpers
{
    public class ColumnType
    {
        public const string Date = "timestamp";
        public const string Guid = "uuid";
        public const string String = "nvarchar(Max)";
        public const string Text = "text";
        public const string Bool = "bit";
        // public const string Bool = "bool";
        public const string Int = "int";
        //public const string Int = "int4";
        public const string Long = "bigint";
        //public const string Long = "int8";
        public const string Decimal = "decimal(18,2)";
        // public const string Decimal = "money";
        public const string Double = "float";
        // public const string Double = "numeric(9,2)";
    }
}
