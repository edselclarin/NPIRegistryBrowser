using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPIRegistryBrowser.ViewModels
{
    internal class TreeNode
    {
        public string Text { get; set; }
        public IList<TreeNode> Children { get; set; }
    }
}
