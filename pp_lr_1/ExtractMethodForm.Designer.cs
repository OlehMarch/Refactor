namespace pp_lr_1
{
    partial class ExtractMethodForm
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
            this.TB_MethodName = new System.Windows.Forms.TextBox();
            this.B_Confirm = new System.Windows.Forms.Button();
            this.B_Close = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 12, 0, 0);
            this.label1.Size = new System.Drawing.Size(498, 60);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter method name:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TB_MethodName
            // 
            this.TB_MethodName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TB_MethodName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TB_MethodName.Location = new System.Drawing.Point(0, 60);
            this.TB_MethodName.MaxLength = 50;
            this.TB_MethodName.Name = "TB_MethodName";
            this.TB_MethodName.Size = new System.Drawing.Size(498, 29);
            this.TB_MethodName.TabIndex = 1;
            this.TB_MethodName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // B_Confirm
            // 
            this.B_Confirm.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.B_Confirm.Location = new System.Drawing.Point(165, 98);
            this.B_Confirm.Name = "B_Confirm";
            this.B_Confirm.Size = new System.Drawing.Size(75, 33);
            this.B_Confirm.TabIndex = 2;
            this.B_Confirm.Text = "Confirm";
            this.B_Confirm.UseVisualStyleBackColor = true;
            this.B_Confirm.Click += new System.EventHandler(this.B_Confirm_Click);
            // 
            // B_Close
            // 
            this.B_Close.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.B_Close.Location = new System.Drawing.Point(258, 98);
            this.B_Close.Name = "B_Close";
            this.B_Close.Size = new System.Drawing.Size(75, 33);
            this.B_Close.TabIndex = 3;
            this.B_Close.Text = "Close";
            this.B_Close.UseVisualStyleBackColor = true;
            this.B_Close.Click += new System.EventHandler(this.B_Close_Click);
            // 
            // ExtractMethodForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 143);
            this.Controls.Add(this.B_Close);
            this.Controls.Add(this.B_Confirm);
            this.Controls.Add(this.TB_MethodName);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ExtractMethodForm";
            this.Text = "Extract Method";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TB_MethodName;
        private System.Windows.Forms.Button B_Confirm;
        private System.Windows.Forms.Button B_Close;
    }
}