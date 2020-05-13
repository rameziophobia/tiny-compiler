using Microsoft.Msagl.Drawing;
using Microsoft.Msagl.GraphViewerGdi;
using System.Windows.Forms;

namespace TinyCompiler.Model
{
    class ParserTree
    {
        private readonly Form form = new Form();
        private readonly GViewer viewer = new GViewer();
        private Graph graph = new Graph();

        public ParserTree()
        {
            viewer.Dock = DockStyle.Fill;
            form.Controls.Add(viewer);
        }

        public void makeGraph(TreeNode rootNode)
        {
            graph = new Graph();
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
            if (rootTreeNode.Children.Count == 0 && rootTreeNode.Siblings.Count == 0)
            {
                graph.AddNode(rootTreeNode.ID);
                graph.FindNode(rootTreeNode.ID).LabelText = rootTreeNode.getDisplayLabel();
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
