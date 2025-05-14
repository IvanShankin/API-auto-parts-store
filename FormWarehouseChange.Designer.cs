namespace WindowsFormsAppAutoPartsStore
{
    partial class FormWarehouseChange
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
            this.numericQuantityProduct = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.richTextBoxDescription = new System.Windows.Forms.RichTextBox();
            this.richTextBoxWhatCarsIsItCompatibleWith = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonConfirmation = new System.Windows.Forms.Button();
            this.textBoxInfo = new System.Windows.Forms.TextBox();
            this.textBoxPrise = new System.Windows.Forms.TextBox();
            this.textBoxProduct = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericQuantityProduct)).BeginInit();
            this.SuspendLayout();
            // 
            // numericQuantityProduct
            // 
            this.numericQuantityProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericQuantityProduct.Location = new System.Drawing.Point(277, 97);
            this.numericQuantityProduct.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericQuantityProduct.Name = "numericQuantityProduct";
            this.numericQuantityProduct.Size = new System.Drawing.Size(120, 26);
            this.numericQuantityProduct.TabIndex = 45;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(12, 304);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 24);
            this.label6.TabIndex = 44;
            this.label6.Text = "Описание:";
            // 
            // richTextBoxDescription
            // 
            this.richTextBoxDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBoxDescription.Location = new System.Drawing.Point(16, 331);
            this.richTextBoxDescription.Name = "richTextBoxDescription";
            this.richTextBoxDescription.Size = new System.Drawing.Size(393, 111);
            this.richTextBoxDescription.TabIndex = 43;
            this.richTextBoxDescription.Text = "";
            // 
            // richTextBoxWhatCarsIsItCompatibleWith
            // 
            this.richTextBoxWhatCarsIsItCompatibleWith.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBoxWhatCarsIsItCompatibleWith.Location = new System.Drawing.Point(16, 193);
            this.richTextBoxWhatCarsIsItCompatibleWith.Name = "richTextBoxWhatCarsIsItCompatibleWith";
            this.richTextBoxWhatCarsIsItCompatibleWith.Size = new System.Drawing.Size(388, 98);
            this.richTextBoxWhatCarsIsItCompatibleWith.TabIndex = 42;
            this.richTextBoxWhatCarsIsItCompatibleWith.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(12, 166);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(260, 24);
            this.label5.TabIndex = 41;
            this.label5.Text = "Для каких машин подходит:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(12, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(240, 24);
            this.label4.TabIndex = 40;
            this.label4.Text = "Имеющиеся колличество:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(193, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 24);
            this.label2.TabIndex = 36;
            this.label2.Text = "Цена:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 24);
            this.label1.TabIndex = 35;
            this.label1.Text = "Товар:";
            // 
            // buttonCancel
            // 
            this.buttonCancel.BackColor = System.Drawing.Color.White;
            this.buttonCancel.BackgroundImage = global::WindowsFormsAppAutoPartsStore.Properties.Resources.cancel;
            this.buttonCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonCancel.FlatAppearance.BorderSize = 0;
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCancel.Location = new System.Drawing.Point(220, 467);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(195, 36);
            this.buttonCancel.TabIndex = 33;
            this.buttonCancel.Text = "         Отмена";
            this.buttonCancel.UseVisualStyleBackColor = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            this.buttonCancel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonDown_MouseDown);
            this.buttonCancel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonUp_MouseUp);
            // 
            // buttonConfirmation
            // 
            this.buttonConfirmation.BackColor = System.Drawing.Color.White;
            this.buttonConfirmation.BackgroundImage = global::WindowsFormsAppAutoPartsStore.Properties.Resources.accept;
            this.buttonConfirmation.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonConfirmation.FlatAppearance.BorderSize = 0;
            this.buttonConfirmation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonConfirmation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonConfirmation.Location = new System.Drawing.Point(12, 467);
            this.buttonConfirmation.Name = "buttonConfirmation";
            this.buttonConfirmation.Size = new System.Drawing.Size(195, 36);
            this.buttonConfirmation.TabIndex = 32;
            this.buttonConfirmation.Text = "        Добавить";
            this.buttonConfirmation.UseVisualStyleBackColor = false;
            this.buttonConfirmation.Click += new System.EventHandler(this.buttonConfirmation_Click);
            this.buttonConfirmation.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonDown_MouseDown);
            this.buttonConfirmation.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonUp_MouseUp);
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
            this.textBoxInfo.TabIndex = 31;
            this.textBoxInfo.Text = "Добавление нового товара";
            this.textBoxInfo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxPrise
            // 
            this.textBoxPrise.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxPrise.Location = new System.Drawing.Point(277, 132);
            this.textBoxPrise.Multiline = true;
            this.textBoxPrise.Name = "textBoxPrise";
            this.textBoxPrise.Size = new System.Drawing.Size(120, 24);
            this.textBoxPrise.TabIndex = 46;
            this.textBoxPrise.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxPrise_KeyPress);
            // 
            // textBoxProduct
            // 
            this.textBoxProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxProduct.Location = new System.Drawing.Point(88, 61);
            this.textBoxProduct.Multiline = true;
            this.textBoxProduct.Name = "textBoxProduct";
            this.textBoxProduct.Size = new System.Drawing.Size(321, 24);
            this.textBoxProduct.TabIndex = 47;
            // 
            // FormWarehouseChange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 516);
            this.Controls.Add(this.textBoxProduct);
            this.Controls.Add(this.textBoxPrise);
            this.Controls.Add(this.numericQuantityProduct);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.richTextBoxDescription);
            this.Controls.Add(this.richTextBoxWhatCarsIsItCompatibleWith);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonConfirmation);
            this.Controls.Add(this.textBoxInfo);
            this.MaximumSize = new System.Drawing.Size(442, 555);
            this.MinimumSize = new System.Drawing.Size(442, 555);
            this.Name = "FormWarehouseChange";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormWarehouseChange";
            this.Load += new System.EventHandler(this.FormWarehouseChange_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericQuantityProduct)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericQuantityProduct;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox richTextBoxDescription;
        private System.Windows.Forms.RichTextBox richTextBoxWhatCarsIsItCompatibleWith;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonConfirmation;
        private System.Windows.Forms.TextBox textBoxInfo;
        private System.Windows.Forms.TextBox textBoxPrise;
        private System.Windows.Forms.TextBox textBoxProduct;
    }
}