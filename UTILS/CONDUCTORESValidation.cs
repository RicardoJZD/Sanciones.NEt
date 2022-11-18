using ActividadASPNET.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ActividadASPNET.UTILS
{
    public class CONDUCTORESValidation: AbstractValidator<CONDUCTORESDTO>
    {
        public CONDUCTORESValidation()
        {
            RuleFor(s => s.IDENTIFICACION).NotEmpty().WithMessage("Numero Obligatorio");
            RuleFor(s => s.IDENTIFICACION).MaximumLength(15).WithMessage("Máximo 15 caracteres");

            RuleFor(s => s.NOMBRE).NotEmpty().WithMessage("Nombre Obligatorio");
            RuleFor(s => s.NOMBRE).MaximumLength(20).WithMessage("Máximo 20 caracteres");

            RuleFor(s => s.APELLIDO).NotEmpty().WithMessage("Apellido Obligatorio");
            RuleFor(s => s.APELLIDO).MaximumLength(20).WithMessage("Máximo 20 caracteres");

            RuleFor(s => s.DIRECCION).MaximumLength(30).WithMessage("Máximo 30 caracteres");
            RuleFor(s => s.TELEFONO).MaximumLength(15).WithMessage("Máximo 15 caracteres");
            RuleFor(s => s.EMAIL).MaximumLength(30).WithMessage("Máximo 30 caracteres");

            RuleFor(s => s.NUMERO_MATRICULA).NotEmpty().WithMessage("Numero de Matricula Obligatorio");
            RuleFor(s => s.NUMERO_MATRICULA).MaximumLength(20).WithMessage("Máximo 20 caracteres");
        }
    }
}
