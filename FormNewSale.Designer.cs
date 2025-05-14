namespace WindowsFormsAppAutoPartsStore
{
    partial class FormNewSale
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
            this.textBoxInfo = new System.Windows.Forms.TextBox();
            this.comboBoxProduct = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LabelPrise = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.HavingQuantity = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.richTextBoxWhatCarsIsItCompatibleWith = new System.Windows.Forms.RichTextBox();
            this.richTextBoxDescription = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSale = new System.Windows.Forms.Button();
            this.PriseOneProduct = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxInfo
            // 
            this.textBoxInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(237)))), ((int)(((byte)(240)))));
            this.textBoxInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxInfo.Location = new System.Drawing.Point(12, 12);
            this.textBoxInfo.Multiline = true;
            this.textBoxInfo.Name = "textBoxInfo";
            this.textBoxInfo.Size = new System.Drawing.Size(397, 46);
            this.textBoxInfo.TabIndex = 14;
            this.textBoxInfo.Text = "Добавление новой продажи";
            this.textBoxInfo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // comboBoxProduct
            // 
            this.comboBoxProduct.BackColor = System.Drawing.Color.White;
            this.comboBoxProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxProduct.FormattingEnabled = true;
            this.comboBoxProduct.Location = new System.Drawing.Point(88, 64);
            this.comboBoxProduct.Name = "comboBoxProduct";
            this.comboBoxProduct.Size = new System.Drawing.Size(316, 21);
            this.comboBoxProduct.TabIndex = 18;
            this.comboBoxProduct.SelectedIndexChanged += new System.EventHandler(this.comboBoxProduct_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 24);
            this.label1.TabIndex = 19;
            this.label1.Text = "Товар:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 497);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 31);
            this.label2.TabIndex = 20;
            this.label2.Text = "Цена:";
            // 
            // LabelPrise
            // 
            this.LabelPrise.AutoSize = true;
            this.LabelPrise.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelPrise.Location = new System.Drawing.Point(110, 497);
            this.LabelPrise.Name = "LabelPrise";
            this.LabelPrise.Size = new System.Drawing.Size(30, 31);
            this.LabelPrise.TabIndex = 21;
            this.LabelPrise.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(12, 172);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(230, 24);
            this.label3.TabIndex = 22;
            this.label3.Text = "Имеющиеся количество:";
            // 
            // HavingQuantity
            // 
            this.HavingQuantity.AutoSize = true;
            this.HavingQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.HavingQuantity.Location = new System.Drawing.Point(274, 175);
            this.HavingQuantity.Name = "HavingQuantity";
            this.HavingQuantity.Size = new System.Drawing.Size(18, 20);
            this.HavingQuantity.TabIndex = 23;
            this.HavingQuantity.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(12, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(259, 24);
            this.label4.TabIndex = 24;
            this.label4.Text = "Необходимое колличество:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(12, 206);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(260, 24);
            this.label5.TabIndex = 26;
            this.label5.Text = "Для каких машин подходит:";
            // 
            // richTextBoxWhatCarsIsItCompatibleWith
            // 
            this.richTextBoxWhatCarsIsItCompatibleWith.Location = new System.Drawing.Point(16, 233);
            this.richTextBoxWhatCarsIsItCompatibleWith.Name = "richTextBoxWhatCarsIsItCompatibleWith";
            this.richTextBoxWhatCarsIsItCompatibleWith.ReadOnly = true;
            this.richTextBoxWhatCarsIsItCompatibleWith.Size = new System.Drawing.Size(388, 98);
            this.richTextBoxWhatCarsIsItCompatibleWith.TabIndex = 27;
            this.richTextBoxWhatCarsIsItCompatibleWith.Text = "";
            // 
            // richTextBoxDescription
            // 
            this.richTextBoxDescription.Location = new System.Drawing.Point(16, 371);
            this.richTextBoxDescription.Name = "richTextBoxDescription";
            this.richTextBoxDescription.ReadOnly = true;
            this.richTextBoxDescription.Size = new System.Drawing.Size(393, 111);
            this.richTextBoxDescription.TabIndex = 28;
            this.richTextBoxDescription.Text = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(12, 344);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 24);
            this.label6.TabIndex = 29;
            this.label6.Text = "Описание:";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericUpDown1.Location = new System.Drawing.Point(277, 97);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 26);
            this.numericUpDown1.TabIndex = 30;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // buttonCancel
            // 
            this.buttonCancel.BackColor = System.Drawing.Color.White;
            this.buttonCancel.BackgroundImage = global::WindowsFormsAppAutoPartsStore.Properties.Resources.cancel;
            this.buttonCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonCancel.FlatAppearance.BorderSize = 0;
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCancel.Location = new System.Drawing.Point(214, 547);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(195, 36);
            this.buttonCancel.TabIndex = 16;
            this.buttonCancel.Text = "         Отмена";
            this.buttonCancel.UseVisualStyleBackColor = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            this.buttonCancel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonDown_MouseDown);
            this.buttonCancel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonUp_MouseUp);
            // 
            // buttonSale
            // 
            this.buttonSale.BackColor = System.Drawing.Color.White;
            this.buttonSale.BackgroundImage = global::WindowsFormsAppAutoPartsStore.Properties.Resources.accept;
            this.buttonSale.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonSale.FlatAppearance.BorderSize = 0;
            this.buttonSale.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSale.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSale.Location = new System.Drawing.Point(6, 547);
            this.buttonSale.Name = "buttonSale";
            this.buttonSale.Size = new System.Drawing.Size(195, 36);
            this.buttonSale.TabIndex = 15;
            this.buttonSale.Text = "        Продать";
            this.buttonSale.UseVisualStyleBackColor = false;
            this.buttonSale.Click += new System.EventHandler(this.buttonSale_Click);
            this.buttonSale.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonDown_MouseDown);
            this.buttonSale.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonUp_MouseUp);
            // 
            // PriseOneProduct
            // 
            this.PriseOneProduct.AutoSize = true;
            this.PriseOneProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PriseOneProduct.Location = new System.Drawing.Point(274, 137);
            this.PriseOneProduct.Name = "PriseOneProduct";
            this.PriseOneProduct.Size = new System.Drawing.Size(18, 20);
            this.PriseOneProduct.TabIndex = 32;
            this.PriseOneProduct.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(12, 134);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(213, 24);
            this.label8.TabIndex = 31;
            this.label8.Text = "Цена за одну еденицу:";
            // 
            // FormNewSale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 595);
            this.Controls.Add(this.PriseOneProduct);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.richTextBoxDescription);
            this.Controls.Add(this.richTextBoxWhatCarsIsItCompatibleWith);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.HavingQuantity);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LabelPrise);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxProduct);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSale);
            this.Controls.Add(this.textBoxInfo);
            this.MinimumSize = new System.Drawing.Size(434, 594);
            this.Name = "FormNewSale";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormNewSale";
            this.Load += new System.EventHandler(this.FormNewSale_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxInfo;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSale;
        private System.Windows.Forms.ComboBox comboBoxProduct;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LabelPrise;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label HavingQuantity;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox richTextBoxWhatCarsIsItCompatibleWith;
        private System.Windows.Forms.RichTextBox richTextBoxDescription;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label PriseOneProduct;
        private System.Windows.Forms.Label label8;
    }
}