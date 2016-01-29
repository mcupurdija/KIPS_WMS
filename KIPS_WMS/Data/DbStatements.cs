﻿namespace KIPS_WMS.Data
{
    public static class DbStatements
    {
        public const string DeleteCustomersStatement = "DELETE FROM Customers";
        public const string DeleteItemsStatement = "DELETE FROM Items";

        public const string InsertCustomersStatement = "INSERT INTO Customers (Customer_barcode, Customer_code, Customer_name) VALUES ('{0}', '{1}', '{2}')";
        public const string InsertItemsStatement = "INSERT INTO Items (Item_barcode, Item_code, Item_description, Item_variant, Item_unit_of_measure) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}')";

        public const string FindCustomersStatementBarcode = "SELECT * FROM Customers Where Customer_barcode = '{0}'";
        public const string FindCustomersStatementComplete = "SELECT * FROM Customers Where Customer_barcode = '{0}' OR Customer_code LIKE '%{0}%' OR Customer_name LIKE '%{0}%'";
        public const string FindItemsStatementCode = "SELECT * FROM Items Where Item_code = '{0}'";
        public const string FindItemsStatementBarcode = "SELECT * FROM Items Where Item_barcode = '{0}'";
        public const string FindItemsStatementComplete = "SELECT * FROM Items Where Item_barcode = '{0}' OR Item_code LIKE '%{0}%' OR Item_description LIKE '%{0}%'";
        public const string FindItemBaseUnitOfMeasure = "SELECT Item_unit_of_measure FROM Items Where Item_code = '{0}' AND Item_quantity = 1";

        public const string UpdateCustomersStatement = "UPDATE Customers SET Customer_code='{1}', Customer_name='{2}' WHERE Customer_barcode='{0}'";
        public const string UpdateItemsStatement = "UPDATE Items SET Item_code='{1}', Item_description='{2}', Item_variant='{3}', Item_unit_of_measure='{4}' WHERE Item_barcode='{0}'";

        public const string GetSyncDateCustomers = "SELECT SyncData_customers FROM SyncData";
        public const string GetSyncDateItems = "SELECT SyncData_items FROM SyncData";

    }
}
