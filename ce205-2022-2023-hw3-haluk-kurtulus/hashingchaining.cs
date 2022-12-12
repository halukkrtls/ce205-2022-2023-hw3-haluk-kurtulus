using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ce205_2022_2023_hw3_haluk_kurtulus

{
    public class HashingChaining
    {
        public class hashnode
        {
            public int key;
            public string data;
            public hashnode next;
            public hashnode(int key, string data)
            {
                this.key = key;
                this.data = data;
                this.next = null;
            }
        }

        public LinkedList<hashnode>[] table;

        public HashingChaining(int size)
        {
            table = new LinkedList<hashnode>[size];
        }
        /// <summary>
        /// The code is trying to insert a new key into the hash table.
        ///The code starts by calculating the index of where it should be inserted in the hash table.
        ///If there is no value for that index, then it creates a new LinkedList and inserts it at that position.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public int HashingChainingInsert(int key, string data)
        {
            int index = key % table.Length;
            if (table[index] == null)
            {
                table[index] = new LinkedList<hashnode>();
                table[index].AddFirst(new hashnode(key, data));
                return 0;
            }
            else
            {
                foreach (hashnode node in table[index])
                {
                    if (node.key == key)
                    {
                        return -1;
                    }
                }
                table[index].AddFirst(new hashnode(key, data));
                return 0;
            }
        }
        /// <summary>
        /// The code starts by declaring a variable, index.
        ///The code then checks to see if the key is less than or equal to the length of the table.
        ///If it is not, then the code returns null.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string HashingChainingSearch(int key)
        {
            int index = key % table.Length;
            if (table[index] == null)
            {
                return null;
            }
            else
            {
                foreach (hashnode node in table[index])
                {
                    if (node.key == key)
                    {
                        return node.data;
                    }
                }
                return null;
            }
        }
        /// <summary>
        /// The code starts by declaring a variable called index.
        ///This is used to track the current position of the key in the table, which is then compared against 0.
        /// If it's not equal to 0, then it means that there are no more nodes in this particular position and so we can return -1.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public int HashingChainingDelete(int key)
        {
            int index = key % table.Length;
            if (table[index] == null)
            {
                return -1;
            }
            else
            {
                foreach (hashnode node in table[index])
                {
                    if (node.key == key)
                    {
                        table[index].Remove(node);
                        return 0;
                    }
                }
                return -1;
            }
        }
    }
}