using System;

namespace InversionCount
{
    class Program
    {
        static void Main(string[] args)
        {
			int n = Convert.ToInt32(Console.ReadLine());
			int[] arr = Array.ConvertAll(Console.ReadLine().Trim().Split(' '), temp => Convert.ToInt32(temp));

			Console.Write(MergeSort(ref arr, 0, n-1)); // Print inversion count.
		}

		static int MergeSort(ref int[] arr, int low, int high)
		{
			if(low < high)
			{
				int mid = (low + high)/2;
				return MergeSort(ref arr, low, mid) 
				+ MergeSort(ref arr, mid + 1, high) 
				+ Merge(ref arr, low, mid, high);
			}
			return 0;
		}

		static int Merge(ref int[] arr, int low, int mid, int high)
		{
			int inversionCount = 0;

			int left_low = low;
			int left_high = mid;
			int right_low = mid + 1;
			int right_high = high;

			while(left_low <= left_high && right_low <= high)
			{
				if(arr[left_low] > arr[right_low])
				{
					inversionCount ++;
					swap(ref arr, left_low , right_low);
					left_low++;
					
					int j = right_low;
					while(j < right_high && arr[j] > arr[j+1])
					{
						inversionCount ++;
						swap(ref arr, j, j+1);
						j++;
					}
				}
				else
				{
					left_low++;
				}
			}

			return inversionCount;
		}

		static void swap(ref int[] arr, int i, int j)
		{
			int temp = arr[i];
			arr[i] = arr[j];
			arr[j] = temp;
		}
	}		
}
