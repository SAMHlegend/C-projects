namespace Projectaccounting
{
    partial class FrmCustomers
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.BtnAddcustomer = new System.Windows.Forms.ToolStripButton();
            this.BtnEditcustomer = new System.Windows.Forms.ToolStripButton();
            this.BtnDeletecustomer = new System.Windows.Forms.ToolStripButton();
            this.BtnRefreshcustomer = new System.Windows.Forms.ToolStripButton();
            this.txtfilter = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.dgcustomers = new System.Windows.Forms.DataGridView();
            this.CustomerId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgcustomers)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtnAddcustomer,
            this.BtnEditcustomer,
            this.BtnDeletecustomer,
            this.BtnRefreshcustomer,
            this.txtfilter,
            this.toolStripLabel1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolStrip1.Size = new System.Drawing.Size(782, 99);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // BtnAddcustomer
            // 
            this.BtnAddcustomer.Image = global::Projectaccounting.Properties.Resources.adduser;
            this.BtnAddcustomer.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BtnAddcustomer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnAddcustomer.Name = "BtnAddcustomer";
            this.BtnAddcustomer.Size = new System.Drawing.Size(108, 96);
            this.BtnAddcustomer.Text = "Add Customer";
            this.BtnAddcustomer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BtnAddcustomer.Click += new System.EventHandler(this.BtnAddcustomer_Click);
            // 
            // BtnEditcustomer
            // 
            this.BtnEditcustomer.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BtnEditcustomer.Image = global::Projectaccounting.Properties.Resources.edituser;
            this.BtnEditcustomer.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BtnEditcustomer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnEditcustomer.Name = "BtnEditcustomer";
            this.BtnEditcustomer.Size = new System.Drawing.Size(106, 96);
            this.BtnEditcustomer.Text = "Edit Customer";
            this.BtnEditcustomer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BtnEditcustomer.Click += new System.EventHandler(this.BtnEditcustomer_Click);
            // 
            // BtnDeletecustomer
            // 
            this.BtnDeletecustomer.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BtnDeletecustomer.Image = global::Projectaccounting.Properties.Resources.deleteuser;
            this.BtnDeletecustomer.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BtnDeletecustomer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnDeletecustomer.Name = "BtnDeletecustomer";
            this.BtnDeletecustomer.Size = new System.Drawing.Size(88, 96);
            this.BtnDeletecustomer.Text = "Delete user";
            this.BtnDeletecustomer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BtnDeletecustomer.Click += new System.EventHandler(this.BtnDeletecustomer_Click);
            // 
            // BtnRefreshcustomer
            // 
            this.BtnRefreshcustomer.Image = global::Projectaccounting.Properties.Resources.Refresh;
            this.BtnRefreshcustomer.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BtnRefreshcustomer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnRefreshcustomer.Name = "BtnRefreshcustomer";
            this.BtnRefreshcustomer.Size = new System.Drawing.Size(76, 96);
            this.BtnRefreshcustomer.Text = "Refresh";
            this.BtnRefreshcustomer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BtnRefreshcustomer.Click += new System.EventHandler(this.BtnRefreshcustomer_Click);
            // 
            // txtfilter
            // 
            this.txtfilter.BackColor = System.Drawing.Color.White;
            this.txtfilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtfilter.Name = "txtfilter";
            this.txtfilter.Size = new System.Drawing.Size(100, 99);
            this.txtfilter.Click += new System.EventHandler(this.txtfilter_Click);
            this.txtfilter.TextChanged += new System.EventHandler(this.txtfilter_TextChanged);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(60, 96);
            this.toolStripLabel1.Text = ": Search";
            // 
            // dgcustomers
            // 
            this.dgcustomers.AllowUserToAddRows = false;
            this.dgcustomers.AllowUserToDeleteRows = false;
            this.dgcustomers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgcustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgcustomers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CustomerId,
            this.Column1,
            this.Column2,
            this.Column3});
            this.dgcustomers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgcustomers.Location = new System.Drawing.Point(0, 99);
            this.dgcustomers.Name = "dgcustomers";
            this.dgcustomers.ReadOnly = true;
            this.dgcustomers.RowTemplate.Height = 24;
            this.dgcustomers.Size = new System.Drawing.Size(782, 354);
            this.dgcustomers.TabIndex = 1;
            this.dgcustomers.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgcustomers_CellContentClick);
            // 
            // CustomerId
            // 
            this.CustomerId.DataPropertyName = "CustomersID";
            this.CustomerId.HeaderText = "Column1";
            this.CustomerId.Name = "CustomerId";
            this.CustomerId.ReadOnly = true;
            this.CustomerId.Visible = false;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Name";
            this.Column1.HeaderText = "Name";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Phone";
            this.Column2.HeaderText = "Mobile";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Email";
            this.Column3.HeaderText = "Email";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // FrmCustomers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 453);
            this.Controls.Add(this.dgcustomers);
            this.Controls.Add(this.toolStrip1);
            this.Name = "FrmCustomers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Customers";
            this.Load += new System.EventHandler(this.FrmCustomers_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgcustomers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton BtnAddcustomer;
        private System.Windows.Forms.ToolStripButton BtnEditcustomer;
        private System.Windows.Forms.ToolStripButton BtnDeletecustomer;
        private System.Windows.Forms.ToolStripButton BtnRefreshcustomer;
        private System.Windows.Forms.ToolStripTextBox txtfilter;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.DataGridView dgcustomers;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
    }
}