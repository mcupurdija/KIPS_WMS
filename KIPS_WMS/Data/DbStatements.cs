namespace KIPS_WMS.Data
{
    public static class DbStatements
    {
        public const string DeleteCustomersStatement = "DELETE FROM Customers";
        public const string DeleteItemsStatement = "DELETE FROM Items";

        public const string InsertCustomersStatement = "INSERT INTO Customers (Customer_barcode, Customer_code, Customer_name) VALUES ('{0}', '{1}', '{2}')";
        public const string InsertItemsStatement = "INSERT INTO Items (Item_barcode, Item_code, Item_variant, Item_description, Item_unit_of_measure) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}')";

        public const string FindCustomersStatementBarcode = "SELECT * FROM Customers Where Customer_barcode = '{0}'";
        public const string FindCustomersStatementComplete = "SELECT * FROM Customers Where Customer_barcode = '{0}' OR Customer_code LIKE '%{0}%' OR Customer_name LIKE '%{0}%'";
        public const string FindItemsStatementBarcode = "SELECT * FROM Items Where Item_barcode = '{0}'";
        public const string FindItemsStatementComplete = "SELECT * FROM Items Where Item_barcode = '{0}' OR Item_code LIKE '%{0}%' OR Item_description LIKE '%{0}%'";
    }
}
