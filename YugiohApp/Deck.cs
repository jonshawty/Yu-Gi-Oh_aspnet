//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace YugiohApp
{
    using System;
    using System.Collections.Generic;
    
    public partial class Deck
    {
        public int IdDeck { get; set; }
        public Nullable<int> UsuarioId { get; set; }
        public Nullable<int> CartaId { get; set; }
        public Nullable<int> TipoDeckId { get; set; }
        public string Descricao { get; set; }
    
        public virtual Carta Carta { get; set; }
        public virtual TipoDeck TipoDeck { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}