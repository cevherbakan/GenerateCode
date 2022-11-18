GENERATECODE

Bu projede 2 controller sınıfı oluşturudu aşağıda resimde görüldüğü gibidir.
![image](https://user-images.githubusercontent.com/53389814/202745988-700fca07-bd3e-4e38-8d5e-7fe9265869ef.png)
User kontrolü veritabanı ile yapılmaktadır.
User başarılı bir şekilde login olursa token üretiliyor diğer işlemlerde bu token kullanılıyor. Ve bu şekilde yetki kontrolü yapılmış oldu.

/api/Code/GetAllCode url i ile kodlar oluşturuluyor ve cevap olarak dönderiliyor. Burada normalde 10^7 code üretiliyor fakat rahat görülebilmesi için 5^7 olarak test amaçlı güncellendi.

/api/Code/CheckCode/{code} bu url ile kod kontrolü yapılmaktadır. Kodun algoritmaya uygun olup olmadığı servis tarafında kontrol edilip true veya false olarak cevap dönmektedir. Veritabanı ile bağlantı yapılmadan doğrudan algortima ile tespit edilmektedir.

/api/User/register Kullanıcı kaydı için kullanılmaktadır.

/api/User/login Token üretimi için kullanılmaktadır.

Algoritmanın Çalışma Mantığı

10.000.000 kod oluşturulması istendiği için döngüler toplamda 10^7 kere dönmektedir.
8 haneli ve ardışık olmayan kodların üretilmesi istendiği için izlenen yol şu şekildedir:
her bir hane için toplamda 10 adet karakter kümesi bulunmaktadır. Bu şekilde 7. haneye kadar sayı üretimi olmaktadır. 
Son hane yani 8.hane ise Bu 7 hanenin toplamının 10 a bölümünden kalanı alınarak oluşturulmaktadır. Bu şekilde 10^7  kadar code üretme sayısına ulaşılabiliyor. Ve son hane diğer hanelere bağlı olduğu için kod kontrolünde kullanılıyor.

Karakter kümesi ardışık olmaması için algoritmada izlenen yöntem şu şekildedir:
karakter kümemiz: ACDEFGHKLMNPRTXYZ234579
1.Hane : 0-9
2.Hane : 11-20
3.Hane : 1-10
4.Hane : 12-21
5.Hane : 2-11
6.Hane : 13-22
7.Hane : 3-12
8.Hane : (Tüm hanelerin indislerinin toplamı) mod 10 

Burada verilen numaralar karakter kümemizdeki indis numaralarına karşılık gelen numaralardır.

Postman Collection ekte paylaşılmıştır. Test edilmek istenirse kullanılabilir.

![image](https://user-images.githubusercontent.com/53389814/202751777-b791917d-61c0-4875-9e27-6a4fba916fa8.png)

Test edereken login işleminden sonra üretilen token bilgisi Variables kısmına eklenmesi gerekir.

