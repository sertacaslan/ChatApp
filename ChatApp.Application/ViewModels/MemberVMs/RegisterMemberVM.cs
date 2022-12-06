using ChatApp.Application.Validators.ModelMetadataTypes.Member;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Application.ViewModels.Member
{
    [ModelMetadataType(typeof(RegisterMemberVMMetadata))]
    public class RegisterMemberVM
    {
        public string UserName { get; set; }
        public string UserPass { get; set; }    
        public string UserMail { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime RegisterDate { get; set; }
    }
}
