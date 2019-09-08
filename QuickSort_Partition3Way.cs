using System;

namespace QuickSort_3Way_Partition
{
    class Program
    {
        static void Main(string[] args)
        {
			int n = Convert.ToInt32(Console.ReadLine());
			int[] arr = Array.ConvertAll(Console.ReadLine().Trim().Split(' '), temp => Convert.ToInt32(temp));

			QuickSort(ref arr, 0, n-1);

			for(int i=0;i<n;i++)
			{
				Console.Write(arr[i] + " ");
			}
		}

		static void QuickSort(ref int[] arr, int low, int high)
		{
			if(low < high)
			{
				Tuple<int, int> pivot = Partition_3Way(ref arr, low, high);
                    
				QuickSort(ref arr, low, pivot.Item1);
				QuickSort(ref arr, pivot.Item2, high);
			}
		}

		static Tuple<int, int> Partition_3Way(ref int[] arr, int low, int high)
		{			
			int pivot = new Random().Next(low, high);
			int pivotElement = arr[pivot];
			swap(ref arr, high, pivot);
            pivot = high;

			int curIndex = low - 1;
			for(int i = low;i<=pivot-1;i++)
			{
                if(arr[i] == pivotElement)
                {
                    pivot = pivot - 1;
                    swap(ref arr, i, pivot);
                }
				if(arr[i] < pivotElement)
				{
					curIndex ++;
					swap(ref arr, i, curIndex);
				}
			}

			int m1 = curIndex;
			while(pivot<=high)
			{
				curIndex = curIndex + 1;
				swap(ref arr, curIndex, pivot);
				pivot = pivot + 1;
			}
			int m2 = curIndex+1;

			Tuple<int, int> tuple = new Tuple<int, int>(m1, m2);
			return tuple;
		}

		static void swap(ref int[] arr, int i, int j)
		{
			int temp = arr[i];
			arr[i] = arr[j];
			arr[j] = temp;
		}
	}		
}
