using Flurl;
using Flurl.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NPIRegistryBrowserUnitTest.Models;
using System;
using System.Diagnostics;

namespace NPIRegistryBrowserUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void LookupDoctor()
        {
            string baseurl = "https://npiregistry.cms.hhs.gov/api";

            var url = new Url(baseurl);

            var response = url
                .SetQueryParams(new
                {
                    version = "2.1",
                    first_name = "diana",
                    last_name = "albay",
                    number = "1477751691"
                })
                .GetJsonAsync<SearchResults>()
                .Result;

            foreach (var result in response.results)
            {
                Debug.WriteLine("--- BASIC ---");
                Debug.WriteLine($"Name: {result.basic.name_prefix} {result.basic.first_name} {result.basic.last_name}");
                Debug.WriteLine($"Credential: {result.basic.credential}");
                Debug.WriteLine($"Sole Proprietor: {result.basic.sole_proprietor}");
                Debug.WriteLine($"Gender: {result.basic.gender}");
                Debug.WriteLine($"Enumeration Date: {result.basic.enumeration_date}");
                Debug.WriteLine($"Last Updated: {result.basic.last_updated}");
                Debug.WriteLine($"Status: {result.basic.status}");
                Debug.WriteLine(String.Empty);
                Debug.WriteLine(String.Empty);

                Debug.WriteLine("--- ADDRESSES --");
                foreach (var addr in result.addresses)
                {
                    Debug.WriteLine(addr.address_1);
                    Debug.WriteLine($"{addr.city}, {addr.state} {addr.postal_code} {addr.country_name}");
                    Debug.WriteLine($"Country Code: {addr.country_code}");
                    Debug.WriteLine($"Tel: {addr.telephone_number}");
                    Debug.WriteLine($"Fax: {addr.fax_number}");
                    Debug.WriteLine($"Type: {addr.address_type}");
                    Debug.WriteLine($"Purpose: {addr.address_purpose}");
                    Debug.WriteLine(String.Empty);
                }
                Debug.WriteLine(String.Empty);
                Debug.WriteLine(String.Empty);

                Debug.WriteLine("--- PRACTICE LOCATIONS --");
                Debug.WriteLine("<< none >>");
                Debug.WriteLine(String.Empty);
                Debug.WriteLine(String.Empty);

                Debug.WriteLine("--- TAXONOMIES --");
                foreach (var taxo in result.taxonomies)
                {
                    Debug.WriteLine($"Code: {taxo.code}");
                    Debug.WriteLine($"Taxonomy Group: {taxo.taxonomy_group}");
                    Debug.WriteLine($"Description: {taxo.desc}");
                    Debug.WriteLine($"State: {taxo.state}");
                    Debug.WriteLine($"License: {taxo.license}");
                    Debug.WriteLine($"Primary: {taxo.primary}");
                    Debug.WriteLine(String.Empty);
                }
                Debug.WriteLine(String.Empty);
                Debug.WriteLine(String.Empty);

                Debug.WriteLine("--- IDENTIFIERS --");
                Debug.WriteLine("<< none >>");
                Debug.WriteLine(String.Empty);
                Debug.WriteLine(String.Empty);

                Debug.WriteLine("--- ENDPOINTS --");
                Debug.WriteLine(String.Empty);
                foreach (var ep in result.endpoints)
                {
                    Debug.WriteLine($"Endpoint Type: {ep.endpointType}");
                    Debug.WriteLine($"Endpoint Type Description: {ep.endpointTypeDescription}");
                    Debug.WriteLine($"Endpoint: {ep.endpoint}");
                    Debug.WriteLine($"Endpoint Description: {ep.endpointDescription}");
                    Debug.WriteLine($"Affiliation: {ep.affiliation}");
                    Debug.WriteLine($"Affiliation Name: {ep.affiliationName}");
                    Debug.WriteLine($"Use: {ep.use}");
                    Debug.WriteLine($"Use Description: {ep.useDescription}");
                    Debug.WriteLine($"Content Type: {ep.contentType}");
                    Debug.WriteLine($"Content Type Description: {ep.contentTypeDescription}");
                    Debug.WriteLine($"Content Other Description: {ep.contentOtherDescription}");
                    Debug.WriteLine($"Country Code: {ep.country_code}");
                    Debug.WriteLine($"Address Type: {ep.address_type}");
                    Debug.WriteLine(ep.address_1);
                    Debug.WriteLine($"{ep.city}, {ep.state} {ep.postal_code} {ep.country_name}");
                    Debug.WriteLine($"Country Code: {ep.country_code}");
                    Debug.WriteLine(String.Empty);
                }
                Debug.WriteLine(String.Empty);

                Debug.WriteLine("--- OTHER NAMES --");
                Debug.WriteLine("<< none >>");
                Debug.WriteLine(String.Empty);
                Debug.WriteLine(String.Empty);
            }
        }
    }
}
