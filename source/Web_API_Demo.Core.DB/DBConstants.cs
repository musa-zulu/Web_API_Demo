namespace Web_API_Demo.DB
{
    public class DBConstants
    {
        public class Tables
        {
            public class ProductTable
            {
                public const string TableName = "Product";
                public class Columns
                {
                    public const string Id = "Id";
                    public const string Name = "Name";
                    public const string Type = "Type";
                    public const string Description = "Description";
                    public const string Price = "Price";
                }
            }
        }
    }
}
