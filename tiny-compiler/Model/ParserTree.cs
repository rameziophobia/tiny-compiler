using Microsoft.Msagl.Drawing;
using Microsoft.Msagl.GraphViewerGdi;
using System.Linq;
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

            Node graphRootNode = graph.AddNode(rootTreeNode.ID);
            foreach (var node in rootTreeNode.Siblings)
            {
                graph.AddEdge(rootTreeNode.ID, node.ID);
                graph.LayerConstraints.AddSameLayerNeighbors(graph.FindNode(rootTreeNode.ID), graph.FindNode(node.ID));
                graph.FindNode(node.ID).LabelText = node.getDisplayLabel();
                graphRootNode.LabelText = rootTreeNode.getDisplayLabel();
                updateGraph(node);
            }
            foreach (var node in rootTreeNode.Children)
            {
                graph.AddEdge(rootTreeNode.ID, node.ID);
                graph.FindNode(node.ID).LabelText = node.getDisplayLabel();
                graphRootNode.LabelText = rootTreeNode.getDisplayLabel();
                updateGraph(node);
            }
            graphRootNode.LabelText = rootTreeNode.getDisplayLabel();
            graphRootNode.Attr.Shape = rootTreeNode.Shape;
            graphRootNode.Attr.FillColor = rootTreeNode.Color;

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
