using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Xml;
using System.Web;
using System.Web.SessionState;

public static class DataProvider {
    private const string SessionKey = "CountriesSampleDataSource";
    private const string XmlFileVirtPath = "~/App_Data/Countries.xml";

    private static HttpSessionState Session {
        get { return HttpContext.Current.Session; }
    }
    private static string CountiesXmlFilePhysPath {
        get { return HttpContext.Current.Request.MapPath(XmlFileVirtPath); }
    }

    public static IList<string> GetCountries() {
        IList<string> countries = (IList<string>)Session[SessionKey];
        if(countries == null) {
            countries = new ReadOnlyCollection<string>(LoadCountries());
            Session[SessionKey] = countries;
        }
        return countries;
    }

    private static List<string> LoadCountries() {
        List<string> result = new List<string>();
        XmlDocument doc = new XmlDocument();
        doc.Load(CountiesXmlFilePhysPath);
        if(doc.ChildNodes.Count <= 1)
            throw new System.IO.InvalidDataException("Unable to read data file.");
        XmlNode countriesRootNode = doc.ChildNodes[1];
        result.Capacity = countriesRootNode.ChildNodes.Count;
        foreach(XmlNode countryNode in countriesRootNode.ChildNodes)
            result.Add(countryNode.Attributes["name"].Value);
        return result;
    }
}