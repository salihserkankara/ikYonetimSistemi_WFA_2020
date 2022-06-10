using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKYonetimSistemi.Models
{
    public class BSTNode
    {
        public NodeModel Data { get; set; }
        public BSTNode Left { get; set; } = null;
        public BSTNode Right { get; set; } = null;
        public BSTNode(NodeModel nodeModel)
        {
            Data = nodeModel;
        }
        public BSTNode()
        {

        }
    }
}
