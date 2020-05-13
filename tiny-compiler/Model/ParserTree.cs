using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Msagl.Drawing;
using System.Diagnostics;

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
        private void updateGraph(TreeNode rootTreeNode)
        {
            foreach (var node in rootTreeNode.Siblings)
            {
                graph.AddEdge(rootTreeNode.ID, node.ID);
                graph.FindNode(node.ID).LabelText = node.getDisplayLabel();
                graph.FindNode(rootTreeNode.ID).LabelText = rootTreeNode.getDisplayLabel();
                updateGraph(node);
            }

            foreach (var node in rootTreeNode.Children)
            {
                graph.AddEdge(rootTreeNode.ID, node.ID);
                graph.FindNode(node.ID).LabelText = node.getDisplayLabel();
                graph.FindNode(rootTreeNode.ID).LabelText = rootTreeNode.getDisplayLabel();
                updateGraph(node);
            }
            graph.FindNode(rootTreeNode.ID).Attr.Shape = rootTreeNode.Shape;
            graph.FindNode(rootTreeNode.ID).Attr.FillColor = rootTreeNode.Color;

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
