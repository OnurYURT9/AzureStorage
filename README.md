# AzureStorage
Azure'un verilerimizi depolamak için sunduğu bulut sistemdir.<br/>
*Güvenlidir. <br/>
*Dayanaklı.<br/>
*Ölçeklenebilir<br/>
*Erişilebilirlik<br/>

## AZURE STORAGE'DA NE TÜR DATALAR TUTULUR
File:  Sanal makinelerin ortak dosya paylaşma ihtiyacı varsa kullanacağı ortak dosyalar varsa burada tutulur.<br />
Table: Veriler key value şeklinde tutulur. NoSQL.<br />
Blob: Kaydedeceğimiz herhangi bir dosyadır. <br/>
Queue: Kuyruk sistemi (rabbitmq) <br />

## AZURE TABLE STORAGE NEDEN KULLANILIR?

Azure Storage Table’ın transaction desteği bulunmamaktadır. Bu durum kesinlikle NoSQL veritabanları için genellenmemelidir. Örneğin; MongoDB NoSQL yaklaşımını benimsemiş bir veritabanıdır ve transaction desteği bulunmaktadır. LİNQ destekler.ODATA ile yapılan sorgularda olumlu sonuçlar doğurur.

## AZURE TABLE STORAGE

Azure da table oluşturduğunuzda 3 özellik otomatik olarak oluşturulur.Bunlar PartitionKey(satırları gurplar hızlı arama yapmak için), RowKey(Primary Key) ve Timestamp’dır.TimeStamp sistem tarafından otomatik oluşturulur fakat tabloya veri eklerken PartitionKey ve RowKey’i belirtmeniz gerekecektir.

## AZURE BLOB STORAGE

Azure blob storage dosya kaydetmek için kullanacağımız storage tipidir. Herhangi binary dosyayı (bütün dosya çeşitleri)blob storage'lara kaydedebiliriz.

Block Blob: Kaydetmek istediğimiz veriler tek parça halinde değil parça parça kaydedilebilir.

Her block'a 100mb 'a kadar data yazabiliriz. 1 tane blob 50bin blocktan meydana gelir. Dosya değiştirilmez üzerine yazılır.

Append Blob:  Ekleme işlemleri yapacağımız blob yapacaksak sürekli o dosyayı kaydedeceksek append blob kullanabiliriz.

Page Blob: Datalar page page tutulur. Her page 512 byte dan meydana gelir. Herhangi byte aralığında okuma ve yazma işlemi gerçekleştirilir. Sanal makinelere disk bağlandığı zaman azure tarafında page bloklardan destekleniyor.

## AZURE QUEUE STORAGE

Mesaj kuyruk sistemidir. Web veya mobil uygulamasında çok uzun süren işlemler varsa onu o anda yapmak yerine arka tarafta çalışan kuyruğa mesaj atıyorsun bunu dinleyen başka bir uygulama onu alıyor ve işliyor o sayede o sistem tarafından değilde daha sonra başka bir sistem tarafından işlenmiş oluyor.
