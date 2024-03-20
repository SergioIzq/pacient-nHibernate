using NHibernate;
using NHibernate.Cfg;
using System.Reflection;

namespace WinFormsPacient
{
    public class NHibernateHelper
    {
        private static ISessionFactory _sessionFactory;

        public static ISessionFactory GetSessionFactory()
        {
            if (_sessionFactory == null)
            {
                Configuration configuration = new Configuration()                    
                    .AddFile("Pacient.hbm.xml");
                configuration.Configure(); // Carga la configuración de NHibernate desde el archivo hibernate.cfg.xml


                _sessionFactory = configuration.BuildSessionFactory();
            }
            return _sessionFactory;
        }
    }
}
