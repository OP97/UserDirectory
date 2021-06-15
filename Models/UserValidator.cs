using FluentValidation;
using System.Linq;

namespace UserDirectory.Models
{
    public class UserValidator : AbstractValidator<User>
    {
        readonly MvcUserContext _context;
        public UserValidator(MvcUserContext context)
        {
            _context = context;
            RuleFor(x => x.Email).Must(uniqueMail).WithMessage("This email is already in use");
            RuleFor(x => x.Phone).Must(uniquePhone).WithMessage("This phone is already in use");
        }

        private bool uniqueMail(User user, string email)
        {
            var mail = _context.User.Where(x => x.Email.ToLower() == user.Email.ToLower()).SingleOrDefault();

            if (mail == null) return true;
            return false;
        }

        private bool uniquePhone(User user, string phone)
        {
            var phoneNumber = _context.User.Where(x => x.Phone == user.Phone).SingleOrDefault();

            if (phoneNumber == null) return true;
            return false;
        }
    }
}