using NHibernate;
using NHibernate.Cfg;
using System.Reflection;

namespace WebApplication1
{
    public class NHibernateHelper
    {
        private static ISessionFactory _sessionFactory;

        public static NHibernate.ISession OpenSession()
        {
            if (_sessionFactory == null)
            {
                var configuration = new Configuration();
                configuration.Configure(); // Carga la configuración de NHibernate desde el archivo hibernate.cfg.xml
                configuration.AddAssembly(Assembly.GetExecutingAssembly()); 
                _sessionFactory = configuration.BuildSessionFactory();
            }
            return _sessionFactory.OpenSession();
        }
    }
}
