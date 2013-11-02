using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CPointSoftware.Equihira.Business.Catalogue;
using CPointSoftware.Equihira.Business.Catalogue.Data;
using CPointSoftware.Equihira.Business.ECommerce;
using CPointSoftware.Equihira.Business.ECommerce.Data;
using CPointSoftware.Equihira.Common;
using CPointSoftware.ECommerce.Tools;
using System.ComponentModel.Composition;

namespace ECommerce_Promo1
{
    [Export(typeof(IPromotionECommerce))]
    class PromotionDemo1 : IPromotionECommerce
    {
        #region IPromotionECommerce Membres

        public void Calculer(IPanierPourPromotions panier, DateTime? date)
        {
            Guid mon_art_guid_offert = new Guid("{56B1EB62-9190-4ED2-95A5-A871C59E4030}");
            bool dejaAjoute = false;
            foreach (var art in panier.Contenu)
            {
                if (art.ArticleGuid.Equals(mon_art_guid_offert))
                    dejaAjoute = true;
            }

            if (dejaAjoute)
                return;

            ElementPanier ma_ligne = panier.Ajouter(mon_art_guid_offert, 1, null) as ElementPanier;
            panier.DefinirPrix(ma_ligne.LigneGuid, 0, 0, 0, 0);
        }

        #endregion
    }
}
