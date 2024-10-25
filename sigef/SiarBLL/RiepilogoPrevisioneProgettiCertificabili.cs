
namespace SiarBLL
{
    public class RiepilogoPrevisioneProgettiCertificabili
    {
        public int _asse;
        public decimal _daIstruire;
        public decimal _daValidare;
        public decimal _daCertificare;

        public RiepilogoPrevisioneProgettiCertificabili() { }

        public RiepilogoPrevisioneProgettiCertificabili(int asse, decimal daIstruire, decimal daValidare, decimal daCertificare)
        {
            _asse = asse;
            _daIstruire = daIstruire;
            _daValidare = daValidare;
            _daCertificare = daCertificare;
        }

        public int Asse
        {
            get { return _asse; }
            set { _asse = value; }
        }

        public decimal DaIstruire
        {
            get { return _daIstruire; }
            set { _daIstruire = value; }
        }

        public decimal DaValidare
        {
            get { return _daValidare; }
            set { _daValidare = value; }
        }

        public decimal DaCertificare
        {
            get { return _daCertificare; }
            set { _daCertificare = value; }
        }
    }
}
