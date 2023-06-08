using Application.UseCases.Commands;
using Application.UseCases.Commands.Reaction;
using Application.UseCases.DTO;
using DataAccess;
using FluentValidation;
using Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands.EF.Reactions
{
    public class EFUpdateReactionCommand: EFUseCase, IUpdateReactionCommand
    {
        private readonly UpdateReactionValidator _validator;

        public EFUpdateReactionCommand(BlogContext context, UpdateReactionValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 27;

        public string Name => "Update Reaction";

        public string Description => "Update Reaction using EF";

        public void Execute(UpdateEntityDto request)
        {
            _validator.ValidateAndThrow(request);

            var reaction = Context.Reactions.Find(request.Id);

            reaction.Name = request.Name;

            Context.SaveChanges();
        }
    }
}
