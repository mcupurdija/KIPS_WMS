namespace KIPS_WMS.Model
{
    public static class DatabaseModel
    {
        public static class CustomerDbModel
        {
            public const int CustomerId = 0;
            public const int CustomerBarcode = 1;
            public const int CustomerCode = 2;
            public const int CustomerName = 3;
        }

        public static class ItemDbModel
        {
            public const int ItemId = 0;
            public const int ItemBarcode = 1;
            public const int ItemCode = 2;
            public const int ItemDescription = 3;
            public const int ItemVariant = 4;
            public const int ItemUnitOfMeasure = 5;
        }

        public static class SyncDataDbModel
        {
            public const int SyncDataId = 0;
            public const int CustomersSyncDate = 1;
            public const int ItemsSyncDate = 2;
        }
    }
}