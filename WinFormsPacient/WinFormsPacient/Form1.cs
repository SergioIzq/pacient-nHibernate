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
                    Patient pacient = new Patient
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

        private void btnModificar_Click(object sender, EventArgs e)
        {
           // string nombre = txtName.Text;
            //int edad = int.Parse(txtAge.Text);

            try
            {
                using (ISession session = _sessionFactory.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {

                        var paciente = session.QueryOver<Patient>().Where(q => q.id == 3).SingleOrDefault();

                        if (paciente != null)
                        {
                            paciente.name = "Nini";
                            paciente.ListaVisitas.Add(new VisitaPaciente() { Patient = paciente, Motivo = string.Format("Visita número {0}.", paciente.ListaVisitas.Count +1) });
                            session.Update(paciente);
                            transaction.Commit();
                        }

                        
                    }
                }
                //MessageBox.Show("Paciente creado exitosamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string nombre = txtName.Text;
            //int edad = int.Parse(txtAge.Text);

            try
            {
                using (ISession session = _sessionFactory.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {

                        var paciente = session.QueryOver<Patient>().Where(q => q.id == 2).SingleOrDefault();

                        if (paciente != null)
                        {
                            //paciente.name = "Nini";
                            //paciente.ListaVisitas.Add(new VisitaPaciente() { Patient = paciente, Motivo = string.Format("Visita número {0}.", paciente.ListaVisitas.Count + 1) });
                            session.Delete(paciente);
                            transaction.Commit();
                        }


                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}
