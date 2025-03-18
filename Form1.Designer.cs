namespace DriversAndOrders
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.buttonSwitchList = new System.Windows.Forms.Button();
            this.dataGridViewDrivers = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.редактироватьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridViewOrders = new System.Windows.Forms.DataGridView();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.labelCurrentList = new System.Windows.Forms.Label();
            this.timerRefresh = new System.Windows.Forms.Timer(this.components);
            this.labelTitle = new System.Windows.Forms.Label();
            this.backupTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDrivers)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonSwitchList
            // 
            this.buttonSwitchList.Location = new System.Drawing.Point(38, 1175);
            this.buttonSwitchList.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.buttonSwitchList.Name = "buttonSwitchList";
            this.buttonSwitchList.Size = new System.Drawing.Size(383, 65);
            this.buttonSwitchList.TabIndex = 0;
            this.buttonSwitchList.Text = "Переключить список";
            this.buttonSwitchList.UseVisualStyleBackColor = true;
            this.buttonSwitchList.Click += new System.EventHandler(this.buttonSwitchList_Click);
            // 
            // dataGridViewDrivers
            // 
            this.dataGridViewDrivers.BackgroundColor = System.Drawing.SystemColors.MenuHighlight;
            this.dataGridViewDrivers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDrivers.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridViewDrivers.Location = new System.Drawing.Point(38, 152);
            this.dataGridViewDrivers.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.dataGridViewDrivers.Name = "dataGridViewDrivers";
            this.dataGridViewDrivers.RowHeadersWidth = 123;
            this.dataGridViewDrivers.Size = new System.Drawing.Size(2457, 990);
            this.dataGridViewDrivers.TabIndex = 1;
            this.dataGridViewDrivers.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDrivers_CellContentClick);
            this.dataGridViewDrivers.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewDrivers_CellMouseDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.редактироватьToolStripMenuItem,
            this.удалитьToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(421, 182);
            // 
            // редактироватьToolStripMenuItem
            // 
            this.редактироватьToolStripMenuItem.Name = "редактироватьToolStripMenuItem";
            this.редактироватьToolStripMenuItem.Size = new System.Drawing.Size(420, 56);
            this.редактироватьToolStripMenuItem.Text = "Редактировать";
            this.редактироватьToolStripMenuItem.Click += new System.EventHandler(this.редактироватьToolStripMenuItem_Click);
            // 
            // удалитьToolStripMenuItem
            // 
            this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(420, 56);
            this.удалитьToolStripMenuItem.Text = "Удалить";
            this.удалитьToolStripMenuItem.Click += new System.EventHandler(this.удалитьToolStripMenuItem_Click);
            // 
            // dataGridViewOrders
            // 
            this.dataGridViewOrders.AllowUserToOrderColumns = true;
            this.dataGridViewOrders.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridViewOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOrders.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridViewOrders.Location = new System.Drawing.Point(38, 152);
            this.dataGridViewOrders.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.dataGridViewOrders.Name = "dataGridViewOrders";
            this.dataGridViewOrders.RowHeadersWidth = 123;
            this.dataGridViewOrders.Size = new System.Drawing.Size(2457, 990);
            this.dataGridViewOrders.TabIndex = 2;
            this.dataGridViewOrders.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewOrders_CellMouseDown);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(470, 1175);
            this.buttonAdd.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(238, 65);
            this.buttonAdd.TabIndex = 3;
            this.buttonAdd.Text = "Добавить";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Location = new System.Drawing.Point(758, 1175);
            this.buttonEdit.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(238, 65);
            this.buttonEdit.TabIndex = 4;
            this.buttonEdit.Text = "Изменить";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(1038, 1175);
            this.buttonDelete.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(238, 65);
            this.buttonDelete.TabIndex = 5;
            this.buttonDelete.Text = "Удалить";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // labelCurrentList
            // 
            this.labelCurrentList.AutoSize = true;
            this.labelCurrentList.Location = new System.Drawing.Point(47, 106);
            this.labelCurrentList.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.labelCurrentList.Name = "labelCurrentList";
            this.labelCurrentList.Size = new System.Drawing.Size(274, 37);
            this.labelCurrentList.TabIndex = 6;
            this.labelCurrentList.Text = "Список: Водители";
            // 
            // timerRefresh
            // 
            this.timerRefresh.Interval = 10000;
            this.timerRefresh.Tick += new System.EventHandler(this.timerRefresh_Tick);
            // 
            // labelTitle
            // 
            this.labelTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTitle.Location = new System.Drawing.Point(774, 29);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(749, 46);
            this.labelTitle.TabIndex = 7;
            this.labelTitle.Text = "Система управления заказами такси";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // backupTimer
            // 
            this.backupTimer.Enabled = true;
            this.backupTimer.Interval = 3600000;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(19F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2533, 1350);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.labelCurrentList);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.dataGridViewOrders);
            this.Controls.Add(this.dataGridViewDrivers);
            this.Controls.Add(this.buttonSwitchList);
            this.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDrivers)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrders)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSwitchList;
        private System.Windows.Forms.DataGridView dataGridViewDrivers;
        private System.Windows.Forms.DataGridView dataGridViewOrders;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Label labelCurrentList;
        private System.Windows.Forms.Timer timerRefresh;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem редактироватьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem;
        private System.Windows.Forms.Timer backupTimer;
    }
}