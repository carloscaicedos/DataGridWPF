//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataGridWpf
{
    using System;
    using System.Collections.Generic;
    
    public partial class Publishers
    {
        public Publishers()
        {
            this.Books = new HashSet<Books>();
        }
    
        public int publisher_id { get; set; }
        public string name { get; set; }
        public string city { get; set; }
    
        public virtual ICollection<Books> Books { get; set; }
    }
}
