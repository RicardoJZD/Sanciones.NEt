using ActividadASPNET.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ActividadASPNET.UTILS
{
    public class MATRICULASValidation: AbstractValidator<MATRICULASDTO> 
    {
        public MATRICULASValidation() 
        {
            RuleFor(s => s.NUMERO).NotEmpty().WithMessage("Numero Obligatorio");
            RuleFor(s => s.NUMERO).MaximumLength(20).WithMessage("Máximo 20 caracteres");

            RuleFor(s => s.FECHA_EXPEDICION).NotEmpty().WithMessage("Fecha Obligatoria");

            RuleFor(s => s.VALIDA_HASTA).NotEmpty().WithMessage("Fecha Obligatoria");
        }
    }
}
