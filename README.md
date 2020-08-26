# Dynamic / Multidimensional / Generic Arrays

Not: c# ta düzensiz diziler (jagged arrays) de var biliyorum ama bu yazının konusu dışında kaldığından bundan bahsetmeyeceğim.

C# ta malumunuz tek boyutlu bir dizi şu şekilde tanımlanıyor:

<pre>int[] dizi1 = new int[10];</pre>

ya da iki ve üç boyutlu dizi tanımları şu şekilde:

<pre>int[,] dizi2 = new int[4, 3];
int[, ,] dizi3 = new int[4, 3, 2];</pre>

dizi elemanlarına değer atama:

<pre>dizi1[2] = 100;
dizi2[2,1] = 100;
dizi3[1,2,0] = 100;</pre>

dizi elemanlarına erişim:

<pre>var x1 = dizi1[2];
var x2 = dizi2[2,1];
var x3 = dizi3[1,2,0];</pre>

bu temel bilgilerden sonra yazdığım Matrix classının kullanımını aktarayım:  
(varsayılan olarak dizi elemanlarının int tipinde olduğunu varsayıyorum.)

dizi tanımlama:

<pre>// 10 elemanlı tek boyutlu dizi
Matrix<int> dizi1 = new Matrix<int>(10);

// iki boyutlu 4x3 lük dizi
Matrix<int> dizi2 = new Matrix<int>(4, 3);

// üç boyutlu 4x3x2 lik dizi
Matrix<int> dizi3 = new Matrix<int>(4, 3, 2);

// 10 boyutlu dizi
Matrix<int> dizi10 = new Matrix<int>(4, 3, 2, 3, 5, 4, 3, 4, 3, 7);
// :) örnekler arttırılabilir...</pre>

dizi elemanlarına erişim:  
(normal dizilerden farklı değil)

<pre>dizi1[4] = 50;
// veya
dizi1.SetValue(50, 4);
// ilk parametre: değer

dizi2[2, 1] = 100;
// veya
dizi2.SetValue(100, 2, 1);

dizi3[2, 2, 1] = 200;
// veya
dizi3.SetValue(200, 2, 2, 1);</pre>

dizi elemanlarına erişim yine normal dizilerle aynı:

<pre>var x = dizi1[4];
// veya
var x = dizi1.GetValue(4);

var y = dizi[2, 1];
// veya
var y = dizi2.GetValue(2, 1);

var z = dizi3[2, 2, 1];
// veya
var z = dizi3.GetValue(2, 2, 1);</pre>

Matrix classının diğer özellik ve metotları ise şunlar:

diziyi sıfırlama:

<pre>dizi1.Clear();</pre>

dizinin toplam eleman sayısını öğrenme:

<pre>var adet = dizi2.Length;</pre>

dizinin boyut sayısını öğrenme:

<pre>var dim = dizi.GetDimension;</pre>

x. boyuttaki eleman sayısını öğrenme:

<pre>var adetX = dizi.GetLength(0); // 0 indisli boyut
var adetY = dizi.GetLength(1); // 1 indisli boyut
// ...</pre>

Bonus:  
dizi kaç boyutlu olursa olsun class içerisinde tüm değerler tek boyutlu bir dizi içerisinde tutulmaktadır.  
boyut sayısına bağlı olarak dizinin istediğimiz bir konumundaki elemanına da erişebiliriz.  
örneğe geçmeden önce boyut matematiğini inceleyelim:

4x3x2 lik 3 boyutlu bir dizinin yapısı şu şekilde olmaktadır:

![](https://static.daltinkurt.com/upload/yazilar/2017/6/11/matrix-1.png)

İstediğimiz bir konumdaki elemanın, class içerisinde kullanılan tek boyutlu dizideki pozisyonunu öğrenmek için şu işlemi gerçekleştirmeliyiz:

örnek olarak 2x2x1 deki elemanın pozisyonunu öğrenmeye çalışalım:

X = 2  
Y = 2  
Z = 1

olmak üzere

her bir Y'de 2 elemanın,  
her bir X'te 3x2=6 elemanın olduğunu görüyoruz.

bu durumda 2x2x1 deki elemanın pozisyonu:  
(2 x 6) + (2 x 2) + 1  = 17 olur.

örnekler için resmi inceleyiniz:

![](https://static.daltinkurt.com/upload/yazilar/2017/6/11/matrix-2.png)

Gelelim pozisyonuna göre elemanlara erişim örneğine:

<pre>var x = dizi3[2, 2, 1];
// aşağıdaki kod da aynı elemana erişim sağlar
var x  = dizi3[17];</pre>

ya da değer atamak istersek:

<pre>dizi3[2, 2, 1] = 500;
// aşağıdaki kod da aynı işlemi yapar
dizi3[17] = 500;</pre>

Not:  
c# ta indisler -genel olarak- 0'dan başlar.  
klasik dizilerde indislerin alt ve üst değerleri farklı olabilir.  
(10 elemanlı bir dizinin indisleri -5..0..+4 olabilir.)

<pre>// A is [-5..4]  
Array A = Array.CreateInstance(typeof(int), new int[] { 10 }, new int[] { -5 });
int lower = A.GetLowerBound(0); // -5
int upper = A.GetUpperBound(0); // 4</pre>

Kullandığım Matrix classında ise bu durum göz ardı edilmiştir.
