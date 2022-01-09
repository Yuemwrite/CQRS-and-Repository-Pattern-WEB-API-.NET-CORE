using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Constants
{
    public enum Messages
    {
        [Display(Name = "Added")]
        Added = 2001,
        [Display(Name = "Updated")]
        Updated = 2002,
        [Display(Name = "Deleted")]
        Deleted = 2003,
        [Display(Name = "Success")]
        Success = 2004,
        [Display(Name = "ApprovalProcess")]
        WaitingApproval = 2005,

        // Warning
        [Display(Name = "PasswordEmpty")]
        PasswordEmpty = 3001,
        [Display(Name = "PasswordLength")]
        PasswordLength = 3002,

        // Exception
        [Display(Name = "AuthorizationsDenied")]
        AuthorizationsDenied = 4001,

        [Display(Name = "EntityNotFound")]
        EntityNotFound = 4002,

        [Display(Name = "UserNotFound")]
        UserNotFound = 4003,

        [Display(Name = "UsernameOrPasswordIncorrect")]
        UsernameOrPasswordIncorrect = 4003,

        [Display(Name = "PasswordIncorrect")]
        PasswordIncorrect = 4004,

        [Display(Name = "NameAlreadyExist")]
        NameAlreadyExist = 4005,

        [Display(Name = "EmailAlreadyExist")]
        EmailAlreadyExist = 4006,

        [Display(Name = "HostNameAlreadyExist")]
        HostNameAlreadyExist = 4007,

        [Display(Name = "TitleAlreadyExist")]
        TitleAlreadyExist = 4008,

        [Display(Name = "EntityNameAlreadyExist")]
        EntityNameAlreadyExist = 4009,

        [Display(Name = "EmailNotVerified")]
        EmailNotVerified = 4010,

        [Display(Name = "TokenExpired")]
        TokenExpired = 4011,

        [Display(Name = "WrongOTP")]
        WrongOTP = 4012,
    }
}
