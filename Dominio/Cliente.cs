using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemaVeterinaria_1._5
{
    internal class Cliente 
    {
        public string Nombre { get; set; }
        public int Sexo { get; set; }
        public int Codigo { get; set; }
        //public Mascota Mascota { get; set; }

        public Cliente(string nom, int sexo)
        {
            Nombre = nom;
            Sexo = sexo;
        }
        public Cliente()
        {

        }
        public override string ToString()
        {
            return $"Nombre: {Nombre} ";
        }

        

    }
}
