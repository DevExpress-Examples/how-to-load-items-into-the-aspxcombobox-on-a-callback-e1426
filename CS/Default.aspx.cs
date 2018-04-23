using System;
using System.Collections.Generic;
using System.Web.UI;
using DevExpress.Web.ASPxEditors;
using DevExpress.Web.ASPxClasses;

namespace ComboBoxDelayedItemLoading {
    public partial class _Default : Page {
        private const string DefaultCountryName = "United Kingdom";

        protected void Page_Load(object sender, EventArgs e) {
            if(!IsCallback) {
                cbCountries.Items.Add(DefaultCountryName);
                cbCountries.SelectedIndex = 0;
            }
        }

        protected void OnCallback(object source, CallbackEventArgsBase e) {
            List<string> counties = new List<string>(DataProvider.GetCountries());
            counties.Remove(DefaultCountryName);
            ((ASPxComboBox)source).Items.AddRange(counties);
        }
    }
}