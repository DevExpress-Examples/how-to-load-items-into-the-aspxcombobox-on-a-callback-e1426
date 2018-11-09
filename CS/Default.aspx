<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ComboBoxDelayedItemLoading._Default" %>
<%@ Register Assembly="DevExpress.Web.v13.1" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <script type="text/javascript">
            function OnDropDown(s, e) {
    if(!s.countriesLoaded) {
        s.countriesLoaded = true;
        cbCountries.PerformCallback();
    }
}
        </script>
        <dxe:ASPxComboBox ID="cbCountries" runat="server" OnCallback="OnCallback" EnableIncrementalFiltering="True">
            <ClientSideEvents DropDown="OnDropDown" />
        </dxe:ASPxComboBox>
    </div>
    </form>
</body>
</html>
