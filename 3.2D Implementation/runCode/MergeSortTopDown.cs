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

            
            int j = 0;
            for(int i = 0; i < num; i++)        
            {
                if (i < mid)
                {
                    leftArray[i] = array[i];
                }
                else
                {
                    rightArray[j] = array[i];
                    j++;
                }
            }

            MergeSort(leftArray, index, mid, comparer);
            MergeSort(rightArray, mid+1, num-mid, comparer);
            Merge(array, leftArray, rightArray, comparer);
        }

        private void Merge<K>(K[] array, K[] leftArray, K[] rightArray, IComparer<K> comparer) where K : IComparable<K>
        {
            int leftSize = array.Length / 2;
            int rightSize = array.Length - leftSize;

            int i = 0, l = 0, r = 0;
            while (l < leftSize && r < rightSize)
            {
                if (comparer.Compare(rightArray[r], leftArray[l]) > 0)
                {
                    array[i] = leftArray[l];
                    i++;
                    l++;
                }
                else
                {
                    array[i] = rightArray[r];
                    i++;
                    r++;
                    
                }
            }

            // case ONLY one element left
            while (l < leftSize)
            {
                array[i] = leftArray[l];
                i++;
                l++;
            }
            while (r < rightSize)
            {
                array[i] = rightArray[r];
                i++;
                r++;
            }
        }

        public void Swap<K>(K[] array, int a, int b)  where K : IComparable<K>
        {
            K temp = array[a];
            array[a] = array[b];
            array[b] = temp;
        }
    }
}
