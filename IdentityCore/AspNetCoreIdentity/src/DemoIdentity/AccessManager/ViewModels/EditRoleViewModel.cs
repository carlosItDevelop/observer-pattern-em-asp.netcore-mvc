using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DemoIdentity.AccessManager.ViewModels
{
    public class EditRoleViewModel
    {
        public EditRoleViewModel()
        {
            // Para evitar que seja null,
            // quando não houver UserInRole
            Usuarios = new List<string>();
        }
        public string Id { get; set; }
        
        [Required(ErrorMessage = "O Nome da Role é Obrigatório!")]
        public string Nome { get; set; }
        public List<string> Usuarios { get; set; }
    }
}