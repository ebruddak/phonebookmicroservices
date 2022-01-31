# Microservice Poc: Telefon Rehberi Uygulaması

Farklı db'ler kullanan iki mikroservisin, Ocelot ile hazırlanan bir Api Gatewey üzerinden haberleşerek Rabbitmq kuyruk yapısı ile birlikte Angular ile yazılmış olan clieant'a rapor sunduğu bir çalışmadır.

Client 

```sh
http://localhost:4200
```
Backend

```sh
http://localhost:5000
```

## Mimari Yapı

Report ve Person isimli iki mikroservis farklı tasarım kalıpları ile geliştirilmiştir. Oluşturulan mimari yapı ve detayları aşağıdaki gibidir. <br/>
![ScreenShot](https://i.ibb.co/rkzjfTZ/1.png)
<br/>Report mikroservisinde Cqrs pattern, MediartR ve Union pattern kullanılmıştır. Katmanlı bir yapı tasarlanmış, command ve queryler ayrılmıştır.

## Veritabanı

Person mikroserviste MongoDb, Report Mikroserviste ise PostgreSql kullanılmıştır. Veritabanları portainer üzerinde ayaklandırılmış ve monitör edilmiştir. Portainer üzerinde aynı zamanda Rabbitmq da kurulmuştur.<br/>
 ![ScreenShot](https://i.ibb.co/cYbbVzk/portainer.png)<br/>
## Class Yapısı

Çalışmada kullanılan classlar aşağıdaki gibidir. Report entity aggregateroot olarak işaretlenmiştir. Person ve ContactInfo classları arasında bire çok ilişki vardır.<br/>
 ![ScreenShot](https://i.ibb.co/P4LGSSZ/2.png)<br/>
 ![ScreenShot](https://i.ibb.co/JdD2ZpC/dfgdfgd.png)<br/>
## Client ve ApiGateWay

Client Projesi Angular13 kullanılarak, material UI kütüphanesiyle yazılmıştır. Client ile backendin haberleşmesi Ocelot kullanılarak yazılan bir gateway üzerinden sağlanmıştır. Yapının görüntüsü ve Gateway configrasyonu aşağıdaki gibidir.<br/>
 ![ScreenShot](https://i.ibb.co/bJv7VK5/3.png)<br/>
 ![ScreenShot](https://i.ibb.co/LnSSgD8/5.png)<br/>
## Kullanılan Teknolojiler

.ner core 5.0
 -Angular13
 -MaterialUI
 -Rabbitmq
 -MediatR
 -Ocelot
 -MassTransit
 -Docker
EntittyFramework

## Ekran Görüntüleri

 ![ScreenShot](https://i.ibb.co/5xwfsCb/9999999.png)<br/>
 ![ScreenShot](https://i.ibb.co/hdJJR7w/6666666666.png)<br/>
 ![ScreenShot](https://i.ibb.co/1bbw6bx/96796796.png)<br/>
 ![ScreenShot](https://i.ibb.co/NjDFGt0/7777777.png)<br/>
 ![ScreenShot](https://i.ibb.co/tYpg8B7/74747457.png)<br/>
