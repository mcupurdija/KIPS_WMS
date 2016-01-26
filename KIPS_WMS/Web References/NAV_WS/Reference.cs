﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.8669
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.CompactFramework.Design.Data, Version 2.0.50727.8669.
// 
namespace KIPS_WMS.NAV_WS {
    using System.Diagnostics;
    using System.Web.Services;
    using System.ComponentModel;
    using System.Web.Services.Protocols;
    using System;
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="KIPS_wms_Binding", Namespace="urn:microsoft-dynamics-schemas/codeunit/KIPS_wms")]
    public partial class KIPS_wms : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        /// <remarks/>
        public KIPS_wms() {
            this.Url = "http://sqlserver:7047/Wurth/ws/Wurth/Codeunit/KIPS_wms";
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:microsoft-dynamics-schemas/codeunit/KIPS_wms:GetQuote", RequestNamespace="urn:microsoft-dynamics-schemas/codeunit/KIPS_wms", ResponseElementName="GetQuote_Result", ResponseNamespace="urn:microsoft-dynamics-schemas/codeunit/KIPS_wms", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void GetQuote(string documentNoP, string userIdP, string locationCodeP, ref string customerCodeP, ref string customerNameP, ref int isAuthenticatedCustomerP, ref string cSVStringP) {
            object[] results = this.Invoke("GetQuote", new object[] {
                        documentNoP,
                        userIdP,
                        locationCodeP,
                        customerCodeP,
                        customerNameP,
                        isAuthenticatedCustomerP,
                        cSVStringP});
            customerCodeP = ((string)(results[0]));
            customerNameP = ((string)(results[1]));
            isAuthenticatedCustomerP = ((int)(results[2]));
            cSVStringP = ((string)(results[3]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetQuote(string documentNoP, string userIdP, string locationCodeP, string customerCodeP, string customerNameP, int isAuthenticatedCustomerP, string cSVStringP, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetQuote", new object[] {
                        documentNoP,
                        userIdP,
                        locationCodeP,
                        customerCodeP,
                        customerNameP,
                        isAuthenticatedCustomerP,
                        cSVStringP}, callback, asyncState);
        }
        
        /// <remarks/>
        public void EndGetQuote(System.IAsyncResult asyncResult, out string customerCodeP, out string customerNameP, out int isAuthenticatedCustomerP, out string cSVStringP) {
            object[] results = this.EndInvoke(asyncResult);
            customerCodeP = ((string)(results[0]));
            customerNameP = ((string)(results[1]));
            isAuthenticatedCustomerP = ((int)(results[2]));
            cSVStringP = ((string)(results[3]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:microsoft-dynamics-schemas/codeunit/KIPS_wms:SendQuote", RequestNamespace="urn:microsoft-dynamics-schemas/codeunit/KIPS_wms", ResponseElementName="SendQuote_Result", ResponseNamespace="urn:microsoft-dynamics-schemas/codeunit/KIPS_wms", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void SendQuote(string userIdP, string locationCodeP, ref string documentNoP, string customerNoP, int isAuthenticatedCustomerP, string cSVStringLinesP, ref int statusP, ref int creditLimitOverdoP) {
            object[] results = this.Invoke("SendQuote", new object[] {
                        userIdP,
                        locationCodeP,
                        documentNoP,
                        customerNoP,
                        isAuthenticatedCustomerP,
                        cSVStringLinesP,
                        statusP,
                        creditLimitOverdoP});
            documentNoP = ((string)(results[0]));
            statusP = ((int)(results[1]));
            creditLimitOverdoP = ((int)(results[2]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginSendQuote(string userIdP, string locationCodeP, string documentNoP, string customerNoP, int isAuthenticatedCustomerP, string cSVStringLinesP, int statusP, int creditLimitOverdoP, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("SendQuote", new object[] {
                        userIdP,
                        locationCodeP,
                        documentNoP,
                        customerNoP,
                        isAuthenticatedCustomerP,
                        cSVStringLinesP,
                        statusP,
                        creditLimitOverdoP}, callback, asyncState);
        }
        
        /// <remarks/>
        public void EndSendQuote(System.IAsyncResult asyncResult, out string documentNoP, out int statusP, out int creditLimitOverdoP) {
            object[] results = this.EndInvoke(asyncResult);
            documentNoP = ((string)(results[0]));
            statusP = ((int)(results[1]));
            creditLimitOverdoP = ((int)(results[2]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:microsoft-dynamics-schemas/codeunit/KIPS_wms:GetCustomerCreditLimit", RequestNamespace="urn:microsoft-dynamics-schemas/codeunit/KIPS_wms", ResponseElementName="GetCustomerCreditLimit_Result", ResponseNamespace="urn:microsoft-dynamics-schemas/codeunit/KIPS_wms", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void GetCustomerCreditLimit(string userIdP, string customerCodeP, ref string creditLimitP, ref string usedCreditLimitP) {
            object[] results = this.Invoke("GetCustomerCreditLimit", new object[] {
                        userIdP,
                        customerCodeP,
                        creditLimitP,
                        usedCreditLimitP});
            creditLimitP = ((string)(results[0]));
            usedCreditLimitP = ((string)(results[1]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetCustomerCreditLimit(string userIdP, string customerCodeP, string creditLimitP, string usedCreditLimitP, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetCustomerCreditLimit", new object[] {
                        userIdP,
                        customerCodeP,
                        creditLimitP,
                        usedCreditLimitP}, callback, asyncState);
        }
        
        /// <remarks/>
        public void EndGetCustomerCreditLimit(System.IAsyncResult asyncResult, out string creditLimitP, out string usedCreditLimitP) {
            object[] results = this.EndInvoke(asyncResult);
            creditLimitP = ((string)(results[0]));
            usedCreditLimitP = ((string)(results[1]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:microsoft-dynamics-schemas/codeunit/KIPS_wms:GetItemInformation", RequestNamespace="urn:microsoft-dynamics-schemas/codeunit/KIPS_wms", ResponseElementName="GetItemInformation_Result", ResponseNamespace="urn:microsoft-dynamics-schemas/codeunit/KIPS_wms", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void GetItemInformation(string itemNoa47BarCodeP, string variantCodeP, string customerNoP, int isAuthenticatedCustomerP, string locationCodeP, string userIdP, ref string cSVStringP) {
            object[] results = this.Invoke("GetItemInformation", new object[] {
                        itemNoa47BarCodeP,
                        variantCodeP,
                        customerNoP,
                        isAuthenticatedCustomerP,
                        locationCodeP,
                        userIdP,
                        cSVStringP});
            cSVStringP = ((string)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetItemInformation(string itemNoa47BarCodeP, string variantCodeP, string customerNoP, int isAuthenticatedCustomerP, string locationCodeP, string userIdP, string cSVStringP, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetItemInformation", new object[] {
                        itemNoa47BarCodeP,
                        variantCodeP,
                        customerNoP,
                        isAuthenticatedCustomerP,
                        locationCodeP,
                        userIdP,
                        cSVStringP}, callback, asyncState);
        }
        
        /// <remarks/>
        public void EndGetItemInformation(System.IAsyncResult asyncResult, out string cSVStringP) {
            object[] results = this.EndInvoke(asyncResult);
            cSVStringP = ((string)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:microsoft-dynamics-schemas/codeunit/KIPS_wms:GetItemPriceAndInventory", RequestNamespace="urn:microsoft-dynamics-schemas/codeunit/KIPS_wms", ResponseElementName="GetItemPriceAndInventory_Result", ResponseNamespace="urn:microsoft-dynamics-schemas/codeunit/KIPS_wms", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void GetItemPriceAndInventory(string itemNoP, string variantCodeP, string unitOfMeasureP, string salesQtyP, string customerNoP, int isAuthenticatedCustomerP, string locationCodeP, string userIdP, ref string cSVStringP) {
            object[] results = this.Invoke("GetItemPriceAndInventory", new object[] {
                        itemNoP,
                        variantCodeP,
                        unitOfMeasureP,
                        salesQtyP,
                        customerNoP,
                        isAuthenticatedCustomerP,
                        locationCodeP,
                        userIdP,
                        cSVStringP});
            cSVStringP = ((string)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetItemPriceAndInventory(string itemNoP, string variantCodeP, string unitOfMeasureP, string salesQtyP, string customerNoP, int isAuthenticatedCustomerP, string locationCodeP, string userIdP, string cSVStringP, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetItemPriceAndInventory", new object[] {
                        itemNoP,
                        variantCodeP,
                        unitOfMeasureP,
                        salesQtyP,
                        customerNoP,
                        isAuthenticatedCustomerP,
                        locationCodeP,
                        userIdP,
                        cSVStringP}, callback, asyncState);
        }
        
        /// <remarks/>
        public void EndGetItemPriceAndInventory(System.IAsyncResult asyncResult, out string cSVStringP) {
            object[] results = this.EndInvoke(asyncResult);
            cSVStringP = ((string)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:microsoft-dynamics-schemas/codeunit/KIPS_wms:GetItemUnitsOfMeasure", RequestNamespace="urn:microsoft-dynamics-schemas/codeunit/KIPS_wms", ResponseElementName="GetItemUnitsOfMeasure_Result", ResponseNamespace="urn:microsoft-dynamics-schemas/codeunit/KIPS_wms", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void GetItemUnitsOfMeasure(string itemNoP, string userIdP, ref string cSVStringP) {
            object[] results = this.Invoke("GetItemUnitsOfMeasure", new object[] {
                        itemNoP,
                        userIdP,
                        cSVStringP});
            cSVStringP = ((string)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetItemUnitsOfMeasure(string itemNoP, string userIdP, string cSVStringP, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetItemUnitsOfMeasure", new object[] {
                        itemNoP,
                        userIdP,
                        cSVStringP}, callback, asyncState);
        }
        
        /// <remarks/>
        public void EndGetItemUnitsOfMeasure(System.IAsyncResult asyncResult, out string cSVStringP) {
            object[] results = this.EndInvoke(asyncResult);
            cSVStringP = ((string)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:microsoft-dynamics-schemas/codeunit/KIPS_wms:GetItemLagerList", RequestNamespace="urn:microsoft-dynamics-schemas/codeunit/KIPS_wms", ResponseElementName="GetItemLagerList_Result", ResponseNamespace="urn:microsoft-dynamics-schemas/codeunit/KIPS_wms", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void GetItemLagerList(string itemNoP, string variantCodeP, string trackingCodeP, string locationCodeP, ref string cSVStringP) {
            object[] results = this.Invoke("GetItemLagerList", new object[] {
                        itemNoP,
                        variantCodeP,
                        trackingCodeP,
                        locationCodeP,
                        cSVStringP});
            cSVStringP = ((string)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetItemLagerList(string itemNoP, string variantCodeP, string trackingCodeP, string locationCodeP, string cSVStringP, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetItemLagerList", new object[] {
                        itemNoP,
                        variantCodeP,
                        trackingCodeP,
                        locationCodeP,
                        cSVStringP}, callback, asyncState);
        }
        
        /// <remarks/>
        public void EndGetItemLagerList(System.IAsyncResult asyncResult, out string cSVStringP) {
            object[] results = this.EndInvoke(asyncResult);
            cSVStringP = ((string)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:microsoft-dynamics-schemas/codeunit/KIPS_wms:GetItems", RequestNamespace="urn:microsoft-dynamics-schemas/codeunit/KIPS_wms", ResponseElementName="GetItems_Result", ResponseNamespace="urn:microsoft-dynamics-schemas/codeunit/KIPS_wms", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void GetItems(ref string cSVStringP, string itemNoP, [System.Xml.Serialization.XmlElementAttribute(DataType="date")] System.DateTime lastDateModifiedP) {
            object[] results = this.Invoke("GetItems", new object[] {
                        cSVStringP,
                        itemNoP,
                        lastDateModifiedP});
            cSVStringP = ((string)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetItems(string cSVStringP, string itemNoP, System.DateTime lastDateModifiedP, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetItems", new object[] {
                        cSVStringP,
                        itemNoP,
                        lastDateModifiedP}, callback, asyncState);
        }
        
        /// <remarks/>
        public void EndGetItems(System.IAsyncResult asyncResult, out string cSVStringP) {
            object[] results = this.EndInvoke(asyncResult);
            cSVStringP = ((string)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:microsoft-dynamics-schemas/codeunit/KIPS_wms:GetCustomers", RequestNamespace="urn:microsoft-dynamics-schemas/codeunit/KIPS_wms", ResponseElementName="GetCustomers_Result", ResponseNamespace="urn:microsoft-dynamics-schemas/codeunit/KIPS_wms", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void GetCustomers(ref string cSVStringP, string customerNoP, [System.Xml.Serialization.XmlElementAttribute(DataType="date")] System.DateTime lastDateModifiedP) {
            object[] results = this.Invoke("GetCustomers", new object[] {
                        cSVStringP,
                        customerNoP,
                        lastDateModifiedP});
            cSVStringP = ((string)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetCustomers(string cSVStringP, string customerNoP, System.DateTime lastDateModifiedP, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetCustomers", new object[] {
                        cSVStringP,
                        customerNoP,
                        lastDateModifiedP}, callback, asyncState);
        }
        
        /// <remarks/>
        public void EndGetCustomers(System.IAsyncResult asyncResult, out string cSVStringP) {
            object[] results = this.EndInvoke(asyncResult);
            cSVStringP = ((string)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:microsoft-dynamics-schemas/codeunit/KIPS_wms:GetWarehouseReceipts", RequestNamespace="urn:microsoft-dynamics-schemas/codeunit/KIPS_wms", ResponseElementName="GetWarehouseReceipts_Result", ResponseNamespace="urn:microsoft-dynamics-schemas/codeunit/KIPS_wms", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void GetWarehouseReceipts(string userIdP, string locationCodeP, string sublocationCodeP, string itemNoP, ref string cSVStringP) {
            object[] results = this.Invoke("GetWarehouseReceipts", new object[] {
                        userIdP,
                        locationCodeP,
                        sublocationCodeP,
                        itemNoP,
                        cSVStringP});
            cSVStringP = ((string)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetWarehouseReceipts(string userIdP, string locationCodeP, string sublocationCodeP, string itemNoP, string cSVStringP, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetWarehouseReceipts", new object[] {
                        userIdP,
                        locationCodeP,
                        sublocationCodeP,
                        itemNoP,
                        cSVStringP}, callback, asyncState);
        }
        
        /// <remarks/>
        public void EndGetWarehouseReceipts(System.IAsyncResult asyncResult, out string cSVStringP) {
            object[] results = this.EndInvoke(asyncResult);
            cSVStringP = ((string)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:microsoft-dynamics-schemas/codeunit/KIPS_wms:GetWarehouseReceiptLines", RequestNamespace="urn:microsoft-dynamics-schemas/codeunit/KIPS_wms", ResponseElementName="GetWarehouseReceiptLines_Result", ResponseNamespace="urn:microsoft-dynamics-schemas/codeunit/KIPS_wms", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void GetWarehouseReceiptLines(string userIdP, string locationCodeP, string sublocationCodeP, string whsReceiptNoP, ref string cSVStringP) {
            object[] results = this.Invoke("GetWarehouseReceiptLines", new object[] {
                        userIdP,
                        locationCodeP,
                        sublocationCodeP,
                        whsReceiptNoP,
                        cSVStringP});
            cSVStringP = ((string)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetWarehouseReceiptLines(string userIdP, string locationCodeP, string sublocationCodeP, string whsReceiptNoP, string cSVStringP, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetWarehouseReceiptLines", new object[] {
                        userIdP,
                        locationCodeP,
                        sublocationCodeP,
                        whsReceiptNoP,
                        cSVStringP}, callback, asyncState);
        }
        
        /// <remarks/>
        public void EndGetWarehouseReceiptLines(System.IAsyncResult asyncResult, out string cSVStringP) {
            object[] results = this.EndInvoke(asyncResult);
            cSVStringP = ((string)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:microsoft-dynamics-schemas/codeunit/KIPS_wms:UpdateWarehouseLineQty", RequestNamespace="urn:microsoft-dynamics-schemas/codeunit/KIPS_wms", ResponseElementName="UpdateWarehouseLineQty_Result", ResponseNamespace="urn:microsoft-dynamics-schemas/codeunit/KIPS_wms", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void UpdateWarehouseLineQty(string userIdP, string whsReceiptNoP, int whsReceiptLineNoP, string qtyP, int isUpdateP, string trackingCSVStringP, string normCSVStringP, string scannedUoMCodeP, string qtyInScannedUoMP) {
            this.Invoke("UpdateWarehouseLineQty", new object[] {
                        userIdP,
                        whsReceiptNoP,
                        whsReceiptLineNoP,
                        qtyP,
                        isUpdateP,
                        trackingCSVStringP,
                        normCSVStringP,
                        scannedUoMCodeP,
                        qtyInScannedUoMP});
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginUpdateWarehouseLineQty(string userIdP, string whsReceiptNoP, int whsReceiptLineNoP, string qtyP, int isUpdateP, string trackingCSVStringP, string normCSVStringP, string scannedUoMCodeP, string qtyInScannedUoMP, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("UpdateWarehouseLineQty", new object[] {
                        userIdP,
                        whsReceiptNoP,
                        whsReceiptLineNoP,
                        qtyP,
                        isUpdateP,
                        trackingCSVStringP,
                        normCSVStringP,
                        scannedUoMCodeP,
                        qtyInScannedUoMP}, callback, asyncState);
        }
        
        /// <remarks/>
        public void EndUpdateWarehouseLineQty(System.IAsyncResult asyncResult) {
            this.EndInvoke(asyncResult);
        }
    }
}
