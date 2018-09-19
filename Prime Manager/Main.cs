using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Collections.Generic;

namespace Prime_Manager
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();

            Item_Filter_Text_Name.Focus();
            Item_Filter_Text_Name.GotFocus += new EventHandler(Item_Filter_Text_Name_GotGocus);
            Item_Filter_Text_Name.LostFocus += new EventHandler(Item_Filter_Text_Name_LostFocus);

            UI.CreateItem(this, Storage.Items);

            AddItemType();
        }

        public void AddItemType()
        {
            foreach (String item in Storage.Types)
            {
                this.Item_Filter_Type.Items.Add(item);
            }
        }

        public void Item_Filter_Text_Name_GotGocus(object sender, EventArgs e)
        {
            Item_Filter_Text_Name.Text = "";
        }

        public void Item_Filter_Text_Name_LostFocus(object sender, EventArgs e)
        {
            Item_Filter_Text_Name.Text = "Filter by item name";
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Exit");
            Parse.DataJson(Storage.JsonFilepath);
            Application.Exit();
        }

        private void Items_Click(object sender, EventArgs e)
        {
            UI.DisposeRelics();
            UI.CreateItem(this, Storage.Items);
            
            this.Item_Panel.Visible = true;
            this.Relic_Panel.Visible = false;
        }

        private void Relics_Click(object sender, EventArgs e)
        {
            UI.DisposeItems();
            
            this.Item_Panel.Visible = false;
            this.Relic_Panel.Visible = true;
        }

        private void Item_Filter_Text_Name_TextChanged(object sender, EventArgs e)
        {

        }

        private void Item_Filter_Type_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            IList<Item> items = new List<Item>();

            string name = this.Item_Filter_Text_Name.Text;
            string type = this.Item_Filter_Type.SelectedText;
            bool constructed = this.Item_Filter_Constructed.Checked;
            bool vaulted = this.Item_Filter_Vaulted.Checked;

            items.Add(Item.FindByName(name));
            
        }
    }
}
