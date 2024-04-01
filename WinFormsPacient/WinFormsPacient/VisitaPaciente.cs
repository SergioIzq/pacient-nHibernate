
namespace WinFormsPacient

{
    public class VisitaPaciente
    {
        public virtual int Id { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual string Motivo { get; set; }

        private DateTime _FechaVisita = DateTime.Now;
        public virtual DateTime FechaVisita 
        { 
            get
            {
                return _FechaVisita;
            }
            set
            {
                _FechaVisita = value;
            }
        }
    }
}
