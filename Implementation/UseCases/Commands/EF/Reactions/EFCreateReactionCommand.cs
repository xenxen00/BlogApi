using Application.UseCases.Commands.Reaction;
using Application.UseCases.DTO;
using DataAccess;
using Domain.Entities;
using FluentValidation;
using Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands.EF.Reactions
{
    public class EFCreateReactionCommand : EFUseCase, ICreateReactionCommand
    {
        private readonly ReactionValidator _validator;
        public EFCreateReactionCommand(BlogContext context, ReactionValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 26;

        public string Name => "Create Reaction";

        public string Description => "Create Reaction using EF";

        public void Execute(CreateEntityDto request)
        {
            _validator.ValidateAndThrow(request);

            Context.Add(new Domain.Entities.Reaction
            {
                Name = request.Name,
            });

            Context.SaveChanges();
        }
    }
}
