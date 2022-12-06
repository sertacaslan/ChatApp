using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Application.Validators.ModelMetadataTypes.Member
{
    public class RegisterMemberVMMetadata
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Bu alan boş bırakılamaz")]
        [NotNull]
        [MinLength(2, ErrorMessage = "En az 2 karakter olmalıdır.")]
        [MaxLength(30, ErrorMessage = "Maksimum 30 karakter girilebilir.")]

        public string UserName { get; set; }



        [Required(AllowEmptyStrings = false, ErrorMessage = "Bu alan boş bırakılamaz")]
        [NotNull]
        [MinLength(2, ErrorMessage = "En az 2 karakter olmalıdır.")]
        [MaxLength(30, ErrorMessage = "Maksimum 30 karakter girilebilir.")]

        public string UserPass { get; set; }





        [Required(AllowEmptyStrings = false, ErrorMessage = "Bu alan boş bırakılamaz")]
        [NotNull]
        [EmailAddress]
        [MinLength(2, ErrorMessage = "En az 2 karakter olmalıdır.")]
        [MaxLength(30, ErrorMessage = "Maksimum 30 karakter girilebilir.")]

        public string UserMail { get; set; }





        [Required(AllowEmptyStrings = false, ErrorMessage = "Bu alan boş bırakılamaz")]
        [NotNull]
        [MinLength(2, ErrorMessage = "En az 2 karakter olmalıdır.")]
        [MaxLength(30, ErrorMessage = "Maksimum 30 karakter girilebilir.")]

        public string FirstName { get; set; }




        [Required(AllowEmptyStrings = false, ErrorMessage = "Bu alan boş bırakılamaz")]
        [NotNull]
        [MinLength(2, ErrorMessage = "En az 2 karakter olmalıdır.")]
        [MaxLength(30, ErrorMessage = "Maksimum 30 karakter girilebilir.")]

        public string LastName { get; set; }

    }
}
