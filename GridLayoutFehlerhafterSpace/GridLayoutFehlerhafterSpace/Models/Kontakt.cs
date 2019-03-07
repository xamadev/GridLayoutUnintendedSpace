using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace C4S.Model
{
    [Table("Kontakte")]
    public class Kontakt
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None), Required]  //Primärschlüssel definieren => GID; 
        public string GID { get; set; }
        public string Name { get; set; }
        public string Vorname { get; set; }
        public string NameVorname => $"{Name}, {Vorname}";

        [Display(Name = "Telefon Büro Ländervorwahl")]
        public string TelefonOfficeLand { get; set; } = "0049";
        [Display(Name = "Telefon Büro Ortsvorwahl")]
        public string TelefonOfficeOrt { get; set; }
        [Display(Name = "Telefon Büro Nummer")]
        public string TelefonOfficeNummer { get; set; }
        [Display(Name = "Telefon Büro"), DataType(DataType.PhoneNumber)]
        public string TelefonOffice
        {
            get
            {
                if (string.IsNullOrEmpty(TelefonOfficeOrt) && string.IsNullOrEmpty(TelefonOfficeNummer))
                    return null;

                string _telefonOfficeLand = TelefonOfficeLand;

                //Ländervorwahl 00 durch +49 ersetzen
                if (Regex.IsMatch(TelefonOfficeLand, "^00"))
                {
                    _telefonOfficeLand = Regex.Replace(_telefonOfficeLand, "^00", "+");
                }

                return $"{_telefonOfficeLand} ({TelefonOfficeOrt}) {TelefonOfficeNummer}";
            }
        }

        [Display(Name = "Telefon Mobil Ländervorwahhl")]
        public string TelefonMobilLand { get; set; } = "0049";
        [Display(Name = "Telefon Mobil Vorwahl")]
        public string TelefonMobilOrt { get; set; }
        [Display(Name = "Telefon Mobil Nummer")]
        public string TelefonMobilNummer { get; set; }
        [Display(Name = "Telefon Mobil"), DataType(DataType.PhoneNumber)]
        public string TelefonMobil
        {
            get
            {
                if (string.IsNullOrEmpty(TelefonMobilOrt) && string.IsNullOrEmpty(TelefonMobilNummer))
                    return null;

                string _telefonMobilLand = TelefonMobilLand;

                if (Regex.IsMatch(TelefonMobilLand, "^00"))
                {
                    _telefonMobilLand = Regex.Replace(_telefonMobilLand, "^00", "+");
                }

                return $"{_telefonMobilLand} ({TelefonMobilOrt}) {TelefonMobilNummer}";
            }
        }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = "@siemens.com";
        [Display(Name = "Abteilung")]
        public string Department { get; set; }

        [Display(Name = "Land")]
        public string Country { get; set; } = "Deutschland";
        [Display(Name = "Ort")]
        public string Location { get; set; }
        public string LocationWithCountry
        {
            get
            {
                if (string.IsNullOrEmpty(Location))
                    return Country;

                return $"{Location}, {Country}";
            }
        }


        public byte[] Bild { get; set; }

        public override string ToString()
        {
            return $"{Name} {Vorname}";
        }
    }
}