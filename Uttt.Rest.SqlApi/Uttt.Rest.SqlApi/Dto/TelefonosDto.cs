using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Uttt.Rest.SqlApi.Dto
{
    public class TelefonosDto
    {
        public int Id { get; set; }
        public string TelefonoCelular { get; set; }
        public string TelefonoCasa { get; set; }
        public string Fax { get; set; }
        public List<PersonasDto> Personas { get; set; }
    }
}