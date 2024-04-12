using Microsoft.AspNetCore.Identity;

namespace Blogy.BusinessLayer.ErrorMessages
{
    public class CustomIdentityValidator:IdentityErrorDescriber
    {

        public override IdentityError PasswordTooShort(int length)
        {
            return new IdentityError()
            {
                Code = "PasswordTooShort",
                Description = $"Şifre minimum {length} karakter olmalıdır."
            };
        }

        public override IdentityError PasswordRequiresNonAlphanumeric()
        {
            return new IdentityError()
            {
                Code = "PasswordRequiresNonAlphanumeric",
                Description = "En az bir tane alfabetik numara olmalıdır."
            };
        }

        public override IdentityError PasswordRequiresDigit()
        {
            return new IdentityError()
            {
                Code = "PasswordRequiresDigit",
                Description = "Şifreler en az bir rakamdan oluşmalıdır."
            };
        }

        public override IdentityError PasswordRequiresLower()
        {
            return new IdentityError()
            {
                Code = "PasswordRequiresLower",
                Description = "Şifrelerde en az bir küçük harf ('a'-'z') bulunmalıdır."

            };
        }

        public override IdentityError PasswordRequiresUpper()
        {
            return new IdentityError()
            {
                Code = "PasswordRequiresUpper",
                Description = "Şifrelerde en az bir büyük harf ('A'-'Z') bulunmalıdır."

            };
        }


    }
}
