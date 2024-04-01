
namespace WinFormsPacient

{
    public class Patient
    {
        public Patient()
        {

            //this._ListaVisitas = new List<VisitaPaciente>();
        }
        public virtual int id { get; set; }
        public virtual string name { get; set; }
        public virtual int age { get; set; }

        private IList<VisitaPaciente> _ListaVisitas = new List<VisitaPaciente>();
        public virtual IList<VisitaPaciente> ListaVisitas
        {
            get
            {
                return this._ListaVisitas;
            }
            set
            {
                this._ListaVisitas = value;
            }
        }

    }
}
