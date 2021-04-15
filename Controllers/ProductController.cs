using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace Net.Controllers {
    public class ProductController : Controller {
        /// <summary>
        ///  This function add product to Shopping cart without redirect to shopping cart.
        /// </summary>
        public ActionResult AddProduct (GiftProdList giftData)
        {
            var ShoppingList = Session["ShopCart"] as List<ShoppingCartList>;
            ShoppingList.Add(new ShoppingCartList { ProdDesc = giftData.GiftDesc , ProdID = giftData.GiftProdID , ProdPrice = giftData.GiftPrice , ProdPhotoURL = giftData.GiftPhotoURL , ProdTitle = giftData.GiftTitle });
            HttpContext.Session.Add("ShopCart" , ShoppingList);
            return Json(new { success = true , responseText = "Added to Cart" , countProductInCart = ShoppingList.Count } , JsonRequestBehavior.AllowGet);
        }
        

        /// <summary>
        ///  This function is remove product item from shopping Cart.
        /// </summary>
        public ActionResult RemoveProductFrmCart (string productId)
        {
            List<ShoppingCartList> ListProdSession = (List<ShoppingCartList>)Session["ShopCart"];
            if (ListProdSession != null) {
                var item = ListProdSession.Find(c => c.ProdID == productId);
                ListProdSession.Remove(item);
                Session["ShopCart"] = ListProdSession;
            }
            return RedirectToAction("ShoppingCart");
        }

        public ActionResult UpdateUserData (UpdateData UserData)
        {
            ///<summary>
            /// UserData is contains data like Id Number. This function is update this datas.
            /// </summary>

            if (UserData.fieldName == "IdNumber" && UserData.fieldValue.Length == 11) {
                
                /*
                *  Updates Process field, update process is can be using database or using model.
                *  This area is up to the programmer's preference.
                */
                return Json(new { success = true , responseText = "IdNumber updated" , newIdNumber = UserData.fieldValue } , JsonRequestBehavior.AllowGet);
            }
            return Json(new { success = false , responseText = "not updated" } , JsonRequestBehavior.AllowGet);
        }

    }
}