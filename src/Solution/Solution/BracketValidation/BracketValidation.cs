using System;
using System.Threading.Channels;
using Solution.BrowserHistory;

namespace Solution.BracketValidation
{
    public class Node
    {
        public char Data {get;set;}
        public Node? Next {get;set;}

        public Node(char data)
        {
            Data = data;
            Next = null;
        }
    }

    public class StackManual
    {
        private Node? top;

        public StackManual()
        {
            top = null;
        }

        public void Push(char Bracket)
        {
            Node newNode = new Node(Bracket);
            newNode.Next = top;
            top = newNode;
        }

        public char? Pop()
        {
            if(top == null)
            {
                return null;
            }
            char temp = top.Data;
            top = top.Next;
            return temp;
        }

        public bool IsEmpty()
        {
            return top == null;
        }

    }

    public class BracketValidator
    {
        public bool ValidasiEkspresi(string ekspresi)
        {
            StackManual stack = new StackManual();
            
            foreach(char c in ekspresi)
            {
                if(c == '(' || c == '{' || c == '[')
                {
                    stack.Push(c);
                }
                else if(c == ')' || c == '}' || c == ']')
                {
                    char? lastBracket = stack.Pop();
                    if(lastBracket == null || !IsMatchingPair(lastBracket.Value, c))
                    {
                        return false;
                    }
                }
            }

            return stack.IsEmpty();
        }

        private bool IsMatchingPair(char open, char close)
        {
            return (open == '(' && close == ')') || (open == '{' && close == '}') || (open == '[' && close == ']');
        }
    }
}