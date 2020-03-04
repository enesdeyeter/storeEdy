using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace storeEdy.Models
{
    public class NewUrunler
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Urunid { get; set; }

        [Required]
        [Display(Name = "Barkod Numarası")]
        //[MinLength(8, ErrorMessage = "Lütfen 8 haneli barkod numarasınız giriniz!"),MaxLength(8)]
        [Range(1, 99999999, ErrorMessage = "Lütfen 8 haneli barkod numarasınız giriniz!")]
        public string barkod { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Ürün Adı")]
        [MaxLength(30)]
        public string urunAd { get; set; }

        [Display(Name = "Ürün Açıklaması")]
        [MaxLength(50)]
        public string urunAciklama { get; set; }

        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        [Display(Name = "Ürün Fiyatı")]
        public Double urunFiyat { get; set; }


        public virtual List<Sepet> Sepets{ get; set; }


    }
}