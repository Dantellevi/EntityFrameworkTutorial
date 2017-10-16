namespace Practic_many_to_Many
{
    partial class Form1
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.addPl = new System.Windows.Forms.Button();
            this.butedit = new System.Windows.Forms.Button();
            this.butdelete = new System.Windows.Forms.Button();
            this.butaddTeam = new System.Windows.Forms.Button();
            this.playerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.positionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.ageDataGridViewTextBoxColumn,
            this.positionDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.playerBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(405, 157);
            this.dataGridView1.TabIndex = 0;
            // 
            // addPl
            // 
            this.addPl.Location = new System.Drawing.Point(12, 185);
            this.addPl.Name = "addPl";
            this.addPl.Size = new System.Drawing.Size(75, 23);
            this.addPl.TabIndex = 1;
            this.addPl.Text = "добавить";
            this.addPl.UseVisualStyleBackColor = true;
            this.addPl.Click += new System.EventHandler(this.addPl_Click);
            // 
            // butedit
            // 
            this.butedit.Location = new System.Drawing.Point(164, 185);
            this.butedit.Name = "butedit";
            this.butedit.Size = new System.Drawing.Size(94, 23);
            this.butedit.TabIndex = 2;
            this.butedit.Text = "редактировать";
            this.butedit.UseVisualStyleBackColor = true;
            this.butedit.Click += new System.EventHandler(this.butedit_Click);
            // 
            // butdelete
            // 
            this.butdelete.Location = new System.Drawing.Point(317, 185);
            this.butdelete.Name = "butdelete";
            this.butdelete.Size = new System.Drawing.Size(100, 23);
            this.butdelete.TabIndex = 3;
            this.butdelete.Text = "удалить";
            this.butdelete.UseVisualStyleBackColor = true;
            this.butdelete.Click += new System.EventHandler(this.butdelete_Click);
            // 
            // butaddTeam
            // 
            this.butaddTeam.Location = new System.Drawing.Point(112, 214);
            this.butaddTeam.Name = "butaddTeam";
            this.butaddTeam.Size = new System.Drawing.Size(190, 23);
            this.butaddTeam.TabIndex = 4;
            this.butaddTeam.Text = "добавить команду";
            this.butaddTeam.UseVisualStyleBackColor = true;
            this.butaddTeam.Click += new System.EventHandler(this.butaddTeam_Click);
            // 
            // playerBindingSource
            // 
            this.playerBindingSource.DataSource = typeof(Practic_many_to_Many.Player);
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
            this.nameDataGridViewTextBoxColumn.HeaderText = "Имя";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // ageDataGridViewTextBoxColumn
            // 
            this.ageDataGridViewTextBoxColumn.DataPropertyName = "Age";
            this.ageDataGridViewTextBoxColumn.HeaderText = "Возраст";
            this.ageDataGridViewTextBoxColumn.Name = "ageDataGridViewTextBoxColumn";
            // 
            // positionDataGridViewTextBoxColumn
            // 
            this.positionDataGridViewTextBoxColumn.DataPropertyName = "Position";
            this.positionDataGridViewTextBoxColumn.HeaderText = "Позиция";
            this.positionDataGridViewTextBoxColumn.Name = "positionDataGridViewTextBoxColumn";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 241);
            this.Controls.Add(this.butaddTeam);
            this.Controls.Add(this.butdelete);
            this.Controls.Add(this.butedit);
            this.Controls.Add(this.addPl);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button addPl;
        private System.Windows.Forms.Button butedit;
        private System.Windows.Forms.Button butdelete;
        private System.Windows.Forms.Button butaddTeam;
        private System.Windows.Forms.BindingSource playerBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ageDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn positionDataGridViewTextBoxColumn;
    }
}

