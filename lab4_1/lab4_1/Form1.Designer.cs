namespace lab4_1
{
    partial class frmPaint
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
            pnlPaintBox = new Panel();
            chckBxCtrl = new CheckBox();
            chckBxMode = new CheckBox();
            SuspendLayout();
            // 
            // pnlPaintBox
            // 
            pnlPaintBox.BackColor = SystemColors.ActiveCaption;
            pnlPaintBox.BorderStyle = BorderStyle.Fixed3D;
            pnlPaintBox.ImeMode = ImeMode.NoControl;
            pnlPaintBox.Location = new Point(12, 91);
            pnlPaintBox.Name = "pnlPaintBox";
            pnlPaintBox.Size = new Size(755, 350);
            pnlPaintBox.TabIndex = 0;
            pnlPaintBox.Paint += pnlPaintBox_Paint;
            pnlPaintBox.MouseClick += pnlPaintBox_MouseClick;
            // 
            // chckBxCtrl
            // 
            chckBxCtrl.AutoSize = true;
            chckBxCtrl.Location = new Point(12, 12);
            chckBxCtrl.Name = "chckBxCtrl";
            chckBxCtrl.Size = new Size(54, 24);
            chckBxCtrl.TabIndex = 1;
            chckBxCtrl.Text = "Ctrl";
            chckBxCtrl.UseVisualStyleBackColor = true;
            // 
            // chckBxMode
            // 
            chckBxMode.AutoSize = true;
            chckBxMode.Location = new Point(12, 42);
            chckBxMode.Name = "chckBxMode";
            chckBxMode.Size = new Size(104, 24);
            chckBxMode.TabIndex = 2;
            chckBxMode.Text = "MultiMode";
            chckBxMode.UseVisualStyleBackColor = true;
            // 
            // frmPaint
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(782, 453);
            Controls.Add(chckBxMode);
            Controls.Add(chckBxCtrl);
            Controls.Add(pnlPaintBox);
            KeyPreview = true;
            Name = "frmPaint";
            Text = "Paint Circle";
            TopMost = true;
            SizeChanged += frmPaint_SizeChanged;
            KeyDown += frmPaint_KeyDown;
            KeyUp += frmPaint_KeyUp;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private CheckBox chckBxMode;
        public Panel pnlPaintBox;
        public CheckBox chckBxCtrl;
    }
}