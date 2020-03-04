using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace storeEdy.Models
{
    public class SepetOturum
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int sepetoturumid { get; set; }

        public DateTime tarih { get; set; }

        public int durum { get; set; }

        public virtual List<Sepet> Sepets { get; set; }

    }
}