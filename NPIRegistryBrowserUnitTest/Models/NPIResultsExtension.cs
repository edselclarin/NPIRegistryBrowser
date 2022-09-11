using System;
using System.Diagnostics;

namespace NPIRegistryBrowserUnitTest.Models
{
    public static class NPIResultsExtension
    {
        public static void DumpToDebugOutput(this SearchResults obj)
        {
            Debug.WriteLine($"Result Count: {obj.result_count}");
            Debug.WriteLine(String.Empty);

            Debug.WriteLine($"--- BASIC ({obj.results.Count} records) ---");
            foreach (var result in obj.results)
            {
                Debug.WriteLine($"Name: {result.basic.name_prefix} {result.basic.first_name} {result.basic.middle_name} {result.basic.last_name} {result.basic.name_suffix}");
                Debug.WriteLine($"Credential: {result.basic.credential}");
                Debug.WriteLine($"Sole Proprietor: {result.basic.sole_proprietor}");
                Debug.WriteLine($"Gender: {result.basic.gender}");
                Debug.WriteLine($"Enumeration Date: {result.basic.enumeration_date}");
                Debug.WriteLine($"Last Updated: {result.basic.last_updated}");
                Debug.WriteLine($"Status: {result.basic.status}");
                Debug.WriteLine(String.Empty);

                Debug.WriteLine($"--- ADDRESSES ({result.addresses.Count} records) ---");
                foreach (var addr in result.addresses)
                {
                    Debug.WriteLine(addr.address_1);
                    Debug.WriteLine($"{addr.city}, {addr.state} {addr.postal_code} {addr.country_name}");
                    Debug.WriteLine($"Country Code: {addr.country_code}");
                    Debug.WriteLine($"Tel: {addr.telephone_number}");
                    Debug.WriteLine($"Fax: {addr.fax_number}");
                    Debug.WriteLine($"Type: {addr.address_type}");
                    Debug.WriteLine($"Purpose: {addr.address_purpose}");
                }
                Debug.WriteLine(String.Empty);

                Debug.WriteLine($"--- PRACTICE LOCATIONS ({result.practiceLocations.Count} records) ---");
                foreach (var pl in result.practiceLocations)
                {
                    Debug.WriteLine(pl.address_1);
                    Debug.WriteLine($"{pl.city}, {pl.state} {pl.postal_code} {pl.country_name}");
                    Debug.WriteLine($"Country Code: {pl.country_code}");
                    Debug.WriteLine($"Tel: {pl.telephone_number}");
                    Debug.WriteLine($"Type: {pl.address_type}");
                    Debug.WriteLine($"Purpose: {pl.address_purpose}");
                }
                Debug.WriteLine(String.Empty);

                Debug.WriteLine($"--- TAXONOMIES ({result.taxonomies.Count} records) ---");
                foreach (var taxo in result.taxonomies)
                {
                    Debug.WriteLine($"Code: {taxo.code}");
                    Debug.WriteLine($"Taxonomy Group: {taxo.taxonomy_group}");
                    Debug.WriteLine($"Description: {taxo.desc}");
                    Debug.WriteLine($"State: {taxo.state}");
                    Debug.WriteLine($"License: {taxo.license}");
                    Debug.WriteLine($"Primary: {taxo.primary}");
                }
                Debug.WriteLine(String.Empty);

                Debug.WriteLine($"--- IDENTIFIERS ({result.identifiers.Count} records) ---");
                foreach (var ident in result.identifiers)
                {
                    Debug.WriteLine($"Code: {ident.code}");
                    Debug.WriteLine($"Description: {ident.desc}");
                    Debug.WriteLine($"Issuer: {ident.issuer}");
                    Debug.WriteLine($"Identifier: {ident.identifier}");
                    Debug.WriteLine($"State: {ident.state}");
                }
                Debug.WriteLine(String.Empty);

                Debug.WriteLine($"--- ENDPOINTS ({result.endpoints.Count} records) ---");
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
                }
                Debug.WriteLine(String.Empty);

                Debug.WriteLine($"--- OTHER NAMES ({result.other_names.Count} records) ---");
                foreach (var on in result.other_names)
                {
                    Debug.WriteLine($"Type: {on.type}");
                    Debug.WriteLine($"Code: {on.code}");
                    Debug.WriteLine($"First Name: {on.first_name}");
                    Debug.WriteLine($"Middle Name: {on.middle_name}");
                    Debug.WriteLine($"Lrst Name: {on.last_name}");
                    Debug.WriteLine($"credential: {on.credential}");
                }
                Debug.WriteLine(String.Empty);
            }
        }
    }
}
