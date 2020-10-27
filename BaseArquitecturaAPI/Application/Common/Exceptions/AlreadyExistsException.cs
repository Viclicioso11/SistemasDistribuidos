using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common.Exceptions
{
    public class AlreadyExistsException : Exception
    {
        public AlreadyExistsException(string obj, int id) : base($"Entity {obj} with id {id} was not found")
        {

        }
    }
}
