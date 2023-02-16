using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinqEFProject
{
    public partial class Form1 : Form
    {
        EFModel DB = new EFModel();
        private object textBoxSupplierMoblie;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //add clients ID in ComboBox
            foreach (var client in DB.Clients)
            {
                comboBoxClientIDs.Items.Add(client.ClientId.ToString());
                comboBoxRequestByClients.Items.Add(client.ClientName);
            }
            //add Suppliers ID in ComboBox
            foreach (var supplier in DB.Suppliers)
            {
                comboBoxSupplierIDs.Items.Add(supplier.SupplierId.ToString());
                comboBoxSupplierNames.Items.Add(supplier.SupplierName);
            }
            //add Items Code in ComboBox
            foreach (var item in DB.Items)
            {
                comboBoxItemCodes.Items.Add(item.ItemCode.ToString());
                comboBoxRequestSelectNewItem.Items.Add(item.ItemName);
                comboBoxMovedItems.Items.Add(item.ItemName);
                comboBoxItemsReports.Items.Add(item.ItemName);
            }
            //add Store Ids in ComboBox
            foreach (var item in DB.Stores)
            {
                comboBoxStoreIDs.Items.Add(item.StoreId.ToString());
                comboBoxSupplyStoreNames.Items.Add(item.StoreName);
                comboBoxRequestToStores.Items.Add(item.StoreName);
                comboBoxMovedStores.Items.Add(item.StoreName);
                comboBoxStoreReports.Items.Add(item.StoreName);
            }
            //add SupplyPermission Ids in ComboBox
            foreach (var item in DB.ImportPermissions)
            {
                comboBoxSupplyPermissionIDs.Items.Add(item.ImportNum.ToString());
            }
            //add RequestPermission Ids in ComboBox
            foreach (var item in DB.RequestPermissions)
            {
                comboBoxRequestPermissionIDs.Items.Add(item.RequestNum.ToString());
            }
        }

        #region Client TabPage
        private void comboBoxClientIDs_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedItem=int.Parse(comboBoxClientIDs.Text);
            Client c = DB.Clients.FirstOrDefault(a => a.ClientId == selectedItem);
            if (c != null)
            {
                textBoxClientId.Text = c.ClientId.ToString();
                textBoxClientName.Text = c.ClientName;
                textBoxClientMobile.Text = c.ClientMobile;
                textBoxClientFax.Text = c.ClientFax;
                textBoxClientMail.Text = c.ClientMail;
                textBoxClientWebSite.Text = c.ClientWebsite;
            }
            else
            {
                MessageBox.Show("Client Not Found...!");
            }
        }

        private void btnUpdateClient_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxClientName.Text != "" && textBoxClientMobile.Text != "" && textBoxClientFax.Text != "" && textBoxClientMail.Text != "" && textBoxClientWebSite.Text != "" && comboBoxClientIDs.Text != "")
                {
                    int selectedItem = int.Parse(comboBoxClientIDs.Text);
                    Client c = DB.Clients.FirstOrDefault(a => a.ClientId == selectedItem);
                    if (c != null)
                    {
                        //textBoxClientId.Text = c.ClientId.ToString();
                        c.ClientName = textBoxClientName.Text;
                        c.ClientMobile = textBoxClientMobile.Text;
                        c.ClientFax = textBoxClientFax.Text;
                        c.ClientMail = textBoxClientMail.Text;
                        c.ClientWebsite = textBoxClientWebSite.Text;
                        MessageBox.Show("Client Updated");
                        DB.SaveChanges();
                        comboBoxClientIDs.Text = textBoxClientName.Text = textBoxClientMobile.Text = textBoxClientFax.Text = textBoxClientMail.Text = textBoxClientWebSite.Text = textBoxClientId.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Client Not Found...!");
                    }
                }
                else
                {
                    MessageBox.Show("Please Fill All Data");
                }
            }
            catch
            {
                MessageBox.Show("InValid Data");
            }
            
        }

        private void btnAddClient_Click(object sender, EventArgs e)
        {
            try
            {
                Client c1 = new Client();
                if (textBoxClientName.Text != "" && textBoxClientMobile.Text != "" && textBoxClientFax.Text != "" && textBoxClientMail.Text != "" && textBoxClientWebSite.Text != "" && textBoxNewClientId.Text != "")
                {
                    int InsertedId = int.Parse(textBoxNewClientId.Text);
                    Client c = DB.Clients.FirstOrDefault(a => a.ClientId == InsertedId);
                    if (c == null)
                    {
                        c1.ClientId = int.Parse(textBoxNewClientId.Text);
                        c1.ClientName = textBoxClientName.Text;
                        c1.ClientMobile = textBoxClientMobile.Text;
                        c1.ClientFax = textBoxClientFax.Text;
                        c1.ClientMail = textBoxClientMail.Text;
                        c1.ClientWebsite = textBoxClientWebSite.Text;
                        MessageBox.Show("Client Added");
                        textBoxNewClientId.Text = comboBoxClientIDs.Text = textBoxClientName.Text = textBoxClientMobile.Text = textBoxClientFax.Text = textBoxClientMail.Text = textBoxClientWebSite.Text = textBoxClientId.Text = "";
                        DB.Clients.Add(c1);
                        DB.SaveChanges();
                        comboBoxClientIDs.Items.Add(c1.ClientId);
                    }
                    else
                    {
                        MessageBox.Show("Invalid ID...!");
                    }
                }
                else
                {
                    MessageBox.Show("Please Fill All Data");
                }
            }
            catch
            {
                MessageBox.Show("InValid Data");
            }
            
        }


        #endregion

        #region Supplier TabPage
        

        private void comboBoxSupplierIDs_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedItem = int.Parse(comboBoxSupplierIDs.Text);
            Supplier s = DB.Suppliers.FirstOrDefault(a => a.SupplierId == selectedItem);
            if (s != null)
            {
                textBoxSupplierId.Text = s.SupplierId.ToString();
                textBoxSupplierName.Text = s.SupplierName;
                textBoxSupplierMobile.Text = s.SupplierMoblie;
                textBoxSupplierFax.Text = s.SupplierFax;
                textBoxSupplierMail.Text = s.SupplierMail;
                textBoxSupplierWebSite.Text = s.SupplierWebsite;
            }
            else
            {
                MessageBox.Show("Supplier Not Found...!");
            }
        }

        private void btnUpdateSupplier_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxSupplierName.Text != "" && textBoxSupplierMobile.Text != "" && textBoxSupplierFax.Text != "" && textBoxSupplierMail.Text != "" && textBoxSupplierWebSite.Text != "" && comboBoxSupplierIDs.Text != "")
                {
                    int selectedItem = int.Parse(comboBoxSupplierIDs.Text);
                    Supplier s = DB.Suppliers.FirstOrDefault(a => a.SupplierId == selectedItem);
                    if (s != null)
                    {
                        s.SupplierName = textBoxSupplierName.Text;
                        s.SupplierMoblie = textBoxSupplierMobile.Text;
                        s.SupplierFax = textBoxSupplierFax.Text;
                        s.SupplierMail = textBoxSupplierMail.Text;
                        s.SupplierWebsite = textBoxSupplierWebSite.Text;
                        MessageBox.Show("Supplier Updated");
                        DB.SaveChanges();
                        comboBoxSupplierIDs.Text = textBoxSupplierName.Text = textBoxSupplierMobile.Text = textBoxSupplierFax.Text = textBoxSupplierMail.Text = textBoxSupplierWebSite.Text = textBoxSupplierId.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Supplier Not Found...!");
                    }
                }
                else
                {
                    MessageBox.Show("Please Fill All Data");
                }
            }
            catch
            {
                MessageBox.Show("InValid Data");
            }
        }

        private void btnAddSupplier_Click(object sender, EventArgs e)
        {
            try
            {
                Supplier s1 = new Supplier();
                if (textBoxSupplierName.Text != "" && textBoxSupplierMobile.Text != "" && textBoxSupplierFax.Text != "" && textBoxSupplierMail.Text != "" && textBoxSupplierWebSite.Text != "" && textBoxNewSupplierId.Text != "")
                {
                    int InsertedId = int.Parse(textBoxNewSupplierId.Text);
                    Supplier s = DB.Suppliers.FirstOrDefault(a => a.SupplierId == InsertedId);
                    if (s == null)
                    {
                        s1.SupplierId = int.Parse(textBoxNewSupplierId.Text);
                        s1.SupplierName = textBoxSupplierName.Text;
                        s1.SupplierMoblie = textBoxSupplierMobile.Text;
                        s1.SupplierFax = textBoxSupplierFax.Text;
                        s1.SupplierMail = textBoxSupplierMail.Text;
                        s1.SupplierWebsite = textBoxSupplierWebSite.Text;
                        MessageBox.Show("Supplier Added");
                        textBoxNewSupplierId.Text = comboBoxSupplierIDs.Text = textBoxSupplierName.Text = textBoxSupplierMobile.Text = textBoxSupplierFax.Text = textBoxSupplierMail.Text = textBoxSupplierWebSite.Text = textBoxSupplierId.Text = "";
                        DB.Suppliers.Add(s1);
                        DB.SaveChanges();
                        comboBoxSupplierIDs.Items.Add(s1.SupplierId);
                    }
                    else
                    {
                        MessageBox.Show("Invalid ID...!");
                    }
                }
                else
                {
                    MessageBox.Show("Please Fill All Data");
                }
            }
            catch
            {
                MessageBox.Show("InValid Data");
            }
        }
        #endregion

        #region Item TabPage
        private void comboBoxItemCodes_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxItemUnits.Items.Clear();
            int selectedCode = int.Parse(comboBoxItemCodes.Text);
            Item i = DB.Items.FirstOrDefault(a => a.ItemCode == selectedCode);
            textBoxItemCode.Text = i.ItemCode.ToString();
            textBoxItemName.Text = i.ItemName;
            foreach (var item in i.ItemUnits)
            {
                comboBoxItemUnits.Items.Add(item.Unit);
            }
        }

        private void btnUpdateItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxItemCode.Text != "" && textBoxItemName.Text != "")
                {
                    int selectedCode = int.Parse(comboBoxItemCodes.Text);
                    Item i = DB.Items.FirstOrDefault(a => a.ItemCode == selectedCode);
                    i.ItemName = textBoxItemName.Text;
                    ItemUnit IU = new ItemUnit();
                    foreach (var u in comboBoxItemUnits.Items)
                    {
                        IU.Unit = u.ToString();
                        i.ItemUnits.Add(IU);
                    }
                    DB.SaveChanges();
                    MessageBox.Show("Item Updated");
                }
                else
                {
                    MessageBox.Show("Please Fill Data");
                }
            }
            catch
            {
                MessageBox.Show("InValid Data");
            }
            
            
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxNewItemCode.Text != "" && textBoxItemName.Text != "")
                {
                    int InserttedCode = int.Parse(textBoxNewItemCode.Text);
                    Item i = DB.Items.FirstOrDefault(a => a.ItemCode == InserttedCode);
                    if (i == null)
                    {
                        Item newItem = new Item();
                        newItem.ItemName = textBoxItemName.Text;
                        newItem.ItemCode = int.Parse(textBoxNewItemCode.Text);
                        ItemUnit IU = new ItemUnit();
                        foreach (var u in comboBoxItemUnits.Items)
                        {
                            IU.Unit = u.ToString();
                            newItem.ItemUnits.Add(IU);
                        }
                        DB.Items.Add(newItem);
                        DB.SaveChanges();
                        MessageBox.Show("Item Added");
                    }
                    else
                    {
                        MessageBox.Show("Code Not Valid");
                    }
                }
                else
                {
                    MessageBox.Show("Please Fill Data");
                }
            }
            catch
            {
                MessageBox.Show("inValid Data");
            }
            
        }
        private void comboBoxItemUnits_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxItemUnits.Items.Remove(comboBoxItemUnits.SelectedItem);
        }

        private void btnAddNewItemUnit_Click(object sender, EventArgs e)
        {
            comboBoxItemUnits.Items.Add(textBoxNewItemUnit.Text);
            textBoxNewItemUnit.Text = "";
        }

        #endregion

        #region Store TabPage
        private void comboBoxStoreIDs_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedId =int.Parse(comboBoxStoreIDs.Text);
            Store S = DB.Stores.FirstOrDefault(a => a.StoreId == selectedId);
            textBoxStoreId.Text = S.StoreId.ToString();
            textBoxStoreName.Text = S.StoreName;
            textBoxStoreAddress.Text = S.StoreAddress;
            textBoxStoreManager.Text = S.Manager;
        }

        private void btnUpdateStore_Click(object sender, EventArgs e)
        {
            try
            {
                Store S = new Store();
                if (textBoxStoreName.Text != "" && textBoxStoreAddress.Text != "" && textBoxStoreManager.Text != "" && comboBoxStoreIDs.Text != "")
                {
                    int selectedId = int.Parse(comboBoxStoreIDs.Text);
                    S = DB.Stores.FirstOrDefault(a => a.StoreId == selectedId);
                    S.StoreName = textBoxStoreName.Text;
                    S.Manager = textBoxStoreManager.Text;
                    S.StoreAddress = textBoxStoreAddress.Text;
                    DB.SaveChanges();
                    MessageBox.Show("Store Updated");
                    textBoxStoreId.Text=textBoxStoreName.Text =  textBoxStoreAddress.Text = textBoxStoreManager.Text = comboBoxStoreIDs.Text = "";
                }
                else
                {
                    MessageBox.Show("Please Fill Data");
                }
            }
            catch
            {
                MessageBox.Show("InValid Data");
            }
            
        }

        private void btnAddStore_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxStoreName.Text != "" && textBoxStoreAddress.Text != "" && textBoxStoreManager.Text != "" && textBoxNewStoreId.Text != "")
                {
                    int insertedId = int.Parse(textBoxNewStoreId.Text);
                    Store s = DB.Stores.FirstOrDefault(a => a.StoreId == insertedId);
                    if (s == null)
                    {
                        Store S = new Store();
                        S.StoreId = int.Parse(textBoxNewStoreId.Text);
                        S.StoreName = textBoxStoreName.Text;
                        S.Manager = textBoxStoreManager.Text;
                        S.StoreAddress = textBoxStoreAddress.Text;
                        comboBoxStoreIDs.Items.Add(textBoxNewStoreId.Text);
                        DB.Stores.Add(S);
                        DB.SaveChanges();
                        MessageBox.Show("Store Added");
                        textBoxStoreId.Text=textBoxStoreName.Text = textBoxStoreAddress.Text = textBoxStoreManager.Text = comboBoxStoreIDs.Text = textBoxNewStoreId.Text="";

                    }
                    else
                    {
                        MessageBox.Show("Invalid Id...!");
                    }
                }
                else
                {
                    MessageBox.Show("Please Fill Data");
                }
            }
            catch
            {
                MessageBox.Show("InValid Data");
            }
        }
        #endregion

        #region Supply Permission TabPage

        //note : by mistake I give wrong name to table "Supply Permission" in Database
        //the name that i gaven is "Import Permission"
        private void comboBoxSupplyPermissionIDs_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedID = int.Parse(comboBoxSupplyPermissionIDs.Text);
            ImportPermission IP=DB.ImportPermissions.FirstOrDefault(a=>a.ImportNum== selectedID);
            textBoxPermissionNum.Text = IP.ImportNum.ToString();
            textBoxSupplySupplierName.Text = IP.Supplier.SupplierName;
            textBoxSupplyStoreName.Text = IP.Store.StoreName;
            textBoxSupplyDate.Text = IP.ImportDate.ToString();
            Item i;
            foreach (var item in IP.ImportItems)
            {
                i = DB.Items.FirstOrDefault(a => a.ItemCode == item.ItemCode);
                comboBoxSupplyItemsInfo.Text = "item name: " + i.ItemName + " ,item quantity: " + item.Quantity.ToString() + " ,item Expire Date: " + item.ExpireDate.ToString() + " ,item production Date: " + item.ProductionDate.ToString();
                comboBoxSupplyItemsInfo.Items.Add("item name: "+i.ItemName+" ,item quantity: "+item.Quantity.ToString()+" ,item Expire Date: "+item.ExpireDate.ToString()+" ,item production Date: "+item.ProductionDate.ToString());
            }
        }

        private void btnUpdatePermission_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedID = int.Parse(comboBoxSupplyPermissionIDs.Text);
                if (textBoxPermissionNum.Text != "" && comboBoxSupplierNames.Text != "" && comboBoxSupplyStoreNames.Text != "" && textBoxSupplyDate.Text != "")
                {
                    ImportPermission IP = DB.ImportPermissions.FirstOrDefault(a => a.ImportNum == selectedID);
                    string storeName = comboBoxSupplyStoreNames.Text;
                    Store store = DB.Stores.FirstOrDefault(a => a.StoreName == storeName);
                    IP.StoreId = store.StoreId;
                    //IP.Store.StoreName = comboBoxSupplyStoreNames.Text;
                    string supplierName = comboBoxSupplierNames.Text;
                    Supplier supplier = DB.Suppliers.FirstOrDefault(a => a.SupplierName == supplierName);
                    IP.SupplierId = supplier.SupplierId;
                    //IP.Supplier.SupplierName = comboBoxSupplierNames.Text;
                    try
                    {
                        IP.ImportDate = DateTime.Parse(textBoxSupplyDate.Text);
                    }
                    catch
                    {
                        MessageBox.Show("InValid Date");
                    }
                    DB.SaveChanges();
                    comboBoxSupplyItemsInfo.Text = comboBoxSupplierNames.Text = comboBoxSupplyStoreNames.Text = textBoxSupplyDate.Text = textBoxPermissionNum.Text = comboBoxSupplyPermissionIDs.Text = "";
                    MessageBox.Show("Permission Updated");
                }
                else
                {
                    MessageBox.Show("Please Fill Data");
                }
            }
            catch
            {
                MessageBox.Show("InValid Data");
            }
        }

        private void btnAddPermission_Click(object sender, EventArgs e)
        {
            try
            {
                if(textBoxNewSupplyPermissionID.Text!=""&&textBoxSupplyDate.Text!=""&&comboBoxSupplyStoreNames.Text!=""&&comboBoxSupplierNames.Text!="")
                {
                    int insertedID = int.Parse(textBoxNewSupplyPermissionID.Text);
                    ImportPermission iP = DB.ImportPermissions.FirstOrDefault(a => a.ImportNum == insertedID);
                    if (iP == null)
                    {
                        ImportPermission IP = new ImportPermission();
                        IP.ImportNum=insertedID;
                        //IP.Store.StoreName = comboBoxSupplyStoreNames.Text;
                        //IP.Supplier.SupplierName = comboBoxSupplierNames.Text;
                        string storeName = comboBoxSupplyStoreNames.Text;
                        Store store = DB.Stores.FirstOrDefault(a => a.StoreName == storeName);
                        IP.StoreId = store.StoreId;
                        string supplierName = comboBoxSupplierNames.Text;
                        Supplier supplier = DB.Suppliers.FirstOrDefault(a => a.SupplierName == supplierName);
                        IP.SupplierId = supplier.SupplierId;
                        try
                        {
                            IP.ImportDate = DateTime.Parse(textBoxSupplyDate.Text);
                        }
                        catch
                        {
                            MessageBox.Show("InValid Date");
                        }
                        DB.ImportPermissions.Add(IP);
                        DB.SaveChanges();
                        textBoxNewSupplyPermissionID.Text=comboBoxSupplyItemsInfo.Text = comboBoxSupplierNames.Text = comboBoxSupplyStoreNames.Text = textBoxSupplyDate.Text = textBoxPermissionNum.Text = comboBoxSupplyPermissionIDs.Text = "";
                        MessageBox.Show("Permission Added");
                    }
                    else
                    {
                        MessageBox.Show("Invalid Id");
                    }
                }
                else
                {
                    MessageBox.Show("Fill Required Data");
                }
            }
            catch
            {
                MessageBox.Show("InValid Data");
            }
        }

        #endregion

        #region Request TabPage

        private void comboBoxRequestPermissionIDs_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedId = int.Parse(comboBoxRequestPermissionIDs.Text);
            RequestPermission RP = DB.RequestPermissions.FirstOrDefault(a => a.RequestNum == selectedId);
            textBoxRequestId.Text = RP.RequestNum.ToString();
            textBoxRequestStore.Text = RP.Store.StoreName;
            textBoxRequestClient.Text = RP.Client.ClientName;
            textBoxRequestDate.Text = RP.RequestDate.ToString();
            foreach (var RequestItem in RP.RequestItems)
            {
                comboBoxRequestedItems.Items.Add(RequestItem.Item.ItemName + "," + RequestItem.Quantity.ToString());
                //comboBoxRequestedItems.Text = RequestItem.Item.ItemName + "," + RequestItem.Quantity.ToString();
            }
        }

        private void comboBoxRequestedItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str=comboBoxRequestedItems.SelectedItem.ToString();
            string[] value = str.Split(',');
            comboBoxRequestSelectNewItem.Text = value[0];
            textBoxRequestNewQuantity.Text = value[1];
            comboBoxRequestedItems.Items.Remove(comboBoxRequestedItems.SelectedItem);
        }

        private void btnAddItemAndQuantity_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxRequestSelectNewItem.Text != "" && textBoxRequestNewQuantity.Text != "")
                {
                    try
                    {
                        int x = int.Parse(textBoxRequestNewQuantity.Text);
                    }
                    catch
                    {
                        MessageBox.Show("Invalid Quantity");
                    }
                    comboBoxRequestedItems.Items.Add(comboBoxRequestSelectNewItem.Text + "," + textBoxRequestNewQuantity.Text);
                    comboBoxRequestSelectNewItem.Text = textBoxRequestNewQuantity.Text = "";
                }
                else
                {
                    MessageBox.Show("Please Fill Data");
                }
            }
            catch
            {
                MessageBox.Show("InValid Data.");
            }
            
        }

        private void btnUpdateRequest_Click(object sender, EventArgs e)
        {
            try
            {
                if(comboBoxRequestPermissionIDs.Text!=""&& comboBoxRequestToStores.Text!=""&& comboBoxRequestByClients.Text!=""&& textBoxRequestDate.Text!=""&& comboBoxRequestedItems.Items.Count > 0)
                {
                    int selectedId = int.Parse(comboBoxRequestPermissionIDs.Text);
                    RequestPermission RP = DB.RequestPermissions.FirstOrDefault(a => a.RequestNum == selectedId);
                    try
                    {
                        RP.RequestDate = DateTime.Parse(textBoxRequestDate.Text);
                    }
                    catch
                    {
                        MessageBox.Show("Invalid Date..!");
                    }
                    string storeName = comboBoxRequestToStores.Text;
                    Store s = DB.Stores.FirstOrDefault(a => a.StoreName == storeName);
                    RP.StoreId = s.StoreId;

                    string clientName = comboBoxRequestByClients.Text;
                    Client c = DB.Clients.FirstOrDefault(a => a.ClientName == clientName);
                    RP.ClientId= c.ClientId;

                    
                    DB.SaveChanges();
                    MessageBox.Show("Request Updated");
                    textBoxNewRequestID.Text = comboBoxRequestToStores.Text = comboBoxRequestByClients.Text = textBoxRequestDate.Text = textBoxRequestId.Text = textBoxRequestStore.Text = textBoxRequestClient.Text = comboBoxRequestPermissionIDs.Text = comboBoxRequestedItems.Text = "";

                }
                else
                {
                    MessageBox.Show("Please Fill Required Data To Update Request");
                }
            }
            catch
            {
                MessageBox.Show("InValid Data");
            }
        }

        

        private void btnAddRequst_Click(object sender, EventArgs e)
        {
            try
            {
                if(textBoxNewRequestID.Text!=""&& comboBoxRequestToStores.Text != ""&& comboBoxRequestByClients.Text != "" && textBoxRequestDate.Text != "")
                {
                    int selectedId = int.Parse(textBoxNewRequestID.Text);
                    RequestPermission rp = DB.RequestPermissions.FirstOrDefault(a => a.RequestNum == selectedId);
                    if (rp == null)
                    {
                        RequestPermission RP = new RequestPermission();
                        RP.RequestNum = selectedId;
                        try
                        {
                            RP.RequestDate = DateTime.Parse(textBoxRequestDate.Text);
                        }
                        catch
                        {
                            MessageBox.Show("Invalid Date..!");
                        }
                        string storeName = comboBoxRequestToStores.Text;
                        Store s = DB.Stores.FirstOrDefault(a => a.StoreName == storeName);
                        RP.StoreId = s.StoreId;

                        string clientName = comboBoxRequestByClients.Text;
                        Client c = DB.Clients.FirstOrDefault(a => a.ClientName == clientName);
                        RP.ClientId = c.ClientId;
                        comboBoxRequestPermissionIDs.Items.Add(selectedId.ToString());
                        DB.RequestPermissions.Add(RP);
                        DB.SaveChanges();
                        MessageBox.Show("Request Added");
                        textBoxNewRequestID.Text = comboBoxRequestToStores.Text = comboBoxRequestByClients.Text = textBoxRequestDate.Text = textBoxRequestId.Text = textBoxRequestStore.Text = textBoxRequestClient.Text = comboBoxRequestPermissionIDs.Text = comboBoxRequestedItems.Text = "";

                    }
                    else
                    {
                        MessageBox.Show("Invalid ID");
                    }
                }
                else
                {
                    MessageBox.Show("please Fill Data");
                }
            }
            catch
            {
                MessageBox.Show("Invalid Data");
            }
        }


        #endregion

        #region Items Movement
        private void btnMoveItem_Click(object sender, EventArgs e)
        {
            try
            {
                string itemName = comboBoxMovedItems.Text;
                Item I = DB.Items.FirstOrDefault(a => a.ItemName == itemName);

                string storeName = comboBoxMovedStores.Text;
                Store S = DB.Stores.FirstOrDefault(a => a.StoreName == storeName);

                S.Items.Add(I);
                DB.SaveChanges();
                MessageBox.Show("You Moved item : " + itemName + " To Store : " + storeName);
                comboBoxMovedItems.Text = comboBoxMovedStores.Text = "";
            }
            catch
            {
                MessageBox.Show("Invalid Movement");
            }
        }

        #endregion

        #region Store Report
        private void comboBoxStoreReports_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string storeName = comboBoxStoreReports.Text;
                Store S = DB.Stores.FirstOrDefault(a => a.StoreName == storeName);
                richTextBoxStoreReport.Text = "The Store ID : " + S.StoreId.ToString() + " ,the Store Name : " + S.StoreName + "\n";
                richTextBoxStoreReport.Text += " The Store Manger : " + S.Manager + " ,the Store Address : " + S.StoreAddress+"\n";
                foreach (var item in S.RequestPermissions)
                {
                    richTextBoxStoreReport.Text += "At " + item.RequestDate.ToString() + " By Client : " + item.Client.ClientName + " there are Request Number : " + item.RequestNum.ToString()+ "\n";
                    foreach(var x in item.RequestItems)
                    {
                        richTextBoxStoreReport.Text += "To Requset item : " + x.Item.ItemName + " and its Quantity is : " + x.Quantity.ToString() + "\n";
                    }
                }
            }
            catch
            {
                MessageBox.Show("try again");
            }
        }

        #endregion

        #region Item Report And Check If Item Nearly To be Expired or Not

        private void comboBoxItemsReports_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string itemName = comboBoxItemsReports.Text;
                Item i = DB.Items.FirstOrDefault(a => a.ItemName == itemName);
                richTextBoxItemReport.Text = "The Item Code : " + i.ItemCode.ToString() + " ,the item Name : " + i.ItemName + "\n";
                foreach (var item in i.ItemUnits)
                {
                    richTextBoxItemReport.Text += "this Item Unit is : " + item.Unit + "\n";
                }
                ImportItem importItems = DB.ImportItems.FirstOrDefault(a => a.ItemCode == i.ItemCode);
                if (importItems != null)
                {
                    //richTextBoxItemReport.Text += "The Production Date of this Item is : " + importItems.ProductionDate.ToString() + "\n";
                    //richTextBoxItemReport.Text += "The Expire Date of this Item is : " + importItems.ExpireDate.ToString() + "\n";
                    //richTextBoxItemReport.Text += (importItems.ExpireDate - DateTime.Now).ToString() + "\n";
                    string date= (importItems.ExpireDate - DateTime.Now).ToString();
                    string[] days = date.Split('.');
                    int x=int.Parse(days[0]);
                    if (x > 30)
                    {
                        richTextBoxItemReport.Text += "this item is not nearly to be expired" +"\n"+"The number of days that remain to be expired are : " + days[0];
                    }
                    else
                    {
                        richTextBoxItemReport.Text += "this item is nearly to be expired" + "\n"+"The number of days that remain to be expired are : " + days[0];
                    }
                }
                else
                {
                    MessageBox.Show("Has not Required Data Please Fill its Data And Try Again");
                }
                
            }
            catch
            {
                MessageBox.Show("try again");
            }
        }
        #endregion
    }
}
