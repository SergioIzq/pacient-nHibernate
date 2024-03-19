using NHibernate;
using NHibernate.Cfg;
using System.Reflection;

namespace WebApplication1
{
    public class PacientDto
    {
        public string name { get; set; }
    }

    public class Pacient
    {
        public virtual int id { get; set; }
        public virtual string name { get; set; }
    }

}
