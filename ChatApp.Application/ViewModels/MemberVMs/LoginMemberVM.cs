using ChatApp.Application.Validators.ModelMetadataTypes.Member;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Application.ViewModels.Member
{
    [ModelMetadataType(typeof(LoginMemberVMMetadata))]
    public class LoginMemberVM
    {

        public string UserName { get; set; }
        public string UserPass { get; set; }
    }
}
