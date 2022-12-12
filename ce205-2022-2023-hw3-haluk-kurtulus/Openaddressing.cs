using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ce205_2022_2023_hw3_haluk_kurtulus
{
    public class OpenAddressing
    {
        public class hashnode
        {
            public int key;
            public string data;

            public hashnode(int key, string data)
            {
                this.key = key;
                this.data = data;
            }
        }
        public hashnode[] table;
        public OpenAddressing(int size)
        {
            table = new hashnode[size];
        }
        /// <summary>
        /// The code starts by creating a hash table called "table".
        ///The code then iterates through the list of keys, which are in the range from 0 to n-1.
 ///For each key, it creates an entry in the hash table with that key and data.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="data"></param>
        /// <param name="n"></param>
        
        public void OpenAddressingLinearProbingInsert(int key, string data, int n)
        {
            int index = key % n;
            while (table[index] != null)
            {
                index = (index + 1) % n;
            }
            table[index] = new hashnode(key, data);
        }
        /// <summary>
        /// The code is trying to find the index of a hashnode in an array.
        ///The code starts by finding the key that is being looked for, then it finds out how many times that key will be found in the table and divides by that number.
        ///If there are no more keys left, it creates a new hashnode with the key and data.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="data"></param>
        /// <param name="n"></param>
        public void OpenAddressingQuadraticProbingInsert(int key, string data, int n)
        {
            int index = key % n;
            int i = 1;
            while (table[index] != null)
            {
                index = (index + i * i) % n;
                i++;
            }
            table[index] = new hashnode(key, data);
        }
        /// <summary>
        /// The code opens the addressing double probing insert table and then iterates through each of its entries.
        ///The code starts by calculating the index of the key in the table, which is equal to(key % n) where n is an integer that represents how many times it will iterate through this loop.
        ///Then, it calculates prime using a while loop with a condition that checks if there are any values left in the table.
  /// </summary>
  /// <param name="key"></param>
  /// <param name="data"></param>
  /// <param name="n"></param>
        public void OpenAddressingDoubleProbingInsert(int key, string data, int n)
      
        {
            int index = key % n;
            int i = 1;
            int prime = 0;
            while (table[index] != null)
            {
                for (int j = 0; j < table.Length; j++)
                {
                    if (table[index] != null)
                    {
                        prime++;
                    }
                }
                index = (index + i * (prime - (key % prime)) % n);
                i++;
            }
            table[index] = new hashnode(key, data);
        }
    }
}
