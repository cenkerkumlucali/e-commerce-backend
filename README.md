# E-Commerce-Backend
Genel olarak proje katmanlı mimariye uygun şekilde tasarlanıp OOP olarak entity framework kullanılmaktadır.IoC prensibi ve SOLID ilkeleri ile geliştirilmeye devam ediyor.AutoFac ve FluentValidation paketleri kullanılıyor.
# Katmanlar
- [Business](https://github.com/cenkerkumlucali/E-Commerce-Backend/tree/main/Business):Sunum katmanından gelen bilgileri gerekli koşullara 
göre işlemek veya denetlemek için oluşturulan Business Katmanı'nda Abstract,Concrete,Utilities,BusinessAspects,DependencyResolvers,Generic ve 
ValidationRules olmak üzere yedi adet klasör bulunmaktadır.
Abstract klasörü soyut nesneleri, Concrete klasörü somut nesneleri tutmak için oluşturulmuştur.Utilities ve ValidationRules klasörlerinde validation işlemleri,BusinessAspects core katmanına eklenebilirdi ancak 
her proje de olmayan sadece bu projeye özel olan aspectler 
DependencyResolvers içerisinde olan Autofac dosyasından da belli olduğu gibi sınıflar arasında bağımlılıkları yönetir böylece uygulama boyutu büyüdükçe kolayca değiştirilebilir 
projede olan bağımlılıkları web api katmanından taşıyıp business katmanında tutulmalıdır,son olarak Generic klasörü var business da 1 den fazla yapılmış olan crud operasyonları
için generic bir interface oluşturulup kendimizi tekrar etmekten kurtulduk(DRY).
- [Core](https://github.com/cenkerkumlucali/ReCapProject/tree/master/Core):Bir framework katmanı olan Core Katmanı'nda Aspects,CrossCuttingConcerns,DependencyResolvers,Extensions,DataAccess, Entities, Utilities olmak üzere 7 adet klasör bulunmaktadır.Aspects klasörü içersinde 2 adet dosya daha vardır Caching içersinde CacheAspect ve CacheRemoveAspect vardır
CacheAspect verilen zaman kadar datanın cache de durmasını sağlıyor CacheRemoveAspect ise cache de olan verileri siliyor örnek olarak ikisini de açıklamak gerekirse
kullanıcı ürünleri listeliyor eğer cache de varsa performans açısından veri tabanından almak yerine cache den alıyor eğer ürün eklenirse cache'in süresi dolmasa bile cache den silinip
tekrardan ekliyor Validation klasörü her class a özel olarak yapılmış olan business katmanında bulunan FluentValidation ile yazılan kuralları AOP olarak attributes olarak
temiz kod ve her method için bağımlı olmamak için yapılan bir Aspect DependencyResolvers içersinde ki CoreModule genel bağımlılıkları çözen class
Utilities klasörü projenin en büyük klasörü içerisinde bulunanları size anlatıyım Business klasörü içersindeki BusinessRules Result tipinde olan iş kurallarını tek methodun içinde if else if else 
yazmak yerine her kural için ayrı method oluşturup onları istediğiniz methodun içinde çağırıp ve sadece tek if yazıp istediğiniz kadar iş kuralı yazmanızı sağlıyan yapıdır.
Helpers klasörü içerisinde olan FileHelper bir ürüne veya herhangi bir şeye fotoğraf ekliceğiniz zaman fotoğrafı veri tabanına Guid şekilde eklenmesine olanak sağlanan generic bir yapıdır
Interceptors klasörü içerisinde 3 adet class vardır MethodInterceptionBaseAttribute bir abstract classdır ve kendisinin bir attributes olması sağlanır,MethodInterception
MethodInterceptionBaseAttribute'i implement alan bir abstract classdır içersinde ezilebilmek üzere 5 adet method tanımlıdır bunlar OnBefore method çalışmadan önce çalışacak olan
method OnAfter method bittikten sonra çalışacak olan method OnException hata verdiğinde çalışacak olan method  OnSuccess başarılı olduğunda çalışacak olan method
son olarak Intercept methodu bahsetmiş olduğu methodların nerede çalışıp çalışmıcağını belirlendiği içerisinde try,cache ve finally ile hayat sıralamasına koyuldu.
Results klasöründe IResult ve IDataResult olarak 2 adet interface var Result yapısında ki amaç add delete update gibi post methodları için success bilgisi ve message bilgisi göstermesi
DataResult ise Data,success ve message göstermesi eğer ki method başarılı olarsak çalışıyorsa SuccessResult yada SuccessDataResult çalışır eğer bir sorun varsa ErrorResult yada
ErrorDataResult çalışır ve message olarak girilen hatayı kullanıcıya gösterir.Security klasöründe 3 adet klasör bulunuyor Encryption'ın içinde SecurityKeyHelper SecurityKey'i kullanarak gelen securityKey i byte a çeviriyor 
SigningCredentialsHelper ise SigningCredentials tipinde bir method parametre olarak da SecurityKey veriliyor çünkü SigningCredentials bizden 2 parametre istiyor 1-securityKey 2-Hangi 
Güvenlik algoritmasını kullanılacağı Hashing klasöründe HashingHelper classı vardır içerisinde 2 method tanımlı CreatePasswordHash methodu ile kayıt olurken gelen şifrenin 
üstüne biraz da kendi bir şeyler ekler ve sonra o şifreyi hashliyip tekrardan çözülemez hale getirir VerifyPasswordHash methodu ise kullanıcı sisteme tekrardan giriş yaparken 
girmiş olduğu şifre kayıt olduğu sırada ki gibi tekrardan saltlanıp hashlenir ve veri tabanında ki şifre ile karşılaştırılır eğer doğruysa sisteme giriş yapar yanlışsa kullanıcı bilgilendirilir 
DataAccess klasörü DataAccess Katmanı ile ilgili nesneleri, Entities klasörü Entities 
katmanı ile ilgili nesneleri tutmak için oluşturulmuştur. Core katmanının .Net Core ile hiçbir bağlantısı yoktur.Oluşturulan core katmanında ortak kodlar tutulur. Core katmanı
ile, kurumsal bir yapıda, alt yapı ekibi ilgilenir. 
- [DataAccess](https://github.com/cenkerkumlucali/E-Commerce-Backend/tree/master/DataAccess):Veritabanı CRUD işlemleri gerçekleştirmek için oluşturulan Data Access Katmanı'nda Abstract ve Concrete olmak üzere iki adet klasör bulunmaktadır.Abstract klasörü soyut nesneleri, Concrete klasörü somut nesneleri tutmak için oluşturulmuştur. 
- [Entites](https://github.com/cenkerkumlucali/E-Commerce-Backend/tree/master/Entities):Veritabanı nesneleri için oluşturulmuş Entities Katmanı'nda Abstract ve Concrete olmak üzere iki adet klasör bulunmaktadır.Abstract klasörü soyut nesneleri, Concrete klasörü somut nesneleri tutmak için oluşturulmuştur. 
- [WebAPI](https://github.com/cenkerkumlucali/E-Commerce-Backend/tree/master/WebAPI) 

#### Kütüphaneler 

 - [ ] EntityFrameworkCore.SqlServer 3.1.11
 - [ ] FluentValidation 7.3.3
 - [ ] Autofac 6.1.0
 - [ ] Autofac.Extensions.DependencyInjection 7.1.0
 - [ ] Autofac.Extras.DynamicProxy 6.0.0 
                
----
                    
                
