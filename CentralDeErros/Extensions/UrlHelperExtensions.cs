using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CentralDeErros.Extensions
{
    public static class UrlHelperExtensions
    {
        // extensao IUrlHelper
        public static string ResetPasswordCallbackLink(this IUrlHelper urlHelper, string userId, string code, string scheme)
        {
            //return $"{scheme}://localhost:5001/api/v1/Auth/resetPassword?userId={userId}&code={code}";
            return $"https://quirky-villani-02ba4d.netlify.app/reset-password?userId={userId}&code={code}";
        }
    }
}
