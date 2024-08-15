namespace Airplane_Ticket_Booking
{
    partial class ChooseFlight
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmbDeptCity = new System.Windows.Forms.ComboBox();
            this.cmbDestCity = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFlightID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpDeptDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.btnBook = new System.Windows.Forms.Button();
            this.dgvResult = new System.Windows.Forms.DataGridView();
            this.btnSearch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(97, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dept City:";
            // 
            // cmbDeptCity
            // 
            this.cmbDeptCity.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDeptCity.FormattingEnabled = true;
            this.cmbDeptCity.Location = new System.Drawing.Point(280, 70);
            this.cmbDeptCity.Name = "cmbDeptCity";
            this.cmbDeptCity.Size = new System.Drawing.Size(203, 41);
            this.cmbDeptCity.TabIndex = 2;
            // 
            // cmbDestCity
            // 
            this.cmbDestCity.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDestCity.FormattingEnabled = true;
            this.cmbDestCity.Location = new System.Drawing.Point(812, 70);
            this.cmbDestCity.Name = "cmbDestCity";
            this.cmbDestCity.Size = new System.Drawing.Size(203, 41);
            this.cmbDestCity.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(629, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 31);
            this.label2.TabIndex = 3;
            this.label2.Text = "Dest City:";
            // 
            // txtFlightID
            // 
            this.txtFlightID.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFlightID.Location = new System.Drawing.Point(543, 267);
            this.txtFlightID.Name = "txtFlightID";
            this.txtFlightID.Size = new System.Drawing.Size(242, 38);
            this.txtFlightID.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(97, 168);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 31);
            this.label3.TabIndex = 5;
            this.label3.Text = "Dept Date:";
            // 
            // dtpDeptDate
            // 
            this.dtpDeptDate.CustomFormat = "DD-MM-YYYY";
            this.dtpDeptDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDeptDate.Location = new System.Drawing.Point(280, 168);
            this.dtpDeptDate.Name = "dtpDeptDate";
            this.dtpDeptDate.Size = new System.Drawing.Size(386, 31);
            this.dtpDeptDate.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(393, 274);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 31);
            this.label4.TabIndex = 7;
            this.label4.Text = "Flight ID:";
            // 
            // btnBook
            // 
            this.btnBook.Location = new System.Drawing.Point(833, 268);
            this.btnBook.Name = "btnBook";
            this.btnBook.Size = new System.Drawing.Size(111, 36);
            this.btnBook.TabIndex = 8;
            this.btnBook.Text = "Book";
            this.btnBook.UseVisualStyleBackColor = true;
            this.btnBook.Click += new System.EventHandler(this.btnBook_Click);
            // 
            // dgvResult
            // 
            this.dgvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResult.Location = new System.Drawing.Point(232, 379);
            this.dgvResult.Name = "dgvResult";
            this.dgvResult.Size = new System.Drawing.Size(756, 258);
            this.dgvResult.TabIndex = 9;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(750, 163);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(111, 36);
            this.btnSearch.TabIndex = 10;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // ChooseFlight
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Airplane_Ticket_Booking.Properties.Resources.Leonardo_Diffusion_Airportplane3d_imagecolorfulsharp_image_0;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.dgvResult);
            this.Controls.Add(this.btnBook);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtpDeptDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbDestCity);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbDeptCity);
            this.Controls.Add(this.txtFlightID);
            this.Controls.Add(this.label1);
            this.Name = "ChooseFlight";
            this.Text = "ChooseFlight";
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbDeptCity;
        private System.Windows.Forms.ComboBox cmbDestCity;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFlightID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpDeptDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnBook;
        private System.Windows.Forms.DataGridView dgvResult;
        private System.Windows.Forms.Button btnSearch;
    }
}