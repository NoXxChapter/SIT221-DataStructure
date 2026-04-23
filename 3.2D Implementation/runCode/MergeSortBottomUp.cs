namespace Vector
{
    public class MergeSortBottomUp : ISorter
    {
        public void Sort<K>(K[] array, int index, int num, IComparer<K> comparer) where K : IComparable<K>
        {
           // base case
            if (array == null)
            {
                throw new ArgumentNullException();
            }
            if (index < 0 || num < 0 )
            {
                throw new ArgumentException("Array null with index/num < 0");
            }
            if (index + num > array.Length)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (comparer == null)
            {
                comparer = Comparer<K>.Default;
            }

            // == MERGE SORT BOTTOM-UP ==
            MergeSort(array, index, num, comparer);
        }

        private void MergeSort<K>(K[] array, int index, int num, IComparer<K> comparer) where K : IComparable<K>
        {
            if (num <= 1) return;   // base case

            for (int width = 1; width < num; width *= 2)
            {
                for (int i = 0; i < num; i += 2 * width)
                {
                    int left = i;
                    int mid = Math.Min(i + width, num);
                    int right = Math.Min(i + 2 * width, num);

                    Merge(array, index, left, mid, right, comparer);
                }
            }
        }

        private void Merge<K>(K[] array, int index, int left, int mid, int right, IComparer<K> comparer) where K : IComparable<K>
        {
            int size = right - left;
            K[] temp = new K[size];
            
            int i = left;      
            int j = mid;       
            int k = 0;         
            while (i < mid && j < right)
            {
                if (comparer.Compare(array[index + i], array[index + j]) <= 0)
                {
                    temp[k++] = array[index + i++];
                }
                else
                {
                    temp[k++] = array[index + j++];
                }
            }

            // copy remaining elements
            while (i < mid) temp[k++] = array[index + i++];
            while (j < right) temp[k++] = array[index + j++];

            // copy back to the original array
            for (int n = 0; n < size; n++)
            {
                array[index + left + n] = temp[n];
            }
        }
    }
}