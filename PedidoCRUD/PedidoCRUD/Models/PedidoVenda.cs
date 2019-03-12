//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjetoCRUD.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class PedidoVenda
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PedidoVenda()
        {
            this.ItemVenda = new HashSet<ItemVenda>();
        }
    
        public int seqPedVenda { get; set; }

        [Required, Display(Name = "NRO. EMPRESA")]
        public int nroEmpresa { get; set; }

        [Required, Display(Name = "NRO. PESSOA")]
        public int seqPessoa { get; set; }

        [Required, Display(Name = "DATA PEDIDO"), DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public System.DateTime dtaPedido { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItemVenda> ItemVenda { get; set; }
    }
}