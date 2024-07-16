using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContainers
{
	internal class Node<X>
	{
		public X Data { get; set; }
		public Node<X> Next { get; set; }
        public Node<X> Previous { get; set; }
        public Node(X value)
        {
            Data = value;
            Next = null;
            Previous = null;
        }
    }
}
