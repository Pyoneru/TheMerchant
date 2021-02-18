using System;
using System.Collections.Generic;
using System.Text;

namespace TheMerchant.Node
{
    public class Node
    {

        #region Properties

        public string Name { get; }

        #region References to neighbours

        public Node Parent { get; set; }

        public List<Node> Children { get; }

        #endregion References to neighbours

        #endregion Properties

        #region Constructors

        public Node(string name, Node parent = null, params Node[] children)
        {
            if (name == null)
                throw new ArgumentNullException("Name argument is null.");
            this.Name = name.ToLower();
            if (parent != null)
                this.Parent = parent;

            this.Children = new List<Node>();

            if(children.Length > 0)
            {
                foreach (Node child in children)
                {
                    this.Children.Add(child);
                }
            }
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Find first node without parent(This is root node)
        /// </summary>
        /// <returns>Root Node</returns>
        public Node GetRoot()
        {
            if (this.Parent == null) return this;

            Node root = this;
            while (root.Parent != null) root = root.Parent;
            return root;
        }

        public bool HasParent()
        {
            return this.Parent != null;
        }

        public bool HasAnyChild()
        {
            return this.Children.Count > 0;
        }

        public bool HasChild(string name)
        {
            if (name == null)
                throw new ArgumentNullException("Name argument is null.");
            return this.Children.Find(node => node.Name.Equals(name)) != null;
        }

        public int CountChildren(string name)
        {
            if (name == null)
                throw new ArgumentNullException("Name argument is null.");
            if (this.Children.Count == 0) return -1;
            return this.Children.FindAll(node => node.Name.Equals(name)).Count;
        }

        public bool OnlyChild(string name)
        {
            if (name == null)
                throw new ArgumentNullException("Name argument is null.");
            return CountChildren(name) == 1;
        }

        public Node GetChild(string name)
        {
            if (name == null)
                throw new ArgumentNullException("Name argument is null.");
            return this.Children.Find(node => node.Name.Equals(name));
        }

        public List<Node> GetChildren(string name)
        {
            if (name == null)
                throw new ArgumentNullException("Name argument is null.");
            return this.Children.FindAll(node => node.Name.Equals(name));
        }

        public bool IsRoot()
        {
            return this.Parent == null;
        }

        public bool IsNode(string name)
        {
            if (name == null)
                throw new ArgumentNullException("Name argument is null.");
            return this.Name.Equals(name.ToLower());
        }

        #endregion Methods



    }
}
