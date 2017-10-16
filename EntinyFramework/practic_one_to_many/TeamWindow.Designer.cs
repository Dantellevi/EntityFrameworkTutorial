namespace practic_one_to_many
{
    partial class TeamWindow
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
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Teambutadd = new System.Windows.Forms.Button();
            this.Teambtnedit = new System.Windows.Forms.Button();
            this.Teambtndelete = new System.Windows.Forms.Button();
            this.Teambtnitem = new System.Windows.Forms.Button();
            this.listItem = new System.Windows.Forms.ListBox();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coachDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.playersDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.teamBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teamBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.coachDataGridViewTextBoxColumn,
            this.playersDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.teamBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(480, 233);
            this.dataGridView1.TabIndex = 0;
            // 
            // Teambutadd
            // 
            this.Teambutadd.Location = new System.Drawing.Point(12, 253);
            this.Teambutadd.Name = "Teambutadd";
            this.Teambutadd.Size = new System.Drawing.Size(94, 23);
            this.Teambutadd.TabIndex = 1;
            this.Teambutadd.Text = "добавить";
            this.Teambutadd.UseVisualStyleBackColor = true;
            this.Teambutadd.Click += new System.EventHandler(this.Teambutadd_Click);
            // 
            // Teambtnedit
            // 
            this.Teambtnedit.Location = new System.Drawing.Point(127, 252);
            this.Teambtnedit.Name = "Teambtnedit";
            this.Teambtnedit.Size = new System.Drawing.Size(95, 23);
            this.Teambtnedit.TabIndex = 2;
            this.Teambtnedit.Text = "изменить";
            this.Teambtnedit.UseVisualStyleBackColor = true;
            this.Teambtnedit.Click += new System.EventHandler(this.Teambtnedit_Click);
            // 
            // Teambtndelete
            // 
            this.Teambtndelete.Location = new System.Drawing.Point(241, 251);
            this.Teambtndelete.Name = "Teambtndelete";
            this.Teambtndelete.Size = new System.Drawing.Size(94, 23);
            this.Teambtndelete.TabIndex = 3;
            this.Teambtndelete.Text = "удалить";
            this.Teambtndelete.UseVisualStyleBackColor = true;
            this.Teambtndelete.Click += new System.EventHandler(this.Teambtndelete_Click);
            // 
            // Teambtnitem
            // 
            this.Teambtnitem.Location = new System.Drawing.Point(498, 253);
            this.Teambtnitem.Name = "Teambtnitem";
            this.Teambtnitem.Size = new System.Drawing.Size(128, 23);
            this.Teambtnitem.TabIndex = 4;
            this.Teambtnitem.Text = "Состав";
            this.Teambtnitem.UseVisualStyleBackColor = true;
            this.Teambtnitem.Click += new System.EventHandler(this.Teambtnitem_Click);
            // 
            // listItem
            // 
            this.listItem.FormattingEnabled = true;
            this.listItem.Location = new System.Drawing.Point(498, 12);
            this.listItem.Name = "listItem";
            this.listItem.Size = new System.Drawing.Size(142, 225);
            this.listItem.TabIndex = 5;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // coachDataGridViewTextBoxColumn
            // 
            this.coachDataGridViewTextBoxColumn.DataPropertyName = "Coach";
            this.coachDataGridViewTextBoxColumn.HeaderText = "Coach";
            this.coachDataGridViewTextBoxColumn.Name = "coachDataGridViewTextBoxColumn";
            // 
            // playersDataGridViewTextBoxColumn
            // 
            this.playersDataGridViewTextBoxColumn.DataPropertyName = "Players";
            this.playersDataGridViewTextBoxColumn.HeaderText = "Players";
            this.playersDataGridViewTextBoxColumn.Name = "playersDataGridViewTextBoxColumn";
            // 
            // teamBindingSource
            // 
            this.teamBindingSource.DataSource = typeof(practic_one_to_many.Team);
            // 
            // TeamWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 324);
            this.Controls.Add(this.listItem);
            this.Controls.Add(this.Teambtnitem);
            this.Controls.Add(this.Teambtndelete);
            this.Controls.Add(this.Teambtnedit);
            this.Controls.Add(this.Teambutadd);
            this.Controls.Add(this.dataGridView1);
            this.Name = "TeamWindow";
            this.Text = "TeamWindow";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teamBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn coachDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn playersDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource teamBindingSource;
        private System.Windows.Forms.Button Teambutadd;
        private System.Windows.Forms.Button Teambtnedit;
        private System.Windows.Forms.Button Teambtndelete;
        private System.Windows.Forms.Button Teambtnitem;
        private System.Windows.Forms.ListBox listItem;
    }
}