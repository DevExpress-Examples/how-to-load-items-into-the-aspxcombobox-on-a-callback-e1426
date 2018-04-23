Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Web.UI
Imports DevExpress.Web.ASPxEditors
Imports DevExpress.Web.ASPxClasses

Namespace ComboBoxDelayedItemLoading
	Partial Public Class _Default
		Inherits Page
		Private Const DefaultCountryName As String = "United Kingdom"

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If (Not IsCallback) Then
				cbCountries.Items.Add(DefaultCountryName)
				cbCountries.SelectedIndex = 0
			End If
		End Sub

		Protected Sub OnCallback(ByVal source As Object, ByVal e As CallbackEventArgsBase)
			Dim counties As List(Of String) = New List(Of String)(DataProvider.GetCountries())
			counties.Remove(DefaultCountryName)
			CType(source, ASPxComboBox).Items.AddRange(counties)
		End Sub
	End Class
End Namespace