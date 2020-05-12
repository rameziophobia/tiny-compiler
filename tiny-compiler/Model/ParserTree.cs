using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Msagl.Drawing;

namespace TinyCompiler.Model
{
    class ParserTree
    {
        //create a form 
        private System.Windows.Forms.Form form = new System.Windows.Forms.Form();
        //create a viewer object 
        private Microsoft.Msagl.Drawing.Graph graph = new Microsoft.Msagl.Drawing.Graph();
        private Microsoft.Msagl.GraphViewerGdi.GViewer viewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();
        public ParserTree()
        {
            viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            form.Controls.Add(viewer);
        }
        public void makeGraph(TreeNode rootNode)
        {
            graph = new Microsoft.Msagl.Drawing.Graph();
            updateGraph(rootNode);
        }
        private void updateGraph(TreeNode rootNode)
        {
            foreach (var node in rootNode.Children)
            {
                graph.AddEdge(rootNode.Name, node.Name);
                updateGraph(node);
            }
            graph.FindNode(rootNode.Name).Attr.Shape = rootNode.Shape;
            graph.FindNode(rootNode.Name).Attr.FillColor = rootNode.Color;

        }
        private void updateView()
        {
            form.SuspendLayout();
            viewer.Graph = graph;
            form.ResumeLayout();
        }
        public void showForm()
        {
            updateView();
            form.WindowState = FormWindowState.Maximized;
            form.ShowDialog();
            
        }
       
    } 
}
