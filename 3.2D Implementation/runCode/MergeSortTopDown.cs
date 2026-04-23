namespace Vector
{
    public class MergeSortTopDown : ISorter
    {
        public void Sort<K>(K[] array, int index, int num, IComparer<K> comparer) where K : IComparable<K>
        {
           // exception
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

            // == MERGE SORT TOP-DOWN ==
            MergeSort(array, index, num, comparer);
            
        }

        private void MergeSort<K>(K[] array, int index, int num, IComparer<K> comparer) where K : IComparable<K>
        {
            // base case
            if (num <= 1) return;

            int mid = num / 2;
            K[] leftArray = new K[mid];
            K[] rightArray = new K[num - mid];

            for(int i = 0; i < num; i++)        
            {
                if (i < mid)
                {
                    leftArray[i] = array[index + i];
                }
                else
                {
                    rightArray[i - mid] = array[index + i];
                }
            }

            MergeSort(leftArray, 0, mid, comparer);
            MergeSort(rightArray, 0, num - mid, comparer);

            Merge(array, index, leftArray, rightArray, comparer);
        }

    private void Merge<K>(K[] array, int targetIndex, K[] leftArray, K[] rightArray, IComparer<K> comparer) where K : IComparable<K>
    {
        int i = 0, l = 0, r = 0;
        while (l < leftArray.Length && r < rightArray.Length)
        {
            if (comparer.Compare(leftArray[l], rightArray[r]) <= 0)
                array[targetIndex + i++] = leftArray[l++];
            else
                array[targetIndex + i++] = rightArray[r++];
        }

        while (l < leftArray.Length) array[targetIndex + i++] = leftArray[l++];
        while (r < rightArray.Length) array[targetIndex + i++] = rightArray[r++];
    }

        public void Swap<K>(K[] array, int a, int b)  where K : IComparable<K>
        {
            K temp = array[a];
            array[a] = array[b];
            array[b] = temp;
        }
    }
}
