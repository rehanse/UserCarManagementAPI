﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserCarManagementAPI.UserInfra.Exceptions
{
    public class NotFoundException:Exception
    {
        public NotFoundException(string name,string message,object key):base($"{name}:{message}({key})")
        {
            
        }
    }
}
