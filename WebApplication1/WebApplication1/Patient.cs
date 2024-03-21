using NHibernate;
using NHibernate.Cfg;
using System.Reflection;

namespace WebApplication1
{
    public class PatientDto
    {
        public string name { get; set; }
        public int age { get; set; }

    }

    public class Patient
    {
        public virtual int id { get; set; }
        public virtual string name { get; set; }
        public virtual int age { get; set; }
    }

}
