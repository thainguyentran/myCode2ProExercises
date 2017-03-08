using System;
using System.Collections.Generic;

namespace ShadyProgramming
{
    class Programs
    {
        public static void Main(string[] args)
        {   
            LeastRecentLyUsedCache l = new LeastRecentLyUsedCache(4);
            
            l.set("yamaha");
            l.set("kawaski");
            l.set("aprilia");
            l.set("bmw");

            Console.WriteLine("most recent value: " + l.front());
            Console.WriteLine("least recent value: " + l.back());
            Console.WriteLine("All value: ");
            l.dump();

            l.set("ducati");
            Console.WriteLine("most recent value: " + l.front());
            Console.WriteLine("least recent value: " + l.back());
            Console.WriteLine("All value: ");
            l.dump();

            l.set("kawaski");
            Console.WriteLine("most recent value: " + l.front());
            Console.WriteLine("least recent value: " + l.back());
            Console.WriteLine("All value: ");
            l.dump();

            l.set("bmw");
            Console.WriteLine("most recent value: " + l.front());
            Console.WriteLine("least recent value: " + l.back());
            Console.WriteLine("All value: ");
            l.dump();

            l.set("honda");
            Console.WriteLine("most recent value: " + l.front());
            Console.WriteLine("least recent value: " + l.back());
            Console.WriteLine("All value: ");
            l.dump();
        }
    }

    class LeastRecentLyUsedCache
    {
        private LinkedList<string> lru = new LinkedList<string>();
        private Dictionary<string, LinkedListNode<string>> tracker;
        private int size;
 
        public LeastRecentLyUsedCache(int capacity)
        {
            size = capacity;
            tracker = new Dictionary<string, LinkedListNode<string>>(capacity);
        }
 
        public void set(string word)
        {
            if (!tracker.ContainsKey(word))
            {
                if(tracker.Count == size)
                {
                    var bot = lru.Last.Value;
                    lru.RemoveLast();
                    tracker.Remove(bot);
                }
                tracker.Add(word,lru.First);
            }
            else 
            {
                lru.Remove(word);
                tracker[word] = lru.First;
            }
            lru.AddFirst(word);
        }
 
        public string front()
        {
            return lru.First.Value;
        }

        public string back()
        {
            return lru.Last.Value;
        }
 
        public void dump()
        {
            foreach (string v in lru)
                Console.WriteLine(v);
            Console.WriteLine();
        }
    }
}
