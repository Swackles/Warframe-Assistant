using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System;
using System.Threading.Tasks;

namespace Prime_Manager
{
   class UI
   {
        #region Add items to Item_Conteiner
        public static void CreateItem(Main main, IList<Item> itemCollection)
        {            
            foreach (Item item in itemCollection)
            {
                Panel Container = new Panel();
                Label Info = new Label();
                Label Title = new Label();
                Label Vaulted = new Label();
                Button Craft = new Button();
                Button Edit = new Button();
                
                PictureBox Icon = new PictureBox();
                
                main.Item_Collection.Controls.Add(Container);
                Container.Controls.Add(Info);
                Container.Controls.Add(Title);
                Container.Controls.Add(Craft);
                Container.Controls.Add(Edit);
                Container.Controls.Add(Icon);


                //
                // Container
                //
                Container.Size = new Size(main.Item_Collection.Width, 300);                
                Container.BorderStyle = BorderStyle.FixedSingle;
                Container.Name = "Container_Collection_Item_" + item.Name;
                Container.Location = new Point(0, (main.Item_Collection.Controls.Count - 1) * Container.Height);


                // 
                // item_Craft
                // 
                Craft.Name = "item_Craft";
                Craft.Text = "Craft";
                Craft.Size = new Size(80, 30);
                Craft.TabIndex = 0;
                Craft.FlatAppearance.BorderSize = 0;
                Craft.FlatStyle = FlatStyle.Flat;
                Craft.Font = new Font("Arial", 15.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                Craft.BackColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(159)))), ((int)(((byte)(219)))));
                Craft.ForeColor = Color.White;
                Craft.Location = new Point(Container.Width - (Craft.Width + 30), (Container.Height / 2) - Craft.Height);

