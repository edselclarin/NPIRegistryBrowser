namespace NPIRegistryBrowserUnitTest.Models
{
    internal class NPISearchParams
    {
        public string version => "2.1";
        public string number { get; set; }
        public string enumeration_type { get; set; }
        public string taxonomy_description { get; set; }
        public string first_name { get; set; }
        public string use_first_name_alias { get; set; }
        public string last_name { get; set; }
        public string organization_name { get; set; }
        public string address_purpose { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string postal_code { get; set; }
        public string country_code { get; set; }
        public string limit { get; set; }
        public bool pretty { get; set; }
    }
}
