using ActividadASPNET.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ActividadASPNET.UTILS
{
    public class SANCIONESValidation: AbstractValidator<SANCIONESDTO>
    {
        public SANCIONESValidation()
        {
            RuleFor(s => s.OBSERVACION).NotEmpty().WithMessage("Observacion es obligatoria");
            RuleFor(s => s.CONDUCTOR_ID).NotEmpty().WithMessage("El ID del conductor es obligatorio");
        }
    }
}
