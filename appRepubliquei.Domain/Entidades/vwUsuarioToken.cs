using System;

namespace appRepubliquei.Domain.Entidades
{
    public class vwUsuarioToken
    {
        public string Email { get; set; }
        public string TokenTemp { get; set; }
        public DateTime DataToken { get; set; }
    }
}
