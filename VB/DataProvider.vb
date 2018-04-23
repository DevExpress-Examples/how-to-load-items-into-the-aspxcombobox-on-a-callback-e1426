Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Xml
Imports System.Web
Imports System.Web.SessionState

Public NotInheritable Class DataProvider
	Private Const SessionKey As String = "CountriesSampleDataSource"
	Private Const XmlFileVirtPath As String = "~/App_Data/Countries.xml"

	Private Sub New()
	End Sub
	Private Shared ReadOnly Property Session() As HttpSessionState
		Get
			Return HttpContext.Current.Session
		End Get
	End Property
	Private Shared ReadOnly Property CountiesXmlFilePhysPath() As String
		Get
			Return HttpContext.Current.Request.MapPath(XmlFileVirtPath)
		End Get
	End Property

	Public Shared Function GetCountries() As IList(Of String)
		Dim countries As IList(Of String) = CType(Session(SessionKey), IList(Of String))
		If countries Is Nothing Then
			countries = New ReadOnlyCollection(Of String)(LoadCountries())
			Session(SessionKey) = countries
		End If
		Return countries
	End Function

	Private Shared Function LoadCountries() As List(Of String)
		Dim result As List(Of String) = New List(Of String)()
		Dim doc As New XmlDocument()
		doc.Load(CountiesXmlFilePhysPath)
		If doc.ChildNodes.Count <= 1 Then
			Throw New System.IO.InvalidDataException("Unable to read data file.")
		End If
		Dim countriesRootNode As XmlNode = doc.ChildNodes(1)
		result.Capacity = countriesRootNode.ChildNodes.Count
		For Each countryNode As XmlNode In countriesRootNode.ChildNodes
			result.Add(countryNode.Attributes("name").Value)
		Next countryNode
		Return result
	End Function
End Class