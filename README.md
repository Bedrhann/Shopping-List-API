# Teleperformance.FinalProject
Teleperformance ve Patika iş birliği ile düzenlenen .net bootcamp'i bitirme projem: **SHOPPİNG LİST**
### Proje İçeriği; 
* **ASP.NET 6** 
* **Onion Architecture**
* **Repository Pattern**
* **CQRS yapısı ve Mediatr kütüphanesi**
* **Jwt Token ile giriş yapma ve rolleme işlemleri**
* **Mapster**
* **RabbitMQ ile kuyruk kullanımı**
* **Unit ve Entegrasyon Testleri**

### Örnek senaryo

**Kullanıcı sisteme girer ve kayıt olması gerekir**
![image](https://user-images.githubusercontent.com/99317183/177709567-446e607c-cb2e-4e9f-9c7d-0b072ed3b092.png)
**Kullanıcı bilgileriyle sisteme giriş yapar**
![image](https://user-images.githubusercontent.com/99317183/177709800-35ddae14-c601-49e4-9dbf-ba1e8beb1d72.png)

**Kullanıcı Listesini oluşturur**
![image](https://user-images.githubusercontent.com/99317183/177710163-6271ea90-0800-4790-8544-15a2f48bc913.png)

**Kullanıcı oluşturduğu listesine kategori ekler**
![image](https://user-images.githubusercontent.com/99317183/177710490-1c160f83-d700-47f9-a7ce-25c7fd694cd3.png)

**Kullanıcı Kahvaltı ürünlerini bu kategoriye ekler**
![image](https://user-images.githubusercontent.com/99317183/177711365-3197fb7f-b60e-4f1d-b478-98eee324acaf.png)

**Kullanıcı Listesini tamamlandı olarak işaretlediğinde Sadece adminin görüntülediği veritabanına yazılır

----
**Genel Endpoint yapısı**
![image](https://user-images.githubusercontent.com/99317183/177711976-489848c3-9264-42c7-8b83-69b83de45e03.png)

###Projenin Eksikleri;
* Filtreleme ve searching düzenlenecek
* Fazla if yapıları düzenlenecek
* CQRS için veritanı command ve query olarak ikiye ayrılıp aralarında haberleşme sağlanacak.
* Yorum satırları eklenecek
