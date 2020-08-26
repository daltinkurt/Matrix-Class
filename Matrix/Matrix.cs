using System;

namespace DA
{
    public class Matrix<T>
    {
        private int n; // boyut sayısı
        private int[] d; // her bir boyuttaki eleman sayısı (d[0], d[1], ... , d[n-1])
        private T[] dizi; // tutulacak değerler
        private int max; // toplam eleman sayısı = d[0] x d[1] x d[2] x ... x d[n-1]

        public Matrix(params int[] a) // boyutlar
        {
            Resize(a);
        }

        public Matrix()
        {
            Clear();
        }

        public void Clear()
        {
            n = -1;
            d = null;
            dizi = null;
            max = 0;
        }

        private void Resize(params int[] a)
        {
            if (a.Length == 0) throw new Exception("Boyut hatası");
            n = a.Length;
            d = new int[n];
            max = 1;
            for (int i = 0; i < n; i++)
            {
                if (a[i] < 0) throw new Exception("Boyut hatası");
                d[i] = a[i];
                max *= d[i];
            }
            dizi = new T[max];
        }

        public T GetValue(params int[] a)
        {
            return dizi[Pos(a)];
        }

        public void SetValue(T t, params int[] a)
        {
            dizi[Pos(a)] = t;
        }

        private int Pos(params int[] a)
        {
            if (n < 0) throw new Exception("Matrix hazır değil");
            if (a.Length != d.Length) throw new Exception("Boyut hatası");
            int pos = 0;
            for (int i = 0; i < n; i++)
            {
                if (a[i] >= d[i]) throw new Exception("Boyut hatası");
                int x = 1;
                for (int j = i + 1; j < n; j++)
                    x *= d[j];
                pos += a[i] * x;
            }
            return pos;
        }

        public T this[int a]
        {
            get { return dizi[a]; }
            set { dizi[a] = value; }
        }

        public T this[params int[] a]
        {
            get { return GetValue(a); }
            set { SetValue(value, a); }
        }

        public int Length
        {
            get
            {
                return max;
            }
        }

        public int GetDimension
        {
            get
            {
                if (n < 0) throw new Exception("Boyut hatası");
                return n;
            }
        }

        public int GetLength(int x)
        {
            if (n < 0 || n <= x) throw new Exception("Boyut hatası");
            if (n < 0) throw new Exception("Boyut hatası");
            return d[x];
        }
    }
}