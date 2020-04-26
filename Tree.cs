using System;

namespace areyesram
{
    internal class Tree<T> where T : IComparable<T>
    {
        private Node<T> _root;

        public Tree()
        {
            _root = null;
        }

        public void Insert(T data)
        {
            if (_root == null)
            {
                _root = new Node<T>(data);
                return;
            }
            Insert(_root, new Node<T>(data));
        }

        private static void Insert(Node<T> root, Node<T> node)
        {
            if (root == null)
                root = node;

            var compare = node.Data.CompareTo(root.Data);

            if (compare == 0) return;

            if (compare < 0)
            {
                if (root.Left == null)
                    root.Left = node;
                else
                    Insert(root.Left, node);

            }
            else
            {
                if (root.Right == null)
                    root.Right = node;
                else
                    Insert(root.Right, node);
            }
        }

        internal bool Find(T data)
        {
            return Find(_root, data);
        }

        private static bool Find(Node<T> root, T data)
        {
            if (root == null)
                return false;
            var compare = data.CompareTo(root.Data);
            if (compare == 0) return true;
            if (compare < 0)
                return root.Left != null && Find(root.Left, data);
            else
                return root.Right != null && Find(root.Right, data);
        }

        internal void Traverse(Action<T> visit)
        {
            Traverse(_root, visit);
        }

        private static void Traverse(Node<T> root, Action<T> visit)
        {
            if (root == null) return;

            Traverse(root.Left, visit);
            visit(root.Data);
            Traverse(root.Right, visit);
        }
    }
}