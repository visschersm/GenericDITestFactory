﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestUtilities.Interfaces
{
    public interface IBaseTest
    {
        void RegisterDependencies(IServiceCollection services);
    }
}
