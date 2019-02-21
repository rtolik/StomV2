namespace Stomatology
{
    partial class Main
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.panel1 = new System.Windows.Forms.Panel();
            this.PrintPriceBtn = new MetroFramework.Controls.MetroButton();
            this.WarehouseBtn = new MetroFramework.Controls.MetroButton();
            this.MoneyTransferBtn = new MetroFramework.Controls.MetroButton();
            this.CardFileBtn = new MetroFramework.Controls.MetroButton();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.metroStyleManager1 = new MetroFramework.Components.MetroStyleManager(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.PrintPriceBtn);
            this.panel1.Controls.Add(this.WarehouseBtn);
            this.panel1.Controls.Add(this.MoneyTransferBtn);
            this.panel1.Controls.Add(this.CardFileBtn);
            this.panel1.Location = new System.Drawing.Point(23, 63);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 700);
            this.panel1.TabIndex = 0;
            // 
            // PrintPriceBtn
            // 
            this.PrintPriceBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.PrintPriceBtn.Location = new System.Drawing.Point(0, 150);
            this.PrintPriceBtn.Margin = new System.Windows.Forms.Padding(0);
            this.PrintPriceBtn.Name = "PrintPriceBtn";
            this.PrintPriceBtn.Size = new System.Drawing.Size(200, 50);
            this.PrintPriceBtn.TabIndex = 5;
            this.PrintPriceBtn.Text = "Друк Прайсу";
            this.PrintPriceBtn.UseSelectable = true;
            // 
            // WarehouseBtn
            // 
            this.WarehouseBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.WarehouseBtn.Location = new System.Drawing.Point(0, 100);
            this.WarehouseBtn.Margin = new System.Windows.Forms.Padding(0);
            this.WarehouseBtn.Name = "WarehouseBtn";
            this.WarehouseBtn.Size = new System.Drawing.Size(200, 50);
            this.WarehouseBtn.TabIndex = 4;
            this.WarehouseBtn.Text = "Сховище";
            this.WarehouseBtn.UseSelectable = true;
            // 
            // MoneyTransferBtn
            // 
            this.MoneyTransferBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("MoneyTransferBtn.BackgroundImage")));
            this.MoneyTransferBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.MoneyTransferBtn.Location = new System.Drawing.Point(0, 50);
            this.MoneyTransferBtn.Margin = new System.Windows.Forms.Padding(0);
            this.MoneyTransferBtn.Name = "MoneyTransferBtn";
            this.MoneyTransferBtn.Size = new System.Drawing.Size(200, 50);
            this.MoneyTransferBtn.TabIndex = 3;
            this.MoneyTransferBtn.UseSelectable = true;
            // 
            // CardFileBtn
            // 
            this.CardFileBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("CardFileBtn.BackgroundImage")));
            this.CardFileBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.CardFileBtn.Location = new System.Drawing.Point(0, 0);
            this.CardFileBtn.Margin = new System.Windows.Forms.Padding(0);
            this.CardFileBtn.Name = "CardFileBtn";
            this.CardFileBtn.Size = new System.Drawing.Size(200, 50);
            this.CardFileBtn.TabIndex = 2;
            this.CardFileBtn.UseSelectable = true;
            this.CardFileBtn.Click += new System.EventHandler(this.CardFileBtn_Click);
            // 
            // webBrowser1
            // 
            this.webBrowser1.AllowWebBrowserDrop = false;
            this.webBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser1.Location = new System.Drawing.Point(229, 63);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.ScriptErrorsSuppressed = true;
            this.webBrowser1.Size = new System.Drawing.Size(1048, 700);
            this.webBrowser1.TabIndex = 1;
            this.webBrowser1.TabStop = false;
            this.webBrowser1.Url = new System.Uri("", System.UriKind.Relative);
            // 
            // metroStyleManager1
            // 
            this.metroStyleManager1.Owner = this;
            this.metroStyleManager1.Style = MetroFramework.MetroColorStyle.Pink;
            this.metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1300, 800);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.panel1);
            this.Name = "Main";
            this.Style = MetroFramework.MetroColorStyle.Default;
            this.Text = "Stomatology";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private MetroFramework.Controls.MetroButton CardFileBtn;
        private MetroFramework.Controls.MetroButton MoneyTransferBtn;
        private MetroFramework.Controls.MetroButton PrintPriceBtn;
        private MetroFramework.Controls.MetroButton WarehouseBtn;
        private MetroFramework.Components.MetroStyleManager metroStyleManager1;
    }
}

