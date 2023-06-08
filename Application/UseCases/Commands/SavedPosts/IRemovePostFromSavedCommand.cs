﻿using Application.UseCases.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Commands.SavedPosts
{
    public interface IRemovePostFromSavedCommand: ICommand<SavedPostDto>
    {
    }
}
