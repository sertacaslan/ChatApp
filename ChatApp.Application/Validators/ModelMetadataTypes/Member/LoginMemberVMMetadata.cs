using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Application.Validators.ModelMetadataTypes.Member
{
    public class LoginMemberVMMetadata
    {
        [Required(AllowEmptyStrings =false,ErrorMessage ="Bu alan boş bırakılamaz")]
        [MaxLength(30,ErrorMessage ="Maksimum 30 karakter girilebilir.")]
        public string UserName { get; set; }



        [Required(AllowEmptyStrings = false, ErrorMessage = "Bu alan boş bırakılamaz")]
        [MaxLength(30, ErrorMessage = "Maksimum 30 karakter girilebilir.")]

        public string UserPass { get; set; }
    }
}
