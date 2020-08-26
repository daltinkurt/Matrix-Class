using System;

namespace DA
{
    public class Matrix<T>
    {
        private int n; // boyut sayısı
        private int[] d; // her bir boyuttaki eleman sayısı (d[0], d[1], ... , d[n-1])
        private T[] dizi; // tutulacak değerler
        private int max; // toplam eleman sayısı = d[0] x d[1] x d[2] x ... x d[n-1]

        /// <summary>
        /// Matrix boyutlarını vererek yeni bir matrix oluşturur
        /// </summary>
        /// <param name="x"></param>
        public Matrix(params int[] x) // boyutlar
        {
            Resize(x);
        }

        /// <summary>
        /// Boş matrix oluşturur
        /// </summary>
        public Matrix()
        {
            Clear();
        }

        /// <summary>
        /// Matrix'i sıfırlar
        /// </summary>
        public void Clear()
        {
            n = -1;
            d = null;
            dizi = null;
            max = 0;
        }

        private void Resize(params int[] x)
        {
            if (x.Length == 0) throw new Exception("Boyut hatası");
            n = x.Length;
            d = new int[n];
            max = 1;
            for (int i = 0; i < n; i++)
            {
                if (x[i] < 0) throw new Exception("Boyut hatası");
                d[i] = x[i];
                max *= d[i];
            }
            dizi = new T[max];
        }

        /// <summary>
        /// Matrix'in bir elemanının değerini döndürür
        /// </summary>
        /// <param name="x">Elemanın pozisyonu</param>
        /// <returns></returns>
        public T GetValue(params int[] x)
        {
            return dizi[Pos(x)];
        }

        /// <summary>
        /// Matrix'in bir elemanına değer atar.
        /// </summary>
        /// <param name="t">Değer</param>
        /// <param name="x">Elemanın pozisyonu</param>
        public void SetValue(T t, params int[] x)
        {
            dizi[Pos(x)] = t;
        }

        private int Pos(params int[] x)
        {
            if (n < 0) throw new Exception("Matrix hazır değil");
            if (x.Length != d.Length) throw new Exception("Boyut hatası");
            int pos = 0;
            for (int i = 0; i < n; i++)
            {
                if (x[i] >= d[i]) throw new Exception("Boyut hatası");
                int p = 1;
                for (int j = i + 1; j < n; j++)
                    p *= d[j];
                pos += x[i] * p;
            }
            return pos;
        }

        /// <summary>
        /// Matrix elemanlarına indexer üzerinden erişim
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public T this[int x]
        {
            get { return dizi[x]; }
            set { dizi[x] = value; }
        }

        /// <summary>
        /// Matrix elemanlarına indexer üzerinden erişim
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public T this[params int[] x]
        {
            get { return GetValue(x); }
            set { SetValue(value, x); }
        }

        /// <summary>
        /// Matrix'in eleman sayısı
        /// </summary>
        public int Length
        {
            get
            {
                return max;
            }
        }

        /// <summary>
        /// Matrix'in boyut sayısı
        /// </summary>
        public int GetDimension
        {
            get
            {
                if (n < 0) throw new Exception("Boyut hatası");
                return n;
            }
        }

        /// <summary>
        /// Matrix'in x. boyutunun eleman sayısı
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public int GetLength(int x)
        {
            if (n < 0 || n <= x) throw new Exception("Boyut hatası");
            if (n < 0) throw new Exception("Boyut hatası");
            return d[x];
        }
    }
}