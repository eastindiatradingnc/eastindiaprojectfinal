﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.ParameterObjects
{
    public class ValueControllerInput
    {
        int param1;
        String param2;

        ValueControllerInput(int param1, String param2) {
            this.param1 = param1;
            this.param2 = param2;
        }
    }
}
