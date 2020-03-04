using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace storeEdy.Models
{
    public class Sepet
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int sepetid { get; set; }

        public int sepetoturumid { get; set; }
        public virtual SepetOturum SepetOturumlar { get; set; }


        public int durum { get; set; }


        public int urunid { get; set; }
        public virtual NewUrunler NewUrunler { get; set; }
    }

}