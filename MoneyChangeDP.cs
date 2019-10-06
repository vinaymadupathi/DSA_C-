using System;
using System.Collections;

namespace MoneyChangeProblem
{
    class MoneyChangeProblem
    {
		static Hashtable hashtable = new Hashtable();

        static void Main(string[] args)
        {
			int[] n = new int[3]{1, 3, 4};// lets say denominations are 1, 3, 4
			int m = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine(GetMinimumMoneyChange(n, m));
		}

		static int GetMinimumMoneyChange(int[] n, int m)
		{
			int min = 0;
			for(int i=0;i<n.Length;i++)
			{
				if(m == n[i])
					return 1;
				if(m-n[i] > 0)
				{
					int temp = (hashtable.ContainsKey(m-n[i]) ? (int)hashtable[m-n[i]] : GetMinimumMoneyChange(n, m-n[i])) + 1;
					if(min == 0 || temp < min)
						min = temp;
				}
			}
			hashtable.Add(m, min);
			return min;
		}
	}
}
