namespace practic_one_to_many
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
            this.butadd = new System.Windows.Forms.Button();
            this.butedit = new System.Windows.Forms.Button();
            this.butDeleted = new System.Windows.Forms.Button();
            this.butTeam = new System.Windows.Forms.Button();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.positionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.teamDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.playerBindingSource = new System.Windows.Forms.BindingSource(this.components);
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
            this.positionDataGridViewTextBoxColumn,
            this.ageDataGridViewTextBoxColumn,
            this.teamDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.playerBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(726, 271);
            this.dataGridView1.TabIndex = 0;
            // 
            // butadd
            // 
            this.butadd.Location = new System.Drawing.Point(24, 352);
            this.butadd.Name = "butadd";
            this.butadd.Size = new System.Drawing.Size(75, 23);
            this.butadd.TabIndex = 1;
            this.butadd.Text = "добавить";
            this.butadd.UseVisualStyleBackColor = true;
            this.butadd.Click += new System.EventHandler(this.butadd_Click);
            // 
            // butedit
            // 
            this.butedit.Location = new System.Drawing.Point(316, 352);
            this.butedit.Name = "butedit";
            this.butedit.Size = new System.Drawing.Size(75, 23);
            this.butedit.TabIndex = 2;
            this.butedit.Text = "изменить";
            this.butedit.UseVisualStyleBackColor = true;
            this.butedit.Click += new System.EventHandler(this.butedit_Click);
            // 
            // butDeleted
            // 
            this.butDeleted.Location = new System.Drawing.Point(645, 351);
            this.butDeleted.Name = "butDeleted";
            this.butDeleted.Size = new System.Drawing.Size(75, 23);
            this.butDeleted.TabIndex = 3;
            this.butDeleted.Text = "удалить";
            this.butDeleted.UseVisualStyleBackColor = true;
            this.butDeleted.Click += new System.EventHandler(this.butDeleted_Click);
            // 
            // butTeam
            // 
            this.butTeam.Location = new System.Drawing.Point(186, 394);
            this.butTeam.Name = "butTeam";
            this.butTeam.Size = new System.Drawing.Size(363, 23);
            this.butTeam.TabIndex = 4;
            this.butTeam.Text = "Команды";
            this.butTeam.UseVisualStyleBackColor = true;
            this.butTeam.Click += new System.EventHandler(this.butTeam_Click);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Личный индификационный ключ";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            // 
            // positionDataGridViewTextBoxColumn
            // 
            this.positionDataGridViewTextBoxColumn.DataPropertyName = "Position";
            this.positionDataGridViewTextBoxColumn.HeaderText = "Позиция игрока";
            this.positionDataGridViewTextBoxColumn.Name = "positionDataGridViewTextBoxColumn";
            // 
            // ageDataGridViewTextBoxColumn
            // 
            this.ageDataGridViewTextBoxColumn.DataPropertyName = "Age";
            this.ageDataGridViewTextBoxColumn.HeaderText = "Возраст футболиста";
            this.ageDataGridViewTextBoxColumn.Name = "ageDataGridViewTextBoxColumn";
            // 
            // teamDataGridViewTextBoxColumn
            // 
            this.teamDataGridViewTextBoxColumn.DataPropertyName = "Team";
            this.teamDataGridViewTextBoxColumn.HeaderText = "Команда футболиста";
            this.teamDataGridViewTextBoxColumn.Name = "teamDataGridViewTextBoxColumn";
            // 
            // playerBindingSource
            // 
            this.playerBindingSource.DataSource = typeof(practic_one_to_many.Player);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 429);
            this.Controls.Add(this.butTeam);
            this.Controls.Add(this.butDeleted);
            this.Controls.Add(this.butedit);
            this.Controls.Add(this.butadd);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button butadd;
        private System.Windows.Forms.Button butedit;
        private System.Windows.Forms.Button butDeleted;
        private System.Windows.Forms.Button butTeam;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn positionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ageDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn teamDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource playerBindingSource;
    }
}

