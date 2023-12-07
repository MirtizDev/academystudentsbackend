using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace academystudentsbackend.Models
{
    public class CourseContext:IdentityDbContext<AppUser,AppRole,int>
    {
        public CourseContext(DbContextOptions<CourseContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Course>().HasData(new Course(){CourseId=1,Name="Adobe Photoshop",Image="photoshop.png",Description="Qrafik dizayn dərslərini təqdim edirik.Dərslər həftə ərzində 3dəfə 60dəq və ya 2dəfə 90dəq həcmində təşkil olunur Məşğələlər fərdi şəkildə təşkil olunur.Bu proqram çərçivəsində siz photoshopla köhnə şəkillərin bərpasını,ağ-qara şəkillərin rənglənmasini,üz montajını,kollaj və panarama şəkillərin yiğılmasını,buklet, flayer, banner, vizitka,poster,retuş,animasiyaların yığılmasını və bir çox yeni praktiki biliklər əldə edəcəksiniz.",Price=90,Category="design"});
            builder.Entity<Course>().HasData(new Course(){CourseId=2,Name="Adobe Illustrator",Image="illustrator.png",Description="Qrafik dizayn dərslərini təqdim edirik.Dərslər həftə ərzində 3dəfə 60dəq və ya 2dəfə 90dəq həcmində təşkil olunur Məşğələlər fərdi şəkildə təşkil olunur.Bu proqram çərçivəsində siz illustratorla flat logo,effektlər,posterlər,vizika,flayer,bukletlər yığılması,vektorların,cədvəllərin,diaqramların çəkilməsini öyrənəcəksiniz.",Price=90,Category="design"});
            builder.Entity<Course>().HasData(new Course(){CourseId=3,Name="Corel Draw",Image="coreldraw.png",Description="Qrafik dizayn dərslərini təqdim edirik.Dərslər həftə ərzində 3dəfə 60dəq və ya 2dəfə 90dəq həcmində təşkil olunur Məşğələlər fərdi şəkildə təşkil olunur.Bu proqram çərçivəsində siz corel draw-la logo,buklet,vizitka,poster,plokat yığılmasını,CMYK rəng ayırımı və effektlər barədə praktiki biliklərə yiyələnəcəksiniz.",Price=90,Category="design"});
            builder.Entity<Course>().HasData(new Course(){CourseId=4,Name="Adobe InDesign",Image="indesign.png",Description="Qrafik dizayn dərslərini təqdim edirik.Dərslər həftə ərzində 3dəfə 60dəq və ya 2dəfə 90dəq həcmində təşkil olunur Məşğələlər fərdi şəkildə təşkil olunur.Bu proqram çərçivəsində siz indesign-la flat logo,effektlər,posterlər,vizika,flayer,bukletlər yığılması,vektorların,cədvəllərin,diaqramların çəkilməsini öyrənəcəksiniz.",Price=120,Category="design"});
            builder.Entity<Course>().HasData(new Course(){CourseId=5,Name="Microsoft Word",Image="word.png",Description="Dərslər həftədə 3 dəfə 1 saat və ya 2dəfə 90 dəqiqə ərzində tədris olunur.Bu proqram çərçivəsində siz word proqramında mətnlərin tərtibini,cədvəlləri,fayllara şifrə qoymağı,sənədlərin çapını,səhifə başlığı və sonu anlayışlarını dərindən öyrənib,praktiki biliklər əldə edəcəksiniz.",Price=90,Category="office"});
            builder.Entity<Course>().HasData(new Course(){CourseId=6,Name="Microsoft Powerpoint",Image="powerpoint.png",Description="Dərslər həftədə 3 dəfə 1 saat və ya 2dəfə 90 dəqiqə ərzində tədris olunur.Bu proqram çərçivəsində siz powerpoint proqramında təqdimat,slide show,naviqator,intro,poster,kiçik həcmdə video montaj,cədvəl,diaqram yığmaqı öyrənəcək,praktiki biliklər əldə edəcəksiniz.",Price=90,Category="office"});
            builder.Entity<Course>().HasData(new Course(){CourseId=7,Name="Microsoft Excel",Image="excel.png",Description="Dərslər həftədə 3 dəfə 1 saat və ya 2dəfə 90 dəqiqə ərzində tədris olunur.Bu proqram çərçivəsində siz exceldə ticarət anlayışlarını,endirim,əmək haqqının hesablanması,kredit,ümumi cəm,konselidasiya,məlumatların yoxlanması,diaqram,valyuta dəyişimi və s əməliiyatları yerinə yetirməyi,bununla yanaşı ДВССЛ,ВПР,ЕСЛИ,ПОИСКПОЗ,ИНДЕКС kimi funksiyalarla çalışmağı öyrənəcək,praktiki biliklər qazanacaqsınız.",Price=90,Category="office"});
        }

        public DbSet<Course> Courses {get; set;}

    }


}