namespace KIPS_WMS.Data
{
    public static class DbStatements
    {
        public const string DeleteCustomersStatement = "DELETE FROM Customers";
        public const string DeleteItemsStatement = "DELETE FROM Items";

        public const string InsertCustomersStatement = "INSERT INTO Customers (Customer_barcode, Customer_code, Customer_name) VALUES ('{0}', '{1}', '{2}')";
        public const string InsertItemsStatement = "INSERT INTO Items (Item_barcode, Item_code, Item_variant, Item_description, Item_unit_of_measure) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}')";
    }
}
