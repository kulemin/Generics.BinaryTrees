using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics.BinaryTrees
{
    public class BinaryTree<T> : IEnumerable
        where T : IComparable
    {
        public T Value;
        public BinaryTree<T> Left;
        public BinaryTree<T> Right;
        public List<T> AllTree;
        public BinaryTree()
        {
            Value = default(T);
            Left = null;
            Right = null;
            AllTree = new List<T>();
        }

        public BinaryTree(T value, List<T> alltree)
        {
            Value = value;
            Left = null;
            Right = null;
            AllTree = alltree;
        }

        public void Initialize(T value)
        {
            Value = value;
            Right = null;
            Left = null;
            AllTree.Add(Value);
        }

        public void Add(T value)
        {
            if (Value.Equals(default(T)))
            {
                Initialize(value);
                return;
            }

            if (Value.CompareTo(value) >= 0)
            {
                ToTheBranch(ref Left, value);
            }

            else
            {
                ToTheBranch(ref Right, value);
            }
        }

        public void Add(T value, BinaryTree<T> sheet)
        {
            if (Value.Equals(default(T)))
            {
                sheet.Value = value;
                AllTree.Add(value);
                return;
            }

            if (sheet.Value.CompareTo(value) >= 0)
            {
                ToTheBranch(ref Left, value);
            }

            else
            {
                ToTheBranch(ref Right, value);
            }
        }

        public void ToTheBranch(ref BinaryTree<T> branch, T value)
        {
            if (branch == null)
            {
                branch = new BinaryTree<T>(value, AllTree);
                AllTree.Add(value);
            }
            else branch.Add(value, branch);
        }

        public IEnumerator GetEnumerator()
        {
            AllTree.Sort();
            for (int i = 0; i < AllTree.Count; i++)
                yield return AllTree[i];
        }

        public T First()
        {
            return Value;
        }
    }

    public class BinaryTree
    {
        public static BinaryTree<T> Create<T>(params T[] numbers)
        where T : IComparable
        {
            var tree = new BinaryTree<T>();
            foreach (var number in numbers)
            {
                tree.Add(number);
            }
            return tree;
        }
    }
}
