using System.Drawing;

namespace SiarBLL
{
    public class Legenda
    {
        private Color _colore;
        private string _testo;

        public Legenda() { }

        public Legenda(Color color, string text)
        {
            _colore = color;
            _testo = text;
        }

        public Color Colore
        {
            get { return _colore; }
            set { _colore = value; }
        }

        public string Testo
        {
            get { return _testo; }
            set { _testo = value; }
        }
    }
}