                Craft.Click += delegate { Item.Craft(item, Info); };
                // 
                // Container_Edit
                // 
                Edit.Name = "Container"+item.Name+"Edit";
                Edit.Text = "Edit";
                Edit.Size = new Size(80, 30);
                Edit.TabIndex = 0;
                Edit.FlatAppearance.BorderSize = 0;
                Edit.FlatStyle = FlatStyle.Flat;
                Edit.Font = new Font("Arial", 15.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                Edit.BackColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(159)))), ((int)(((byte)(219)))));
                Edit.ForeColor = Color.White;
                Edit.Location = new Point(Container.Width - (Edit.Width + 30), (Container.Height / 2));
                // 
                // Container_icon
                //
                Debug.WriteLine(item.Name);
                Bitmap obj =  (Bitmap)(Properties.Resources.ResourceManager.GetObject(item.Name));
                Icon.Location = new Point(15, ((Container.Height - obj.Height) / 2));
                Icon.Name = "Container"+item.Name+"icon";
                Icon.Size = new Size(obj.Width, obj.Height);
                Icon.BackgroundImage = obj;
                Icon.TabIndex = 0;
                Icon.TabStop = false;
                // 
                // Container_Info
                // 
                Info.Size = new Size(180, 40);
                Info.Name = "Container_"+item.Name+"_info";
                Info.Text = "Vaulted: "+item.Vaulted.ToString()+"     Constructed: "+item.Constructed.ToString();
                Info.TabIndex = 0;
                Info.Location = new Point((Container.Width - Info.Width) / 2, Container.Height - 20);
                // 
                // Container_Title
                // 
                Title.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                Title.Location = new Point((Container.Width - Title.Width) / 2, 15);
                Title.TextAlign = ContentAlignment.MiddleCenter;
                Title.Name = "Container_"+item.Name+"_Title";
                Title.Text = item.Name;
                Title.TabIndex = 0;
                Title.Text = item.Name;

                int count = 0;

                foreach (Item.Part parts in item.Parts)
                {
                    Panel Part_Container = new Panel();
                    Label Name = new Label();
                    Label Have = new Label();
                    Button More = new Button();
                    Button Less = new Button();

                    LinkLabel Market_Title = new LinkLabel();
                    Label Market_BuyNow = new Label();
                    Label Market_SellNow = new Label();

                    LinkLabel Nexus_Title = new LinkLabel();
                    Label Nexus_Price = new Label();
                    Label Nexus_Supply = new Label();
                    Label Nexus_Demand = new Label();

                    Container.Controls.Add(Part_Container);
                    Part_Container.Controls.Add(Name);
                    Part_Container.Controls.Add(Have);
                    Part_Container.Controls.Add(More);
                    Part_Container.Controls.Add(Less);

                    Part_Container.Controls.Add(Market_Title);
                    Part_Container.Controls.Add(Market_BuyNow);
                    Part_Container.Controls.Add(Market_SellNow);

                    Part_Container.Controls.Add(Nexus_Title);
                    Part_Container.Controls.Add(Nexus_Price);
                    Part_Container.Controls.Add(Nexus_Supply);
                    Part_Container.Controls.Add(Nexus_Demand);

                    Part_Container.Size = new Size(100, 180);
                    Part_Container.Location = new Point(Icon.Width + 30 + (count * Part_Container.Width), (Container.Height / 2) - (Part_Container.Height / 2));
                    Part_Container.BorderStyle = BorderStyle.FixedSingle;
                    Part_Container.Name = "Container_Collection_" + item.Name + "_" + parts.Name;

                    Name.Size = new Size(80, 20);
                    Name.Font = new Font("Arial", 9.75F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
                    Name.Location = new Point((Part_Container.Width - Name.Width) / 2, 0);
                    Name.TextAlign = ContentAlignment.MiddleCenter;
                    Name.Name = "Container_" + item.Name + "_Title";
                    Name.Text = parts.Name;
                    Name.TabIndex = 0;

                    Less.Name = "item_Less";
                    Less.Text = "-";
                    Less.Size = new Size(20, 20);
                    Less.TabIndex = 0;
                    Less.FlatStyle = FlatStyle.Flat;
                    Less.Font = new Font("Arial", 15.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    Less.BackColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(159)))), ((int)(((byte)(219)))));
                    Less.ForeColor = Color.White;
                    Less.Location = new Point(0, 20);

                    Less.Click += delegate { Item.Part.Less(parts, Have); };

                    Have.Size = new Size(65, 20);
                    Have.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    Have.Location = new Point((Part_Container.Width - Have.Width) / 2, 20);
                    Have.TextAlign = ContentAlignment.MiddleCenter;
                    Have.Name = "Container_" + item.Name + "_Need";
                    Have.Text = "Have: " + parts.Have+"/"+parts.Needed;
                    Have.TabIndex = 0;

                    More.Name = "item_More";
                    More.Text = "+";
                    More.Size = new Size(20, 20);
                    More.TabIndex = 0;
                    More.FlatStyle = FlatStyle.Flat;
                    More.Font = new Font("Arial", 15.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    More.BackColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(159)))), ((int)(((byte)(219)))));
                    More.ForeColor = Color.White;
                    More.Location = new Point(Part_Container.Width - Less.Width, 20);

                    More.Click += delegate { Item.Part.More(parts, Have); };
                    //
                    // Warframe Market
                    //
                    Nexus_Title.Size = new Size(65, 20);
                    Nexus_Title.Font = new Font("Arial", 9.75F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
                    Nexus_Title.Location = new Point((Part_Container.Width - Nexus_Title.Width) / 2, 40);
                    Nexus_Title.TextAlign = ContentAlignment.MiddleCenter;
                    Nexus_Title.Name = "Container_" + item.Name + "_Title";
                    Nexus_Title.LinkClicked += new LinkLabelLinkClickedEventHandler( 
                        (object sender, LinkLabelLinkClickedEventArgs e) => {

                            string name = parts.Name;

                            name = name.Replace(" ", "");

                            if (name.Length > "Blueprint".Length)
                            {
                                parts.Name.Replace("Blueprint", "");
                            }                            

                            System.Diagnostics.Process.Start(("https://warframe.market/items/" + (item.Name+"_prime_"+name).ToLower()).Replace(" ", "_"));

                        });
                    Nexus_Title.Text = "Warframe";
                    Nexus_Title.TabIndex = 0;

                    Market_BuyNow.Size = new Size(90, 20);
                    Market_BuyNow.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    Market_BuyNow.Location = new Point((Part_Container.Width - Market_BuyNow.Width) / 2, 60);
                    Market_BuyNow.TextAlign = ContentAlignment.MiddleCenter;
                    Market_BuyNow.Name = "Container_" + item.Name + "_Need";
                    Market_BuyNow.Text = "Buy now: N/A";
                    Market_BuyNow.TabIndex = 0;

                    Market_SellNow.Size = new Size(90, 20);
                    Market_SellNow.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    Market_SellNow.Location = new Point((Part_Container.Width - Market_SellNow.Width) / 2, 80);
                    Market_SellNow.TextAlign = ContentAlignment.MiddleCenter;
                    Market_SellNow.Name = "Container_" + item.Name + "_Need";
                    Market_SellNow.Text = "Sell now: N/A";
                    Market_SellNow.TabIndex = 0;

                    //
                    // Warframe Nexus
                    //

                    Market_Title.Size = new Size(65, 20);
                    Market_Title.Font = new Font("Arial", 9.75F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
                    Market_Title.Location = new Point((Part_Container.Width - Market_Title.Width) / 2, 100);
                    Market_Title.TextAlign = ContentAlignment.MiddleCenter;
                    Market_Title.Name = "Container_" + item.Name + "_Title";
                    Market_Title.LinkClicked += new LinkLabelLinkClickedEventHandler(
                        (object sender, LinkLabelLinkClickedEventArgs e) => {

                            string name = item.Name;

                            name = name.Replace(" ", "");

                            if (name.Length > "Blueprint".Length)
                            {
                                parts.Name.Replace("Blueprint", "");
                            }

                            System.Diagnostics.Process.Start("https://nexus-stats.com/Prime/" + name);

                        });
                    Market_Title.Text = "Nexus";
                    Market_Title.TabIndex = 0;

                    Nexus_Price.Size = new Size(90, 20);
                    Nexus_Price.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    Nexus_Price.Location = new Point((Part_Container.Width - Nexus_Price.Width) / 2, 120);
                    Nexus_Price.TextAlign = ContentAlignment.MiddleCenter;
                    Nexus_Price.Name = "Container_" + item.Name + "_Need";
                    Nexus_Price.Text = "Buy: N/A";
                    Nexus_Price.TabIndex = 0;

                    Nexus_Supply.Size = new Size(90, 20);
                    Nexus_Supply.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    Nexus_Supply.Location = new Point((Part_Container.Width - Nexus_Supply.Width) / 2, 140);
                    Nexus_Supply.TextAlign = ContentAlignment.MiddleCenter;
                    Nexus_Supply.Name = "Container_" + item.Name + "_Need";
                    Nexus_Supply.Text = "Supply: N/A%";
                    Nexus_Supply.TabIndex = 0;

                    Nexus_Demand.Size = new Size(100, 20);
                    Nexus_Demand.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    Nexus_Demand.Location = new Point((Part_Container.Width - Nexus_Demand.Width) / 2, 160);
                    Nexus_Demand.TextAlign = ContentAlignment.MiddleCenter;
                    Nexus_Demand.Name = "Container_" + item.Name + "_Need";
                    Nexus_Demand.Text = "Demand: N/A%";
                    Nexus_Demand.TabIndex = 0;

                    count++;
                }
            }
        }
        #endregion

        #region Add relics to Relic_Container
        public static void CreateRelic(Main main, IList<Relic> relicCollection)
        {
            IList<Panel> ContainerCollection = new List<Panel>();

            Parallel.ForEach(relicCollection, relic  => {
                Panel Container = new Panel();
                Label Info = new Label();
                Label Title = new Label();
                Label Vaulted = new Label();
                Button Craft = new Button();
                Button Edit = new Button();

                PictureBox Icon = new PictureBox();

                ContainerCollection.Add(Container);
                Container.Controls.Add(Info);
                Container.Controls.Add(Title);
                Container.Controls.Add(Craft);
                Container.Controls.Add(Edit);
                Container.Controls.Add(Icon);
                //
                // Container
                //
                Container.Size = new Size(main.Item_Collection.Width, 300);
                Container.BorderStyle = BorderStyle.FixedSingle;
                Container.Name = "Container_Collection_Relic" + relic.Name;
                Container.Location = new Point(0, (main.Item_Collection.Controls.Count - 1) * Container.Height);
                // 
                // relic_Craft
                // 
                Craft.Name = "relic_Craft";
                Craft.Text = "Craft";
                Craft.Size = new Size(80, 30);
                Craft.TabIndex = 0;
                Craft.FlatAppearance.BorderSize = 0;
                Craft.FlatStyle = FlatStyle.Flat;
                Craft.Font = new Font("Arial", 15.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                Craft.BackColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(159)))), ((int)(((byte)(219)))));
                Craft.ForeColor = Color.White;
                Craft.Location = new Point(Container.Width - (Craft.Width + 30), (Container.Height / 2) - Craft.Height);
                // 
                // Container_Edit
                // 
                Edit.Name = "Container" + relic.Name + "Edit";
                Edit.Text = "Edit";
                Edit.Size = new Size(80, 30);
                Edit.TabIndex = 0;
                Edit.FlatAppearance.BorderSize = 0;
                Edit.FlatStyle = FlatStyle.Flat;
                Edit.Font = new Font("Arial", 15.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                Edit.BackColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(159)))), ((int)(((byte)(219)))));
                Edit.ForeColor = Color.White;
                Edit.Location = new Point(Container.Width - (Edit.Width + 30), (Container.Height / 2));
                // 
                // Container_icon
                //
                Debug.WriteLine(relic.Name);
                Bitmap obj = (Bitmap)(Properties.Resources.ResourceManager.GetObject(Storage.Tiers[relic.Tier]));
                Icon.Location = new Point(15, ((Container.Height - obj.Height) / 2));
                Icon.Name = "Container" + relic.Name + "icon";
                Icon.Size = new Size(obj.Width, obj.Height);
                Icon.BackgroundImage = obj;
                Icon.TabIndex = 0;
                Icon.TabStop = false;
                // 
                // Container_Info
                // 
                Info.Size = new Size(180, 40);
                Info.Name = "Container_" + relic.Name + "_info";
                Info.Text = "Vaulted: " + relic.Vaulted.ToString() + "     Amount: " + relic.Have.ToString();
                Info.TabIndex = 0;
                Info.Location = new Point((Container.Width - Info.Width) / 2, Container.Height - 20);
                // 
                // Container_Title
                // 
                Title.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                Title.Location = new Point((Container.Width - Title.Width) / 2, 15);
                Title.TextAlign = ContentAlignment.MiddleCenter;
                Title.Name = "Container_" + relic.Name + "_Title";
                Title.Text = relic.Name;
                Title.TabIndex = 0;
                Title.Text = relic.Name;

                int count = 0;

                foreach (Item.Part parts in relic.Parts)
                {
                    Panel Part_Container = new Panel();
                    Label Name = new Label();
                    Label Have = new Label();
                    Button More = new Button();
                    Button Less = new Button();

                    LinkLabel Market_Title = new LinkLabel();
                    Label Market_BuyNow = new Label();
                    Label Market_SellNow = new Label();

                    LinkLabel Nexus_Title = new LinkLabel();
                    Label Nexus_Price = new Label();
                    Label Nexus_Supply = new Label();
                    Label Nexus_Demand = new Label();

                    Container.Controls.Add(Part_Container);
                    Part_Container.Controls.Add(Name);
                    Part_Container.Controls.Add(Have);
                    Part_Container.Controls.Add(More);
                    Part_Container.Controls.Add(Less);

                    Part_Container.Controls.Add(Market_Title);
                    Part_Container.Controls.Add(Market_BuyNow);
                    Part_Container.Controls.Add(Market_SellNow);

                    Part_Container.Controls.Add(Nexus_Title);
                    Part_Container.Controls.Add(Nexus_Price);
                    Part_Container.Controls.Add(Nexus_Supply);
                    Part_Container.Controls.Add(Nexus_Demand);

                    Part_Container.Size = new Size(100, 180);
                    Part_Container.Location = new Point(Icon.Width + 30 + (count * Part_Container.Width), (Container.Height / 2) - (Part_Container.Height / 2));
                    Part_Container.BorderStyle = BorderStyle.FixedSingle;
                    Part_Container.Name = "Container_Collection_" + relic.Name + "_" + parts.Name;

                    Name.Size = new Size(80, 20);
                    Name.Font = new Font("Arial", 9.75F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
                    Name.Location = new Point((Part_Container.Width - Name.Width) / 2, 0);
                    Name.TextAlign = ContentAlignment.MiddleCenter;
                    Name.Name = "Container_" + relic.Name + "_Title";
                    Name.Text = parts.Name;
                    Name.TabIndex = 0;

                    Less.Name = "relic_Less";
                    Less.Text = "-";
                    Less.Size = new Size(20, 20);
                    Less.TabIndex = 0;
                    Less.FlatStyle = FlatStyle.Flat;
                    Less.Font = new Font("Arial", 15.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    Less.BackColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(159)))), ((int)(((byte)(219)))));
                    Less.ForeColor = Color.White;
                    Less.Location = new Point(0, 20);

                    Less.Click += delegate { Item.Part.Less(parts, Have); };

                    Have.Size = new Size(65, 20);
                    Have.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    Have.Location = new Point((Part_Container.Width - Have.Width) / 2, 20);
                    Have.TextAlign = ContentAlignment.MiddleCenter;
                    Have.Name = "Container_" + relic.Name + "_Need";
                    Have.Text = "Have: " + parts.Have + "/" + parts.Needed;
                    Have.TabIndex = 0;

                    More.Name = "relic_More";
                    More.Text = "+";
                    More.Size = new Size(20, 20);
                    More.TabIndex = 0;
                    More.FlatStyle = FlatStyle.Flat;
                    More.Font = new Font("Arial", 15.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    More.BackColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(159)))), ((int)(((byte)(219)))));
                    More.ForeColor = Color.White;
                    More.Location = new Point(Part_Container.Width - Less.Width, 20);

                    More.Click += delegate { Item.Part.More(parts, Have); };
                    //
                    // Warframe Market
                    //
                    Nexus_Title.Size = new Size(65, 20);
                    Nexus_Title.Font = new Font("Arial", 9.75F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
                    Nexus_Title.Location = new Point((Part_Container.Width - Nexus_Title.Width) / 2, 40);
                    Nexus_Title.TextAlign = ContentAlignment.MiddleCenter;
                    Nexus_Title.Name = "Container_" + relic.Name + "_Title";
                    Nexus_Title.LinkClicked += new LinkLabelLinkClickedEventHandler(
                        (object sender, LinkLabelLinkClickedEventArgs e) => {

                            string name = parts.Name;

                            name = name.Replace(" ", "");

                            if (name.Length > "Blueprint".Length)
                            {
                                parts.Name.Replace("Blueprint", "");
                            }

                            System.Diagnostics.Process.Start(("https://warframe.market/items/" + (relic.Name + "_prime_" + name).ToLower()).Replace(" ", "_"));

                        });
                    Nexus_Title.Text = "Warframe";
                    Nexus_Title.TabIndex = 0;

                    Market_BuyNow.Size = new Size(90, 20);
                    Market_BuyNow.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    Market_BuyNow.Location = new Point((Part_Container.Width - Market_BuyNow.Width) / 2, 60);
                    Market_BuyNow.TextAlign = ContentAlignment.MiddleCenter;
                    Market_BuyNow.Name = "Container_" + relic.Name + "_Need";
                    Market_BuyNow.Text = "Buy now: N/A";
                    Market_BuyNow.TabIndex = 0;

                    Market_SellNow.Size = new Size(90, 20);
                    Market_SellNow.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    Market_SellNow.Location = new Point((Part_Container.Width - Market_SellNow.Width) / 2, 80);
                    Market_SellNow.TextAlign = ContentAlignment.MiddleCenter;
                    Market_SellNow.Name = "Container_" + relic.Name + "_Need";
                    Market_SellNow.Text = "Sell now: N/A";
                    Market_SellNow.TabIndex = 0;

                    //
                    // Warframe Nexus
                    //

                    Market_Title.Size = new Size(65, 20);
                    Market_Title.Font = new Font("Arial", 9.75F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
                    Market_Title.Location = new Point((Part_Container.Width - Market_Title.Width) / 2, 100);
                    Market_Title.TextAlign = ContentAlignment.MiddleCenter;
                    Market_Title.Name = "Container_" + relic.Name + "_Title";
                    Market_Title.LinkClicked += new LinkLabelLinkClickedEventHandler(
                        (object sender, LinkLabelLinkClickedEventArgs e) => {

                            string name = relic.Name;

                            name = name.Replace(" ", "");

                            if (name.Length > "Blueprint".Length)
                            {
                                parts.Name.Replace("Blueprint", "");
                            }

                            System.Diagnostics.Process.Start("https://nexus-stats.com/Prime/" + name);

                        });
                    Market_Title.Text = "Nexus";
                    Market_Title.TabIndex = 0;

                    Nexus_Price.Size = new Size(90, 20);
                    Nexus_Price.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    Nexus_Price.Location = new Point((Part_Container.Width - Nexus_Price.Width) / 2, 120);
                    Nexus_Price.TextAlign = ContentAlignment.MiddleCenter;
                    Nexus_Price.Name = "Container_" + relic.Name + "_Need";
                    Nexus_Price.Text = "Buy: N/A";
                    Nexus_Price.TabIndex = 0;

                    Nexus_Supply.Size = new Size(90, 20);
                    Nexus_Supply.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    Nexus_Supply.Location = new Point((Part_Container.Width - Nexus_Supply.Width) / 2, 140);
                    Nexus_Supply.TextAlign = ContentAlignment.MiddleCenter;
                    Nexus_Supply.Name = "Container_" + relic.Name + "_Need";
                    Nexus_Supply.Text = "Supply: N/A%";
                    Nexus_Supply.TabIndex = 0;

                    Nexus_Demand.Size = new Size(100, 20);
                    Nexus_Demand.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    Nexus_Demand.Location = new Point((Part_Container.Width - Nexus_Demand.Width) / 2, 160);
                    Nexus_Demand.TextAlign = ContentAlignment.MiddleCenter;
                    Nexus_Demand.Name = "Container_" + relic.Name + "_Need";
                    Nexus_Demand.Text = "Demand: N/A%";
                    Nexus_Demand.TabIndex = 0;

                    count++;
                }
            });

            foreach (Panel panel in ContainerCollection)
            {
                main.Controls.Add(panel);
            }
        }

 

        #endregion

        #region Remove items from Item_Container
        public static void DisposeItems()
        {
            
            foreach(Panel panel in Main.ActiveForm.Controls.Find("Item_Collection", true))
            {
                panel.Dispose();
            }
            
        }
        #endregion

        #region Remove relics from Relic_Container
        public static void DisposeRelics()
        {
            foreach (Panel panel in Main.ActiveForm.Controls.Find("Relic_Collection", true))
            {
                panel.Dispose();
            }

        }
        #endregion

        #region Mission success confirmation
        public static void SuccessConfirm(List<Item.Part> parts) {
            Parallel.foreach(parts, part => {
                
            });
        }
        #endregion

        #region Mission reward confirmation
        public static void RewardConfirm(List<Item.Part> parts) {

        }
        #endregion
    }
}
