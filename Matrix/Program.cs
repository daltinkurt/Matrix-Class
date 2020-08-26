using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DA
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix<int> dizi = new Matrix<int>(4, 3, 2);

            // değer atama
            dizi[2, 2, 1] = 500;
            dizi.SetValue(500, 2, 2, 1);

            // değer okuma
            var x = dizi[2, 2, 1];
            var x2 = dizi.GetValue(2, 2, 1);

            // sıfırlama
            //dizi.Clear();

            // elemanların pozisyonunu kullanma
            dizi[17] = 500;
            // aynısı
            dizi[2, 2, 1] = 400;


            // eleman sayısı
            var adet = dizi.Length;

            // Boyut sayısı
            var dim = dizi.GetDimension;

            // X. boyyuttaki eleman sayısı
            var adetX = dizi.GetLength(1);

            // dizinin tüm elemanlarını yazdırma
            for (int i = 0; i < dizi.Length; i++)
            {
                Console.Write(dizi[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
