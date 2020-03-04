using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace storeEdy.Models
{
    public class NewFisler
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int fisid { get; set; }

        public double fisTutar { get; set; }

        public DateTime tarih { get; set; }

        public int sepetoturumid { get; set; }

        public virtual SepetOturum SepetOturum { get; set; }
    }
}