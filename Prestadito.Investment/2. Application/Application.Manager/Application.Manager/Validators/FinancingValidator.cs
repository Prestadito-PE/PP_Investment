﻿using FluentValidation;
using Prestadito.Investment.Application.Dto.Financing.CreateFinancing;
using Prestadito.Investment.Application.Dto.Financing.DisableFinancing;
using Prestadito.Investment.Application.Dto.Financing.GetFinancingById;
using Prestadito.Investment.Application.Dto.Financing.UpdateFinancing;
using Prestadito.Investment.Infrastructure.Data.Constants;

namespace Prestadito.Investment.Application.Manager.Validators
{
    public class GetFinancingByIdValidator : AbstractValidator<GetFinancingByIdRequest>
    {
        public GetFinancingByIdValidator()
        {
            RuleFor(x => x.StrId)
                .NotEmpty().WithMessage(ConstantMessages.Validator.PROPERTY_NAME_IS_EMPTY);
        }
    }

    public class CreateFinancingValidator : AbstractValidator<CreateFinancingRequest>
    {
        public CreateFinancingValidator()
        {
            RuleFor(x => x.StrEmail)
                .NotEmpty().WithMessage(ConstantMessages.Validator.PROPERTY_NAME_IS_EMPTY)
                .EmailAddress().WithMessage(ConstantMessages.Validator.EMAIL_NOT_VAlID);

            RuleFor(x => x.StrPassword)
                .NotEmpty().WithMessage(ConstantMessages.Validator.PROPERTY_NAME_IS_EMPTY);

            RuleFor(x => x.StrRolId)
                .NotEmpty().WithMessage(ConstantMessages.Validator.PROPERTY_NAME_IS_EMPTY);
        }
    }

    public class UpdateFinancingValidator : AbstractValidator<UpdateFinancingRequest>
    {
        public UpdateFinancingValidator()
        {
            RuleFor(x => x.StrId)
                .NotEmpty().WithMessage(ConstantMessages.Validator.PROPERTY_NAME_IS_EMPTY);

            RuleFor(x => x.StrPassword)
                .NotEmpty().WithMessage(ConstantMessages.Validator.PROPERTY_NAME_IS_EMPTY);

            RuleFor(x => x.StrRolId)
                .NotEmpty().WithMessage(ConstantMessages.Validator.PROPERTY_NAME_IS_EMPTY);
        }
    }

    public class DisableFinancingValidator : AbstractValidator<DisableFinancingRequest>
    {
        public DisableFinancingValidator()
        {
            RuleFor(x => x.StrId)
                .NotEmpty().WithMessage(ConstantMessages.Validator.PROPERTY_NAME_IS_EMPTY);
        }
    }

    public class DeleteFinancingValidator : AbstractValidator<DeleteFinancingRequest>
    {
        public DeleteFinancingValidator()
        {
            RuleFor(x => x.StrId)
                .NotEmpty().WithMessage(ConstantMessages.Validator.PROPERTY_NAME_IS_EMPTY);
        }
    }
}