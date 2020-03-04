using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using storeEdy.Models;

namespace storeEdy.Controllers
{
    public class Item
    {

        private NewUrunler pr = new NewUrunler();

        public NewUrunler Pr { get => pr; set => pr = value; }
        

        private int quantity;
        public int Quantity { get => quantity; set => quantity = value; }


        public Item()
        { }

        public Item(NewUrunler product, int quantity)
        {
            this.pr = product;
            this.quantity = quantity;
        }
    }
}