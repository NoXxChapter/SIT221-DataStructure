namespace Vector
{
    public class BubbleSort : ISorter
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

            // === BUBBLE SORT ===
            for (int i=index; i<index+num-1; i++)
            {
                bool swapped = false;
                for (int j=index; j<index+num-i-1;j++)
                {
                    if (comparer.Compare(array[j], array[j+1]) > 0)
                    {
                        K temp = array[j];
                        array[j] = array[j+1];
                        array[j+1] = temp;
                        swapped = true;
                    }
                }
                // No SWAP then BREAK LOOP
                if(!swapped)    break;  
            }
        }
    }
}