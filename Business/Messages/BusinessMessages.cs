using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Messages
{
    public class BusinessMessages
    {
        internal static string UserIsAlreadyExist = "Böyle bir kullanıcı zaten mevcut";
        internal static string EmailOrPasswordIsWrong = "E-Posta veya Şifre Hatalı!";
        internal static string OkayMessage = "Okay";
        internal static string CreatedMessage = "Oluşturuldu";
        internal static string UserIsNotExist = "Böyle bir kullanıcı mevcut değil";
        internal static string OccuredAnErrorDuringRegister = "Kullanıcıyı veritabanına eklerken bir sorun oluştu.";
    }
}
