﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public interface IValidation
    {
        bool validate(string path);
    }
}
