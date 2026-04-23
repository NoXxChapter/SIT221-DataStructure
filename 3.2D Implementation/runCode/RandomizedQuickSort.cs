namespace Vector
{
    public class RandomizedQuickSort : ISorter
    {
        private Random _random = new Random();
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

            // == QUICK SORT ==
            QuickSort(array, index, index + num - 1, comparer);

        }

        private void QuickSort<K>(K[] array, int start, int end, IComparer<K> comparer) where K : IComparable<K>
        {
            if (end <= start)   return; // base case
            
            int randomIndex = _random.Next(start, end + 1);
            Swap(array, randomIndex, end); 

            int pivot = Partition(array, start, end, comparer);
            QuickSort(array, start, pivot - 1, comparer);
            QuickSort(array, pivot + 1, end, comparer);
        }

        private int Partition<K>(K[] array, int start, int end, IComparer<K> comparer) where K : IComparable<K>
        {
            K pivot = array[end];   // set pivot at last array's number
            int i = start - 1;

            for (int j = start; j <= end-1;j++)
            {
                if (comparer.Compare(pivot, array[j]) > 0)
                {
                    i++;
                    Swap(array, i, j);
                }
            }
            
            // final position of pivot
            i++;                    // get pivot position
            Swap(array, end, i);    // set pivot position

            return i;
        }

        private void Swap<K>(K[] array, int a, int b)  where K : IComparable<K>
            {
                K temp = array[a];
                array[a] = array[b];
                array[b] = temp;
            }
    }
}
