namespace AmaToRa {
    partial class MainForm {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent() {
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ItemNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemTitleOverColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemDetailColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemDetailOverColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemImageColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.ItemPriceColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeleteButtonColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.button2 = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 40);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(135, 35);
            this.button1.TabIndex = 0;
            this.button1.Text = "情報DL";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(1129, 22);
            this.textBox1.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeight = 50;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ItemNameColumn,
            this.ItemTitleOverColumn,
            this.ItemDetailColumn,
            this.ItemDetailOverColumn,
            this.ItemImageColumn,
            this.ItemPriceColumn,
            this.DeleteButtonColumn});
            this.dataGridView1.Location = new System.Drawing.Point(12, 81);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 100;
            this.dataGridView1.Size = new System.Drawing.Size(1510, 739);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // ItemNameColumn
            // 
            this.ItemNameColumn.HeaderText = "商品名";
            this.ItemNameColumn.Name = "ItemNameColumn";
            this.ItemNameColumn.ReadOnly = true;
            this.ItemNameColumn.Width = 300;
            // 
            // ItemTitleOverColumn
            // 
            this.ItemTitleOverColumn.HeaderText = "品名超過";
            this.ItemTitleOverColumn.Name = "ItemTitleOverColumn";
            this.ItemTitleOverColumn.ReadOnly = true;
            this.ItemTitleOverColumn.Width = 50;
            // 
            // ItemDetailColumn
            // 
            this.ItemDetailColumn.HeaderText = "商品詳細";
            this.ItemDetailColumn.Name = "ItemDetailColumn";
            this.ItemDetailColumn.ReadOnly = true;
            this.ItemDetailColumn.Width = 400;
            // 
            // ItemDetailOverColumn
            // 
            this.ItemDetailOverColumn.HeaderText = "詳細超過";
            this.ItemDetailOverColumn.Name = "ItemDetailOverColumn";
            this.ItemDetailOverColumn.ReadOnly = true;
            this.ItemDetailOverColumn.Width = 50;
            // 
            // ItemImageColumn
            // 
            this.ItemImageColumn.HeaderText = "商品画像";
            this.ItemImageColumn.Name = "ItemImageColumn";
            this.ItemImageColumn.ReadOnly = true;
            // 
            // ItemPriceColumn
            // 
            this.ItemPriceColumn.HeaderText = "価格";
            this.ItemPriceColumn.Name = "ItemPriceColumn";
            this.ItemPriceColumn.ReadOnly = true;
            this.ItemPriceColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ItemPriceColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DeleteButtonColumn
            // 
            this.DeleteButtonColumn.HeaderText = "削除";
            this.DeleteButtonColumn.Name = "DeleteButtonColumn";
            this.DeleteButtonColumn.ReadOnly = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(425, 40);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(196, 35);
            this.button2.TabIndex = 3;
            this.button2.Text = "出力";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(665, 48);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 22);
            this.numericUpDown1.TabIndex = 4;
            this.numericUpDown1.Value = new decimal(new int[] {
            1500,
            0,
            0,
            0});
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(153, 40);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(134, 35);
            this.button3.TabIndex = 5;
            this.button3.Text = "全削除";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1534, 832);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Name = "MainForm";
            this.Text = "AmaToRa";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemTitleOverColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemDetailColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemDetailOverColumn;
        private System.Windows.Forms.DataGridViewImageColumn ItemImageColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemPriceColumn;
        private System.Windows.Forms.DataGridViewButtonColumn DeleteButtonColumn;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button button3;
    }
}

