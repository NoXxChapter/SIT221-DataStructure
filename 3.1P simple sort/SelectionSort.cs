namespace Vector
{
    public class SelectionSort : ISorter
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

            // === SELECTION SORT ===
            for (int i=index; i<index+num-1;i++)
            {
                int minIndex = i;
                for (int j=i+1; j<index+num;j++)
                {
                    if (comparer.Compare(array[minIndex],array[j]) > 0)
                    {
                        minIndex = j;
                    }
                }
                // swap min 
                K temp = array[i];
                array[i] = array[minIndex];
                array[minIndex] = temp;
            }
        }
    }
}