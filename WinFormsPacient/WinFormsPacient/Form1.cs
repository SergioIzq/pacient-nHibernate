using NHibernate;
using System;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WinFormsPacient
{
    public partial class Form1 : Form
    {
        private readonly ISessionFactory _sessionFactory;

        public Form1(ISessionFactory sessionFactory)
        {
            InitializeComponent();
            _sessionFactory = sessionFactory;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string nombre = txtName.Text;
            int edad = int.Parse(txtAge.Text);

            try
            {
                using (ISession session = _sessionFactory.OpenSession())
                using (ITransaction transaction = session.BeginTransaction())
                {
                    Pacient pacient = new Pacient
                    {
                        name = nombre,
                        age = edad
                    };

                    session.Save(pacient);
                    transaction.Commit();
                }

                MessageBox.Show("Paciente creado exitosamente");
            }
            catch (Exception ex)
            {
              MessageBox.Show($"Error: {ex.Message}");
           }
       }
    }
}
