using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheMerchant.Node;
using System;
using System.Collections.Generic;

namespace NodeTests
{
    [TestClass]
    public class NodeTest
    {

        #region Constructors

        /// <summary>
        /// Check if after created node, Name prop is set on value given in constructor.
        /// </summary>
        [TestMethod]
        public void CreateNodeTest()
        {        
            // Create node
            Node node = new Node("world");


            // Name proprtie should be set on value given at constructor
            Assert.AreEqual("world", node.Name);

        }

        /// <summary>
        /// If argument in constructor will be null, should throw ArgumentNullException.
        /// </summary>
        [TestMethod]
        public void CreateNodeWithNullTest()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new Node(null));
        }

        /// <summary>
        /// Name argument in constructor should be transformed to lower case
        /// </summary>
        [TestMethod]
        public void CreateNodeUpperCaseTest()
        {
            Node node = new Node("NoDe");

            Assert.AreEqual("node", node.Name);
        }

        /// <summary>
        /// Check if parent is setting correct.
        /// </summary>
        [TestMethod]
        public void CreateNodeWithParentTest()
        {
            Node parent = new Node("parent");

            Node next = new Node("next", parent);

            Assert.AreEqual("parent", next.Parent.Name);
        }

        /// <summary>
        /// Test constructor with initalize children.
        /// </summary>
        [TestMethod]
        public void CreateNodeWithChildrenTest()
        {
            // list of name for children nodes.
            List<string> childrenName = new List<string>() { "child1", "child2", "child3", "child4" };

            Node[] children = new Node[childrenName.Count];

            // Initialize children
            for(int i = 0; i < childrenName.Count; i++)
            {
                children[i] = new Node(childrenName[i]);
            }

            Node node = new Node("node", null, children);

            // Test if children was correct initialized.
            for (int i = 0; i < node.Children.Count; i++)
            {
                Assert.AreEqual(childrenName[i], node.Children[i].Name);
                Assert.ReferenceEquals(children[i], node.Children[i]);
            }

        }
        
        #endregion Constructors

        #region Properties

        #region Parent

        /// <summary>
        /// Test Set Parent
        /// </summary>
        [TestMethod]
        public void ParentSetTest()
        {
            Node node = new Node("node");
            node.Parent = new Node("parent");

            Assert.AreEqual("parent", node.Parent.Name);
        }

        /// <summary>
        /// Test Get Parent
        /// </summary>
        [TestMethod]
        public void ParentGetTest()
        {
            Node parent = new Node("parent");
            Node node = new Node("node", parent);

            Assert.ReferenceEquals(parent, node.Parent);
        }

        /// <summary>
        /// Test Get Parent if no parent.
        /// </summary>
        [TestMethod]
        public void ParentGetNoInstanceTest()
        {
            Node node = new Node("node");

            Assert.IsNull(node.Parent);
        }

        #endregion Parent

        #region Children

        /// <summary>
        /// Children prop should be initialized in constructor
        /// </summary>
        [TestMethod]
        public void ChildrenNotNullAfterCreatedTest()
        {
            Node node = new Node("node");

            Assert.IsNotNull(node.Children);
        }

        /// <summary>
        /// You can manage list from Children propertie.
        /// </summary>
        [TestMethod]
        public void ChildrenManageFromPropertiesTest()
        {
            Node node = new Node("node");
            node.Children.Add(new Node("child"));

            Assert.AreEqual("child", node.Children[0].Name);
        }

        #endregion Children

        #endregion Properties

        #region Methods

        #region GetRoot

        /// <summary>
        /// GetRoot method should first Node without parent node.
        /// </summary>
        [TestMethod]
        public void GetRootTest()
        {   
            Node root = new Node("n");
            Node n = root;
            for (int i = 0; i < 10; i++)
                n = new Node("n" + (i + 1), n);

            Node getRoot = n.GetRoot();

            Assert.AreEqual("n", getRoot.Name);
            Assert.ReferenceEquals(root, getRoot);
        }


        /// <summary>
        /// If you invoke GetRoot in root, should return himself.
        /// </summary>
        [TestMethod]
        public void GetRootFromRootTest()
        {
            Node node = new Node("n");
            Node root = node.GetRoot();

            Assert.ReferenceEquals(node, root);
        }

        #endregion GetRoot

        #region HasParent

        /// <summary>
        /// Test HasParent method
        /// </summary>
        [TestMethod]
        public void HasParentTest()
        {
            Node parent = new Node("parent");
            Node node = new Node("node", parent);

            Assert.IsTrue(node.HasParent());
        }

        /// <summary>
        /// Root is a element in node tree without parent. So, HasParent should return always false in root element
        /// </summary>
        [TestMethod]
        public void HasParentInRootTest()
        {
            Node root = new Node("root");

            Assert.IsFalse(root.HasParent());
        }

        #endregion HasParent

        #region HasAnyChild

        /// <summary>
        /// If Children prop has any child return true(Count > 0)
        /// </summary>
        [TestMethod]
        public void HasAnyChildTest()
        {
            Node[] children = new Node[]
            {
                new Node("c1"),
                new Node("c2"),
                new Node("c3"),
            };
            Node node = new Node("node", null, children);

            Assert.IsTrue(node.HasAnyChild());
        }

        [TestMethod]
        public void HasAnyChildWithoutChildrenTest()
        {
            Node node = new Node("node");

            Assert.IsFalse(node.HasAnyChild());
        }

        #endregion HasAnyChild

        #region HasChild

        /// <summary>
        /// Check if Node contains child with given name.
        /// Method return true or false, so not return amount on children with given name.
        /// </summary>
        [TestMethod]
        public void HasChildTest()
        {
            Node[] children =
            {
                new Node("child1"),
                new Node("child2"),
                new Node("child3"),
                new Node("child4"),
                new Node("target"),
                new Node("child5"),
                new Node("child6"),

            };

            Node node = new Node("node", null, children);

            Assert.IsTrue(node.HasChild("target"));
        }

        /// <summary>
        /// If child has not given name, but this node has this name, can not return true.
        /// </summary>
        [TestMethod]
        public void HasChildNodeIsHimselftChildTest()
        {
            Node[] children =
            {
                new Node("child1"),
                new Node("child2"),
                new Node("child3"),
                new Node("child4"),
                new Node("target"),
                new Node("child5"),
                new Node("child6"),

            };

            Node node = new Node("node", null, children);

            Assert.IsFalse(node.HasChild("node"));
        }

        /// <summary>
        /// If node and his child has the same, return true, but it's why child with this name was found.
        /// </summary>
        [TestMethod]
        public void HasChildNodeAndChildHaveTheSameNameTest()
        {
            Node[] children =
            {
                new Node("child1"),
                new Node("child2"),
                new Node("child3"),
                new Node("child4"),
                new Node("node"),
                new Node("child5"),
                new Node("child6"),

            };

            Node node = new Node("node", null, children);

            Assert.IsTrue(node.HasChild("node"));
        }

        /// <summary>
        /// Throw ArugmentNullException if argument is null
        /// </summary>
        [TestMethod]
        public void HasChildNullNameTest()
        {
            Node node = new Node("node");

            Assert.ThrowsException<ArgumentNullException>(() => node.HasChild(null));
        }

        #endregion HasChild

        #region CountChildren

        /// <summary>
        /// Count children with the given name.
        /// Only one child with the name in this test.
        /// </summary>
        [TestMethod]
        public void CountChildrenTheOnetest()
        {
            Node[] children =
            {
                new Node("child1"),
                new Node("child2"),
                new Node("target"),
                new Node("child3"),
                new Node("child4"),
            };

            Node node = new Node("node", null, children);

            Assert.AreEqual(1, node.CountChildren("target"));
        }

        /// <summary>
        /// Count children with the given name.
        /// A few children with the name in this test.
        /// </summary>
        [TestMethod]
        public void CountChildrenAFewChildrenTest()
        {
            Node[] children =
            {
                new Node("chi"),
                new Node("child2"),
                new Node("chi"),
                new Node("child3"),
                new Node("chi"),
            };

            Node node = new Node("node", null, children);

            Assert.AreEqual(3, node.CountChildren("chi"));
        }

        /// <summary>
        /// If Children is empty should return -1
        /// </summary>
        [TestMethod]
        public void CountChildrenWithEmptyChildrenTest()
        {
            Node node = new Node("node");

            Assert.AreEqual(-1, node.CountChildren("node"));
        }

        /// <summary>
        /// If node has the same with his children, no count him 
        /// </summary>
        [TestMethod]
        public void CountChildrenNodeAndChildrenTheSameNameTest()
        {
            Node[] children =
            {
                new Node("node"),
                new Node("node"),
            };

            Node node = new Node("node", null, children);

            Assert.AreEqual(2, node.CountChildren("node"));
        }

        /// <summary>
        /// Throw ArugmentNullException if argument is null
        /// </summary>
        [TestMethod]
        public void CountChildrenNullNameTest()
        {
            Node node = new Node("node");

            Assert.ThrowsException<ArgumentNullException>(() => node.CountChildren(null));
        }

        #endregion CountChildren

        #region OnlyChild

        /// <summary>
        /// If node has only one child with given name, return true, otherwise return false
        /// </summary>
        [TestMethod]
        public void OnlyChildTest()
        {
            Node[] children =
            {
                new Node("child1"),
                new Node("child2"),
                new Node("target"),
                new Node("child3"),
                new Node("child4"),
            };

            Node node = new Node("node", null, children);

            Assert.IsTrue(node.OnlyChild("target"));
        }

        /// <summary>
        /// If node has more the one child with given name, return false
        /// </summary>
        [TestMethod]
        public void OnlyChildFewChildrenTheSameNameTest()
        {
            Node[] children =
            {
                new Node("child1"),
                new Node("target"),
                new Node("target"),
                new Node("child3"),
                new Node("child4"),
            };

            Node node = new Node("node", null, children);

            Assert.IsFalse(node.OnlyChild("target"));
        }

        /// <summary>
        /// If node and his child have the same name, return true if only child has the name
        /// node is not counting in this method
        /// </summary>
        [TestMethod]
        public void OnlyChildNodeAndChildTheSameNameTest()
        {
            Node[] children =
            {
                new Node("child1"),
                new Node("child2"),
                new Node("node"),
                new Node("child3"),
                new Node("child4"),
            };

            Node node = new Node("node", null, children);

            Assert.IsTrue(node.OnlyChild("node"));
        }

        /// <summary>
        /// Throw ArugmentNullException if argument is null 
        /// </summary>
        [TestMethod]
        public void OnlyChildNullNameTest()
        {
            Node node = new Node("node");

            Assert.ThrowsException<ArgumentNullException>(() => node.OnlyChild(null));
        }

        #endregion

        #region GetChild

        /// <summary>
        /// Get first child with given name from node.
        /// </summary>
        [TestMethod]
        public void GetChildTest()
        {
            Node[] children =
            {
                new Node("child1"),
                new Node("child2"),
                new Node("target"),
                new Node("child3"),
                new Node("child4"),
            };

            Node node = new Node("node", null, children);

            Assert.ReferenceEquals(children[2], node.GetChild("target"));
        }

        /// <summary>
        /// If node has more then one child with the given name, should return first
        /// </summary>
        [TestMethod]
        public void GetChildFirstChildTest()
        {
            Node[] children =
            {
                new Node("child1"),
                new Node("target"),
                new Node("target"),
                new Node("child3"),
                new Node("child4"),
            };

            Node node = new Node("node", null, children);

            Assert.ReferenceEquals(children[1], node.GetChild("target"));
        }

        /// <summary>
        /// If child with the name not found, should return null
        /// </summary>
        [TestMethod]
        public void GetChildNotFoundTest()
        {
            Node[] children =
            {
                new Node("child1"),
                new Node("target"),
                new Node("target"),
                new Node("child3"),
                new Node("child4"),
            };

            Node node = new Node("node", null, children);

            Assert.IsNull(node.GetChild("strawberry"));
        }

        /// <summary>
        /// Throw ArugmentNullException if argument is null
        /// </summary>
        [TestMethod]
        public void GetChildNullNameTest()
        {
            Node node = new Node("node");

            Assert.ThrowsException<ArgumentNullException>(() => node.GetChild(null));
        }

        #endregion GetChild

        #region GetChildren


        /// <summary>
        /// Return list of child with the given name.
        /// </summary>
        [TestMethod]
        public void GetChildrenTest()
        {
            Node[] children =
            {
                new Node("child1"),
                new Node("target"),
                new Node("target"),
                new Node("child3"),
                new Node("child4"),
            };

            Node node = new Node("node", null, children);

            IList<Node> found = node.GetChildren("target");

            Assert.IsFalse(found.Contains(children[0]));
            Assert.IsTrue(found.Contains(children[1]));
            Assert.IsTrue(found.Contains(children[2]));
            Assert.IsFalse(found.Contains(children[3]));
            Assert.IsFalse(found.Contains(children[4]));

            Assert.AreEqual(2, found.Count);
        }

        /// <summary>
        /// Node with the same name like his children is not given.
        /// </summary>
        [TestMethod]
        public void GetChildrenNodeAndChildrenTheSameNameTest()
        {
            Node[] children =
            {
                new Node("child1"),
                new Node("target"),
                new Node("node"),
                new Node("node"),
                new Node("node"),
            };

            Node node = new Node("node", null, children);

            List<Node> found = node.GetChildren("node");

            Assert.AreEqual(3, found.Count);
        }

        /// <summary>
        /// Given nodes should the same reference as children in node
        /// </summary>
        [TestMethod]
        public void GetChildrenReferenceTest()
        {
            Node[] children =
            {
                new Node("child1"),
                new Node("target"),
                new Node("childek"),
                new Node("child77"),
                new Node("child57"),
            };

            Node node = new Node("node", null, children);

            IList<Node> found = node.GetChildren("target");

            Assert.AreEqual(1, found.Count);
            Assert.ReferenceEquals(node.Children[1], found[0]);
        }

        /// <summary>
        /// If given argument is null throw ArgumentNullException
        /// </summary>
        [TestMethod]
        public void GetChildrenNullNameTest()
        {
            Node node = new Node("node");

            Assert.ThrowsException<ArgumentNullException>(() => node.GetChildren(null));
        }
        
        #endregion GetChildren

        #region IsRoot

        /// <summary>
        /// IsRoot should work reversely to HasParent. If node has not parent element then return true, otherwise return false.
        /// </summary>
        [TestMethod]
        public void IsRootWithParentElementTest()
        {
            Node node = new Node("node", new Node("parent"));

            Assert.IsFalse(node.IsRoot());
        }

        /// <summary>
        /// If node has not parent then IsRoot should return true.
        /// </summary>
        [TestMethod]
        public void IsRootTest()
        {
            Node root = new Node("root");

            Assert.IsTrue(root.IsRoot());
        }

        #endregion IsRoot

        #region IsNode

        /// <summary>
        /// Check if this node has name given at parameter
        /// </summary>
        [TestMethod]
        public void IsNodeTest()
        {
            Node node = new Node("node", new Node("parent"));

            Assert.IsFalse(node.IsNode("parent"));
            Assert.IsTrue(node.Parent.IsNode("parent"));
        }

        /// <summary>
        /// Should throw ArgumentNullException
        /// </summary>
        [TestMethod]
        public void IsNodeNullArgTest()
        {
            Node node = new Node("node");

            Assert.ThrowsException<ArgumentNullException>(() => node.IsNode(null));
        }

        /// <summary>
        /// If you give the same name as node but with upper case, should return true
        /// </summary>
        [TestMethod]
        public void IsNodeTheSameNameInUpperCasTest()
        {
            Node node = new Node("ala ma kota");

            Assert.IsTrue(node.IsNode("Ala Ma Kota"));
        }

        #endregion IsNode

        #endregion Methods
    }
}
