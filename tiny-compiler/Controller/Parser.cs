using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyCompiler.Model;

namespace TinyCompiler.Controller
{
    // Task I
    // todo custom exception
    // todo match()
    // todo display errors on the GUI

    // Task II
    // todo change rules to EBNF and implement their methods
    // todo implement methods: program stmt_sequence, statement, if_stmt, read_stmt, write_stmt, assign_stmt

    // Task III
    // todo change rules to EBNF and implement their methods 
    // *note law 3ayzin t2asemo el methods ma3 ba3d differently -> sure
    // todo repeat_stmt, exp, comparison_op, simple_exp, add_op, term, mul_op, factor

    // Task IV
    // todo display the tree on the screen and architect the tree data structure
    // todo implement methods to add to that Tree structure

    // Task V
    // todo implement the general Parser class structure and helping w/ task 4
    // todo architect the system we ay 7aga fadla 3mtn
    // ana wa5ed el task da xD



    class Parser
    {
        private List<Token> tokens;
        Token current_token = new Token();

        public Parser (List<Token> tokens)
        {
            this.tokens = tokens;
        }

        // change return type 
        public void getGraphData ()
        {

        }

        private TreeNode stmt_sequence ()
        {
            return new TreeNode();
        }
        private TreeNode statement ()
        {
            return new TreeNode();
        }

    }
}