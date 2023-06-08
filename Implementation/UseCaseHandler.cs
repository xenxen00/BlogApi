using Application;
using Application.Exeptions;
using Application.UseCases;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Implementation
{
    public class UseCaseHandler
    {
        private IApplicationUser _applicationUser;

        public UseCaseHandler(IApplicationUser applicationUser)
        {
            _applicationUser = applicationUser;
        }

        public void HandleCommand<TRequest>(ICommand<TRequest> command, TRequest request)
        {
            try
            {
                HandleAuthorization(command);
                command.Execute(request);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public TResponse HandleQuery<TRequest, TResponse>(IQuery<TRequest,TResponse> query, TRequest request)
        {
            try
            {
                HandleAuthorization(query);
                return query.Execute(request);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public TResponse HandleEmptyQuery<TResponse> (IEmptyQuery<TResponse> query)
        {
            try
            {
                HandleAuthorization(query);
                return query.Execute();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void HandleAuthorization(IUseCase usecase)
        {
            var isUserAuthorized = _applicationUser.PermissionsIds.Contains(usecase.Id);

            if(!isUserAuthorized)
            {
                throw new ForbiddenUseCase();
            }
        }
    }
}
