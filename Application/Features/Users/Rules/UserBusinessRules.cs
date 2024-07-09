using Core.CrossCuttingConcerns.Exceptions;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Rules
{
    public class UserBusinessRules
    {
        public void UserShouldExistWhenRequest(User? User)
        {
            if (User == null) throw new BusinessException("Requested programing language does not exist.");
        }
    }
}
