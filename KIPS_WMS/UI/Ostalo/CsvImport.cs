﻿using System;
using System.Collections.Generic;
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

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);

            DisplayDates();
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
                    var engine = new FileHelperEngine(typeof (CsvImportModel));
                    _csvImports = (CsvImportModel[]) engine.ReadFile(fileName);
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

                int customerCount = 0;
                int itemCount = 0;

                foreach (CsvImportModel import in _csvImports)
                {
                    switch (import.TableNo)
                    {
                        case Utils.CsvImportCustomers:
                            UpsertCustomer(import);
                            customerCount++;
                            break;
                        case Utils.CsvImportItems:
                            UpsertItem(import);
                            itemCount++;
                            break;
                    }
                }

                DateTime today = DateTime.ParseExact(_csvImports[0].Field1, "dd.MM.yyyy.", null);

                SQLiteHelper.nonQuery(DbStatements.UpdateSyncDateCustomers, new object[] {today.ToString("yyyy-MM-dd")});
                SQLiteHelper.nonQuery(DbStatements.UpdateSyncDateItems, new object[] {today.ToString("yyyy-MM-dd")});

                lCustSyncDate.Text = string.Format("Kupci ažurirani: {0}", today.ToString("dd.MM.yyyy."));
                lItemSyncDate.Text = string.Format("Artikli ažurirani: {0}", today.ToString("dd.MM.yyyy."));

                tbFile.Text = String.Empty;
                lStatus.Text =
                    String.Format("Sinhronizacija je uspešno završena.\nUkupno kupaca: {0}\nUkupno artikala: {1}",
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

        private void UpsertCustomer(CsvImportModel customer)
        {
            List<Object> foundCustomer = SQLiteHelper.oneRowQuery(DbStatements.FindCustomersStatementBarcode,
                new object[] {customer.Field1});

            if (foundCustomer.Count > 0)
            {
                SQLiteHelper.nonQuery(DbStatements.UpdateCustomersStatement,
                    new object[] {customer.Field1, customer.Field2, customer.Field4});
            }
            else
            {
                SQLiteHelper.insertQuery(DbStatements.InsertCustomersStatement,
                    new object[] {customer.Field1, customer.Field2, customer.Field4});
            }
        }

        private void UpsertItem(CsvImportModel item)
        {
            List<Object> foundItem = SQLiteHelper.oneRowQuery(DbStatements.FindItemsStatementBarcode,
                new object[] {item.Field1});

            if (foundItem.Count > 0)
            {
                SQLiteHelper.nonQuery(DbStatements.UpdateItemsStatement,
                    new object[]
                    {item.Field1, item.Field2, item.Field4, item.Field3, item.Field5, item.Field6, item.Field7});
            }
            else
            {
                SQLiteHelper.insertQuery(DbStatements.InsertItemsStatement,
                    new object[]
                    {item.Field1, item.Field2, item.Field4, item.Field3, item.Field5, item.Field6, item.Field7});
            }
        }

        private void DisplayDates()
        {
            try
            {
                var customersDateString =
                    (string) SQLiteHelper.simpleQuery(DbStatements.GetSyncDateItems, new object[] {});
                var itemsDateString = (string) SQLiteHelper.simpleQuery(DbStatements.GetSyncDateItems, new object[] {});
                DateTime customersDate = Convert.ToDateTime(customersDateString);
                DateTime itemsDate = Convert.ToDateTime(itemsDateString);

                lCustSyncDate.Text = string.Format("Kupci ažurirani: {0}", customersDate.ToString("dd.MM.yyyy."));
                lItemSyncDate.Text = string.Format("Artikli ažurirani: {0}", itemsDate.ToString("dd.MM.yyyy."));
            }
            catch (Exception)
            {
                lCustSyncDate.Text = string.Empty;
                lItemSyncDate.Text = string.Empty;
            }
        }

        private void toolBar1_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            Close();
        }
    }
}