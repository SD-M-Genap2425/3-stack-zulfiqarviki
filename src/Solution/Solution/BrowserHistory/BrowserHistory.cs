using System;
using System.ComponentModel;

namespace Solution.BrowserHistory
{
    public class Halaman
    {
        public string URL {get;set;}

        public Halaman(string url)
        {
            URL = url;
        }
    }

    public class Node
    {
        public Halaman Data {get;set;}
        public Node? Next {get;set;}

        public Node(Halaman data)
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

        public void Push(Halaman halaman)
        {
            Node newNode = new Node(halaman);
            newNode.Next = top;
            top = newNode;
        }

        public Halaman? Pop()
        {
            if(top == null)
            {
                return null;
            }
            Halaman temp = top.Data;
            top = top.Next;
            return temp;
        }

        public Halaman? Peek()
        {
            return top?.Data;
        }

        public List<string> PrintHistory()
        {
            List<string> historyList = new List<string>();
            Node? current = top;
            int index = 1;
            while(current != null)
            {
                historyList.Insert(0, current.Data.URL);
                current = current.Next;
            }

            return historyList;

        }
    }

    public class HistoryManager
    {
        private StackManual history;
        private string lastVisited;

        public HistoryManager()
        {
            history = new StackManual();
            lastVisited = "Tidak ada halaman sebelumnya.";
        }

        public void KunjungiHalaman(string url)
        {
            if(history.Peek() != null)
            {
                lastVisited = history.Peek().URL;
            }
            Halaman halaman = new Halaman(url);
            history.Push(halaman);
        }

        public string Kembali()
        {
            Halaman? halamanSebelumnya = history.Pop();
            return halamanSebelumnya != null ? lastVisited : "Tidak ada halaman sebelumnya.";
        }

        public string LihatHalamanSaatIni()
        {
            Halaman? halamanSaatIni = history.Peek();
            return halamanSaatIni != null ? halamanSaatIni.URL : "Tidak ada halaman yang sedang dikunjungi.";
        }

        public void TampilkanHistory()
        {
            List<string> historyList = history.PrintHistory();
            foreach(string url in historyList)
            {
                Console.WriteLine(url);
            }
        }
    }
}