using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace _06.TreeViewFromXml
{
    public partial class XmlTreeView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //First, we'll load the Xml document
                XmlDocument xDoc = new XmlDocument();
                //var di = new DirectoryInfo(Assembly..GetExecutingAssembly().Location);
                //var path = Path.Combine(di.Parent.Parent.FullName, "~/Test.xml");

                xDoc.Load(this.MapPath("Test.xml"));
                //Now, clear out the treeview, 
                //and add the first (root) node
                TreeViewXml.Nodes.Clear();
                TreeViewXml.Nodes.Add(new
                  TreeNode(xDoc.DocumentElement.Name));
                TreeNode tNode = new TreeNode();
                tNode = (TreeNode)TreeViewXml.Nodes[0];
                //We make a call to addTreeNode, 
                //where we'll add all of our nodes
                AddTreeNode(xDoc.DocumentElement, tNode);
                //Expand the treeview to show all nodes
                TreeViewXml.ExpandAll();
            }
        }

        //This function is called recursively until all nodes are loaded
        private void AddTreeNode(XmlNode xmlNode, TreeNode treeNode)
        {
            XmlNode xNode;
            TreeNode tNode;
            XmlNodeList xNodeList;
            if (xmlNode.HasChildNodes) //The current node has children
            {
                xNodeList = xmlNode.ChildNodes;
                for (int x = 0; x <= xNodeList.Count - 1; x++)
                //Loop through the child nodes
                {
                    xNode = xmlNode.ChildNodes[x];
                    treeNode.ChildNodes.Add(new TreeNode(xNode.Name));
                    tNode = treeNode.ChildNodes[x];
                    AddTreeNode(xNode, tNode);
                }
            }
            else
            {//No children, so add the outer xml (trimming off whitespace)
                treeNode.Text = Server.HtmlEncode(xmlNode.Name/* .OuterXml.Trim()*/);
                treeNode.Value = Server.HtmlEncode(xmlNode.OuterXml.Trim());
            }
        }

        protected void TreeViewXml_SelectedNodeChanged(object sender, EventArgs e)
        {
            this.LiteralDisplay.Text = (sender as TreeView).SelectedNode.Value;
        }
    }
}