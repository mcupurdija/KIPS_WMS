using System;
using System.Windows.Forms;
using FileHelpers;
using KIPS_WMS.Data;
using KIPS_WMS.Model;
using KIPS_WMS.Properties;

namespace KIPS_WMS.UI.Ostalo
{
    public partial class CsvImport : Form
    {
        private CsvImportModel[] _csvImports;

        public CsvImport()
        {
            InitializeComponent();
        }

        private void bSelect_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog1.FileName;
                tbFile.Text = fileName;
                lStatus.Text = String.Empty;

                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    var engine = new FileHelperEngine(typeof(CsvImportModel));
                    _csvImports = (CsvImportModel[])engine.ReadFile(fileName);
                }
                catch (Exception ex)
                {
                    lStatus.Text = ex.Message;
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }
            }
        }

        private void bLoad_Click(object sender, EventArgs e)
        {
            if (tbFile.Text.Length == 0)
            {
                MessageBox.Show(Resources.OdaberiteDokument);
                return;
            }

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                SQLiteHelper.nonQuery(DbStatements.DeleteCustomersStatement, new object[] {});
                SQLiteHelper.nonQuery(DbStatements.DeleteItemsStatement, new object[] {});

                int customerCount = 0;
                int itemCount = 0;

                foreach (CsvImportModel import in _csvImports)
                {
                    switch (import.TableNo)
                    {
                        case Utils.CsvImportCustomers:
                            SQLiteHelper.insertQuery(DbStatements.InsertCustomersStatement,
                                new object[] {import.Field1, import.Field2, import.Field4});
                            customerCount++;
                            break;
                        case Utils.CsvImportItems:
                            SQLiteHelper.insertQuery(DbStatements.InsertItemsStatement,
                                new object[] {import.Field1, import.Field2, import.Field3, import.Field4, import.Field5});
                            itemCount++;
                            break;
                    }
                }

                tbFile.Text = String.Empty;
                lStatus.Text =
                    String.Format(Resources.UspesnaSinhronizacija,
                        customerCount, itemCount);
            }
            catch (Exception ex)
            {
                lStatus.Text = ex.Message;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
    }
}