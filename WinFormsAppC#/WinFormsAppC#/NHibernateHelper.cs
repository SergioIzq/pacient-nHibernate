using NHibernate;
using NHibernate.Cfg;
using System.Reflection;

namespace WinFormsAppC
{
    public class NHibernateHelper
    {
        private static ISessionFactory _sessionFactory;

        public static ISessionFactory GetSessionFactory()
        {
            if (_sessionFactory == null)
            {
                var configuration = new Configuration();
                configuration.Configure(); // Carga la configuración de NHibernate desde el archivo hibernate.cfg.xml


                _sessionFactory = configuration.BuildSessionFactory();
            }
            return _sessionFactory;
        }
    }
}
