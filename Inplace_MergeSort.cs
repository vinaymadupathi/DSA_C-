using System;

namespace MergeSort_Inplace
{
    class Program
    {
        static void Main(string[] args)
        {
			int n = Convert.ToInt32(Console.ReadLine());
			int[] arr = Array.ConvertAll(Console.ReadLine().Trim().Split(' '), temp => Convert.ToInt32(temp));

			MergeSort(ref arr, 0, n-1);

			for(int i=0;i<n;i++)
			{
				Console.Write(arr[i] + " ");
			}
		}

		static void MergeSort(ref int[] arr, int low, int high)
		{
			if(low < high)
			{
				int mid = (low + high)/2;
				MergeSort(ref arr, low, mid);
				MergeSort(ref arr, mid + 1, high);
				Merge(ref arr, low, mid, high);
			}
		}

		static void Merge(ref int[] arr, int low, int mid, int high)
		{
			int left_low = low;
			int left_high = mid;
			int right_low = mid + 1;
			int right_high = high;

			while(left_low <= left_high && right_low <= high)
			{
				if(arr[left_low] > arr[right_low])
				{
					swap(ref arr, left_low , right_low);
					left_low++;
					
					int j = right_low;
					while(j < right_high && arr[j] > arr[j+1])
					{
						swap(ref arr, j, j+1);
						j++;
					}
				}
				else
				{
					left_low++;
				}
			}
		}

		static void swap(ref int[] arr, int i, int j)
		{
			int temp = arr[i];
			arr[i] = arr[j];
			arr[j] = temp;
		}
	}		
}
