using C4S.Model;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace C4S.Model
{
    [Table("Funktionen")]
    public class Funktion
    {
        public int Id { get; set; }
        public string Bezeichnung { get; set; }      

        public override string ToString()
        {
            return Bezeichnung;
        }
    }
}