using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TrainTicketMachine.Bll.DataStructures
{
    /// <summary>
    ///     This class contains the implementation of a Prefix Tree data structure.
    /// </summary>
    public class PrefixTree : IPrefixTree
    {
        private readonly TreeNode _head;

        private readonly StringBuilder _stringBuilder = new StringBuilder();

        public PrefixTree()
        {
            _head = new TreeNode();
        }

        public async Task<IEnumerable<string>> FindAsync(string prefix)
        {
            var task = Task.Run(() => Find(prefix));
            return await task;
        }

        private IEnumerable<string> Find(string prefix)
        {
            if (prefix == null)
                throw new ArgumentNullException("prefix");
            prefix = prefix.ToUpper();

            _stringBuilder.Clear();

            TreeNode node = _head;
            foreach (char prefixChar in prefix)
            {
                TreeNode child = node.GetChild(prefixChar);
                node = child;

                if (child == null)
                    return new string[0];

                _stringBuilder.Append(prefixChar);
            }

            return node.GetChildsTerms(_stringBuilder.ToString());
        }

        public void Add(IEnumerable<string> terms)
        {
            foreach (string term in terms)
            {
                Add(term);
            }
        }

        private void Add(string term)
        {
            if (term == null)
                throw new ArgumentNullException("term");
            term = term.ToUpper();

            TreeNode node = _head;

            var prefixChars = new List<char>(term) { new char() };
            foreach (char prefixChar in prefixChars)
            {
                TreeNode child = node.GetChild(prefixChar);
                if (child == null)
                {
                    child = new TreeNode(prefixChar);
                    node.AddChild(child);
                }

                node = child;
            }
        }

        private class TreeNode
        {
            private readonly Dictionary<char, TreeNode> _treeNodes;

            #region Ctor

            public TreeNode()
            {
                _treeNodes = new Dictionary<char, TreeNode>();
            }

            public TreeNode(char c)
                : this()
            {
                Char = c;
            }

            #endregion

            private bool IsLeaf
            {
                get { return _treeNodes.Count == 0; }
            }

            private char Char { get; set; }

            public TreeNode GetChild(char c)
            {
                TreeNode node;
                _treeNodes.TryGetValue(c, out node);
                return node;
            }

            public void AddChild(TreeNode node)
            {
                _treeNodes.Add(node.Char, node);
            }

            public IEnumerable<string> GetChildsTerms(string term)
            {
                if (IsLeaf)
                    return new List<string> { term };

                var terms = new List<string>();

                foreach (var pair in _treeNodes)
                {
                    var tmpStringBuilder = new StringBuilder();
                    tmpStringBuilder.Append(term);

                    terms.AddRange(pair.Value.GetChildTermsInternal(tmpStringBuilder));
                }

                return terms;
            }

            private IEnumerable<string> GetChildTermsInternal(StringBuilder sb)
            {
                // Do not append the control char
                if (new char() != Char)
                    sb.Append(Char);

                if (IsLeaf)
                    return new[] { sb.ToString() };

                var terms = new List<string>();
                foreach (var treeNode in _treeNodes)
                {
                    terms.AddRange(treeNode.Value.GetChildTermsInternal(new StringBuilder(sb.ToString())));
                }

                return terms;
            }
        }
    }
}