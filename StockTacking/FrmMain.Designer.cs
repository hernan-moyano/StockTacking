namespace StockTacking
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSales = new System.Windows.Forms.Button();
            this.btnProduct = new System.Windows.Forms.Button();
            this.btnCustomer = new System.Windows.Forms.Button();
            this.btnAddStock = new System.Windows.Forms.Button();
            this.btnCategory = new System.Windows.Forms.Button();
            this.btnDeleted = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSales
            // 
            this.btnSales.BackColor = System.Drawing.Color.Gold;
            this.btnSales.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSales.Image = global::StockTacking.Properties.Resources.cart_arrow_down_solid;
            this.btnSales.Location = new System.Drawing.Point(396, 1);
            this.btnSales.Name = "btnSales";
            this.btnSales.Size = new System.Drawing.Size(191, 228);
            this.btnSales.TabIndex = 2;
            this.btnSales.Text = "Ventas";
            this.btnSales.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSales.UseVisualStyleBackColor = false;
            this.btnSales.Click += new System.EventHandler(this.btnSales_Click);
            // 
            // btnProduct
            // 
            this.btnProduct.BackColor = System.Drawing.Color.Orange;
            this.btnProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProduct.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnProduct.Image = global::StockTacking.Properties.Resources.box_solid;
            this.btnProduct.Location = new System.Drawing.Point(199, 1);
            this.btnProduct.Name = "btnProduct";
            this.btnProduct.Size = new System.Drawing.Size(191, 228);
            this.btnProduct.TabIndex = 1;
            this.btnProduct.Text = "Productos";
            this.btnProduct.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnProduct.UseVisualStyleBackColor = false;
            this.btnProduct.Click += new System.EventHandler(this.btnProduct_Click);
            // 
            // btnCustomer
            // 
            this.btnCustomer.BackColor = System.Drawing.Color.Firebrick;
            this.btnCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCustomer.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCustomer.Image = global::StockTacking.Properties.Resources.people_group_solid;
            this.btnCustomer.Location = new System.Drawing.Point(2, 1);
            this.btnCustomer.Name = "btnCustomer";
            this.btnCustomer.Size = new System.Drawing.Size(191, 228);
            this.btnCustomer.TabIndex = 0;
            this.btnCustomer.Text = "Clientes";
            this.btnCustomer.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCustomer.UseVisualStyleBackColor = false;
            this.btnCustomer.Click += new System.EventHandler(this.btnCustomer_Click);
            // 
            // btnAddStock
            // 
            this.btnAddStock.BackColor = System.Drawing.Color.YellowGreen;
            this.btnAddStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddStock.Image = global::StockTacking.Properties.Resources.square_plus_solid;
            this.btnAddStock.Location = new System.Drawing.Point(2, 235);
            this.btnAddStock.Name = "btnAddStock";
            this.btnAddStock.Size = new System.Drawing.Size(191, 228);
            this.btnAddStock.TabIndex = 3;
            this.btnAddStock.Text = "Agregar Stock";
            this.btnAddStock.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAddStock.UseVisualStyleBackColor = false;
            this.btnAddStock.Click += new System.EventHandler(this.btnAddStock_Click);
            // 
            // btnCategory
            // 
            this.btnCategory.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCategory.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCategory.Image = global::StockTacking.Properties.Resources.sitemap_solid;
            this.btnCategory.Location = new System.Drawing.Point(199, 235);
            this.btnCategory.Name = "btnCategory";
            this.btnCategory.Size = new System.Drawing.Size(191, 228);
            this.btnCategory.TabIndex = 4;
            this.btnCategory.Text = "Categorías";
            this.btnCategory.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCategory.UseVisualStyleBackColor = false;
            this.btnCategory.Click += new System.EventHandler(this.btnCategory_Click);
            // 
            // btnDeleted
            // 
            this.btnDeleted.BackColor = System.Drawing.Color.DarkViolet;
            this.btnDeleted.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleted.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDeleted.Image = global::StockTacking.Properties.Resources.eraser_solid;
            this.btnDeleted.Location = new System.Drawing.Point(396, 235);
            this.btnDeleted.Name = "btnDeleted";
            this.btnDeleted.Size = new System.Drawing.Size(191, 228);
            this.btnDeleted.TabIndex = 5;
            this.btnDeleted.Text = "Eliminados";
            this.btnDeleted.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDeleted.UseVisualStyleBackColor = false;
            this.btnDeleted.Click += new System.EventHandler(this.btnDeleted_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Red;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnExit.Image = global::StockTacking.Properties.Resources.arrow_right_from_bracket_solid;
            this.btnExit.Location = new System.Drawing.Point(199, 469);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(191, 228);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "Salir";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 694);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnAddStock);
            this.Controls.Add(this.btnCategory);
            this.Controls.Add(this.btnDeleted);
            this.Controls.Add(this.btnCustomer);
            this.Controls.Add(this.btnProduct);
            this.Controls.Add(this.btnSales);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stock Traking";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMain_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSales;
        private System.Windows.Forms.Button btnProduct;
        private System.Windows.Forms.Button btnCustomer;
        private System.Windows.Forms.Button btnAddStock;
        private System.Windows.Forms.Button btnCategory;
        private System.Windows.Forms.Button btnDeleted;
        private System.Windows.Forms.Button btnExit;
    }
}