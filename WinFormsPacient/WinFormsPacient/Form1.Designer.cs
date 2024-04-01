using NHibernate;
using System;
using System.Windows.Forms;

namespace WinFormsPacient
{
    partial class Form1 : Form
    {
        private System.ComponentModel.IContainer components;

        private Button btnSend;
        private Label Label1;
        private Label Label2;
        private TextBox txtName;
        private TextBox txtAge;

        public Form1()
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && components != null)
                {
                    components.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        private void InitializeComponent()
        {
            btnSend = new Button();
            Label1 = new Label();
            Label2 = new Label();
            txtName = new TextBox();
            txtAge = new TextBox();
            btnModificar = new Button();
            btnEliminar = new Button();
            SuspendLayout();
            // 
            // btnSend
            // 
            btnSend.Location = new Point(81, 261);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(75, 23);
            btnSend.TabIndex = 0;
            btnSend.Text = "Insertar";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // Label1
            // 
            Label1.AutoSize = true;
            Label1.Location = new Point(227, 130);
            Label1.Name = "Label1";
            Label1.Size = new Size(54, 15);
            Label1.TabIndex = 1;
            Label1.Text = "Nombre:";
            // 
            // Label2
            // 
            Label2.AutoSize = true;
            Label2.Location = new Point(227, 169);
            Label2.Name = "Label2";
            Label2.Size = new Size(36, 15);
            Label2.TabIndex = 2;
            Label2.Text = "Edad:";
            // 
            // txtName
            // 
            txtName.Location = new Point(308, 127);
            txtName.Name = "txtName";
            txtName.Size = new Size(227, 23);
            txtName.TabIndex = 3;
            // 
            // txtAge
            // 
            txtAge.Location = new Point(308, 169);
            txtAge.Name = "txtAge";
            txtAge.Size = new Size(56, 23);
            txtAge.TabIndex = 4;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(162, 261);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(75, 23);
            btnModificar.TabIndex = 0;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(243, 261);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 23);
            btnEliminar.TabIndex = 0;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtAge);
            Controls.Add(txtName);
            Controls.Add(Label2);
            Controls.Add(Label1);
            Controls.Add(btnEliminar);
            Controls.Add(btnModificar);
            Controls.Add(btnSend);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        private Button btnModificar;
        private Button btnEliminar;
    }
}
