namespace ServiciosEj1
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnTime = new System.Windows.Forms.Button();
            this.btnDate = new System.Windows.Forms.Button();
            this.btnAll = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtContra = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblResul = new System.Windows.Forms.Label();
            this.btnCambio = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnTime
            // 
            this.btnTime.Location = new System.Drawing.Point(149, 271);
            this.btnTime.Name = "btnTime";
            this.btnTime.Size = new System.Drawing.Size(75, 23);
            this.btnTime.TabIndex = 0;
            this.btnTime.Text = "time";
            this.btnTime.UseVisualStyleBackColor = true;
            this.btnTime.Click += new System.EventHandler(this.btnTime_Click);
            // 
            // btnDate
            // 
            this.btnDate.Location = new System.Drawing.Point(272, 271);
            this.btnDate.Name = "btnDate";
            this.btnDate.Size = new System.Drawing.Size(75, 23);
            this.btnDate.TabIndex = 1;
            this.btnDate.Text = "date";
            this.btnDate.UseVisualStyleBackColor = true;
            this.btnDate.Click += new System.EventHandler(this.btnTime_Click);
            // 
            // btnAll
            // 
            this.btnAll.Location = new System.Drawing.Point(405, 271);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(75, 23);
            this.btnAll.TabIndex = 2;
            this.btnAll.Text = "all";
            this.btnAll.UseVisualStyleBackColor = true;
            this.btnAll.Click += new System.EventHandler(this.btnTime_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(548, 271);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnTime_Click);
            // 
            // txtContra
            // 
            this.txtContra.Location = new System.Drawing.Point(149, 176);
            this.txtContra.Name = "txtContra";
            this.txtContra.Size = new System.Drawing.Size(100, 20);
            this.txtContra.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 179);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Contraseña:";
            // 
            // lblResul
            // 
            this.lblResul.AutoSize = true;
            this.lblResul.Location = new System.Drawing.Point(146, 63);
            this.lblResul.Name = "lblResul";
            this.lblResul.Size = new System.Drawing.Size(58, 13);
            this.lblResul.TabIndex = 6;
            this.lblResul.Text = "Resultado:";
            // 
            // btnCambio
            // 
            this.btnCambio.Location = new System.Drawing.Point(304, 361);
            this.btnCambio.Name = "btnCambio";
            this.btnCambio.Size = new System.Drawing.Size(147, 23);
            this.btnCambio.TabIndex = 7;
            this.btnCambio.Text = "Cambio IP/Puerto";
            this.btnCambio.UseVisualStyleBackColor = true;
            this.btnCambio.Click += new System.EventHandler(this.btnCambio_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCambio);
            this.Controls.Add(this.lblResul);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtContra);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAll);
            this.Controls.Add(this.btnDate);
            this.Controls.Add(this.btnTime);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Hora y fecha";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTime;
        private System.Windows.Forms.Button btnDate;
        private System.Windows.Forms.Button btnAll;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtContra;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblResul;
        private System.Windows.Forms.Button btnCambio;
    }
}

