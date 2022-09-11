using NPIRegistryBrowser.Models;
using NPIRegistryBrowser.Queries;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;

namespace NPIRegistryBrowser.ViewModels
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        private IList<TreeNode> _nodes;

        public event PropertyChangedEventHandler PropertyChanged;

        public string City { get; set; }
        public string State { get; set; }

        public IList<TreeNode> Nodes
        {
            get { return _nodes; }
            set
            {
                _nodes = value;

                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Nodes"));
            }
        }

        public MainViewModel()
        {
            City = "Irvine";
            State = "CA";
        }

        public void Search()
        {
            try
            {
                var qry = new CityStateQuery(City, State);
                var results = qry.Search();
                Nodes = BuildNodes(results.results.OrderBy(x => x.number));
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex);
            }
        }

        #region Implmentation
        private IList<TreeNode> BuildNodes(IEnumerable<Result> results)
        {
            var nodes = new List<TreeNode>();

            foreach (var res in results)
            {
                string name = BuildNameText(res.basic);
                if (String.IsNullOrEmpty(name))
                {
                    name = $"-- NPI Number: {res.number} --";
                }

                var node = new TreeNode()
                {
                    Text = name,
                    Children = BuildBasicNodes(res.number, res.basic)
                };

                int nAddresses = 1;
                foreach (var addr in res.addresses)
                {
                    var child = new TreeNode()
                    {
                        Text = $"Address {nAddresses++}",
                        Children = BuildAddressNodes(addr)
                    };

                    node.Children.Add(child);
                }

                int nPractices = 1;
                foreach (var pl in res.practiceLocations)
                {
                    var child = new TreeNode()
                    {
                        Text = $"Practice {nPractices++}",
                        Children = BuildPracticeNodes(pl)
                    };

                    node.Children.Add(child);
                }

                int nTaxonomies = 1;
                foreach (var tn in res.taxonomies)
                {
                    var child = new TreeNode()
                    {
                        Text = $"Taxonomy {nTaxonomies++}",
                        Children = BuildTaxonomyNodes(tn)
                    };

                    node.Children.Add(child);
                }

                int nIdentifiers = 1;
                foreach (var id in res.identifiers)
                {
                    var child = new TreeNode()
                    {
                        Text = $"Identifier {nIdentifiers++}",
                        Children = BuildIdentifierNodes(id)
                    };

                    node.Children.Add(child);
                }

                int nEndpoints = 1;
                foreach (var ep in res.endpoints)
                {
                    var child = new TreeNode()
                    {
                        Text = $"Endpoints {nEndpoints++}",
                        Children = BuildEndpointNodes(ep)
                    };

                    node.Children.Add(child);
                }

                int nOtherNames = 1;
                foreach (var on in res.other_names)
                {
                    var child = new TreeNode()
                    {
                        Text = $"Other Name {nOtherNames++}",
                        Children = BuildOtherNameNodes(on)
                    };

                    node.Children.Add(child);
                }

                nodes.Add(node);
            }

            return nodes;
        }

        private IList<TreeNode> BuildOtherNameNodes(OtherName on)
        {
            var nodes = new List<TreeNode>();

            nodes.Add(new TreeNode() { Text =$"Type: {on.type}" });
            nodes.Add(new TreeNode() { Text =$"Code: {on.code}" });
            nodes.Add(new TreeNode() { Text =$"First Name: {on.first_name}" });
            nodes.Add(new TreeNode() { Text =$"Middle Name: {on.middle_name}" });
            nodes.Add(new TreeNode() { Text =$"Lrst Name: {on.last_name}" });
            nodes.Add(new TreeNode() { Text =$"credential: {on.credential}" });

            return nodes;
        }

        private IList<TreeNode> BuildEndpointNodes(Endpoint ep)
        {
            var nodes = new List<TreeNode>();

            nodes.Add(new TreeNode() { Text = $"Endpoint Type: {ep.endpointType}" });
            nodes.Add(new TreeNode() { Text = $"Endpoint Type Description: {ep.endpointTypeDescription}" });
            nodes.Add(new TreeNode() { Text = $"Endpoint: {ep.endpoint}" });
            nodes.Add(new TreeNode() { Text = $"Endpoint Description: {ep.endpointDescription}" });
            nodes.Add(new TreeNode() { Text = $"Affiliation: {ep.affiliation}" });
            nodes.Add(new TreeNode() { Text = $"Affiliation Name: {ep.affiliationName}" });
            nodes.Add(new TreeNode() { Text = $"Use: {ep.use}" });
            nodes.Add(new TreeNode() { Text = $"Use Description: {ep.useDescription}" });
            nodes.Add(new TreeNode() { Text = $"Content Type: {ep.contentType}" });
            nodes.Add(new TreeNode() { Text = $"Content Type Description: {ep.contentTypeDescription}" });
            nodes.Add(new TreeNode() { Text = $"Content Other Description: {ep.contentOtherDescription}" });
            nodes.Add(new TreeNode() { Text = $"Address Type: {ep.address_type}" });
            nodes.Add(new TreeNode() { Text = ep.address_1 });
            nodes.Add(new TreeNode() { Text = $"{ep.city}, {ep.state} {ep.postal_code} {ep.country_name}" });
            nodes.Add(new TreeNode() { Text = $"{ep.country_name} ({ep.country_code})" });

            return nodes;
        }

        private IList<TreeNode> BuildIdentifierNodes(Identifier ident)
        {
            var nodes = new List<TreeNode>();

            nodes.Add(new TreeNode() { Text = $"Code: {ident.code}" });
            nodes.Add(new TreeNode() { Text = $"Description: {ident.desc}" });
            nodes.Add(new TreeNode() { Text = $"Issuer: {ident.issuer}" });
            nodes.Add(new TreeNode() { Text = $"Identifier: {ident.identifier}" });
            nodes.Add(new TreeNode() { Text = $"State: {ident.state}" });

            return nodes;
        }

        private IList<TreeNode> BuildTaxonomyNodes(Taxonomy taxo)
        {
            var nodes = new List<TreeNode>();

            nodes.Add(new TreeNode() { Text = $"Code: {taxo.code}" });
            nodes.Add(new TreeNode() { Text = $"Taxonomy Group: {taxo.taxonomy_group}" });
            nodes.Add(new TreeNode() { Text = $"Description: {taxo.desc}" });
            nodes.Add(new TreeNode() { Text = $"State: {taxo.state}" });
            nodes.Add(new TreeNode() { Text = $"License: {taxo.license}" });
            nodes.Add(new TreeNode() { Text = $"Primary: {taxo.primary}" });

            return nodes;
        }

        private IList<TreeNode> BuildPracticeNodes(PracticeLocation pl)
        {
            var nodes = new List<TreeNode>();

            nodes.Add(new TreeNode() { Text = pl.address_1 });
            nodes.Add(new TreeNode() { Text = $"{pl.city}, {pl.state} {pl.postal_code}" });
            nodes.Add(new TreeNode() { Text = $"{pl.country_name} ({pl.country_code})" });
            nodes.Add(new TreeNode() { Text = $"Tel: {pl.telephone_number}" });
            nodes.Add(new TreeNode() { Text = $"Type: {pl.address_type}" });
            nodes.Add(new TreeNode() { Text = $"Purpose: {pl.address_purpose}" });

            return nodes;
        }

        private IList<TreeNode> BuildAddressNodes(Address addr)
        {
            var nodes = new List<TreeNode>();

            nodes.Add(new TreeNode() { Text = $"{addr.address_1} {addr.address_2}" });
            nodes.Add(new TreeNode() { Text = $"{addr.city}, {addr.state} {addr.postal_code}" });
            nodes.Add(new TreeNode() { Text = $"{addr.country_name} ({addr.country_code})" });
            nodes.Add(new TreeNode() { Text = $"Tel: {addr.telephone_number}" });
            nodes.Add(new TreeNode() { Text = $"Fax: {addr.fax_number}" });
            nodes.Add(new TreeNode() { Text = $"Type: {addr.address_type}" });
            nodes.Add(new TreeNode() { Text = $"Purpose: {addr.address_purpose}" });

            return nodes;
        }

        private IList<TreeNode> BuildBasicNodes(string number, Basic basic)
        {
            var nodes = new List<TreeNode>();

            nodes.Add(new TreeNode() { Text = $"NPI Number: {number}" });
            nodes.Add(new TreeNode() { Text = $"Credential: {basic.credential}" });
            nodes.Add(new TreeNode() { Text = $"Sole Proprietor: {basic.sole_proprietor}" });
            nodes.Add(new TreeNode() { Text = $"Gender: {basic.gender}" });
            nodes.Add(new TreeNode() { Text = $"Enumeration Date: {basic.enumeration_date}" });
            nodes.Add(new TreeNode() { Text = $"Last Updated: {basic.last_updated}" });
            nodes.Add(new TreeNode() { Text = $"Status: {basic.status}" });

            return nodes;
        }

        private string BuildNameText(Basic basic)
        {
            string text = String.Empty;

            if (basic.name_prefix != null && basic.name_prefix != "--")
            {
                text += $"{basic.name_prefix} ";
            }

            text += $"{basic.first_name} ";

            if (basic.middle_name != null && basic.middle_name != "--")
            {
                text += $"{basic.middle_name} ";
            }

            text += $"{basic.last_name}";

            if (basic.name_suffix != null && basic.name_suffix != "--")
            {
                text += $" {basic.name_suffix}";
            }

            return text.Trim();
        }
        
        private void ShowExceptionMessage(Exception ex)
        {
            MessageBox.Show(ex.InnerException != null ? ex.InnerException.Message : ex.Message,
                Application.Current.MainWindow.Title, MessageBoxButton.OK, MessageBoxImage.Error);
        }
        #endregion
    }
}
