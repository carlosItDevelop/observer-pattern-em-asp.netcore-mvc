using System;
using System.ComponentModel.DataAnnotations;

namespace DemoIdentity.AccessManager.ViewModels
{
    public class CreateRoleViewModel
    {
        //public CreateRoleViewModel()
        //{
        //    this.Id = Guid.NewGuid();
        //}

        //public Guid Id { get; set; }
        
        [Required(ErrorMessage = "O nome da Role é obrigatório!")]
        public string Name { get; set; }
    }
}