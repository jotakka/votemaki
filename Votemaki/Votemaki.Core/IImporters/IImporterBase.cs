﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Votemaki.Core.IImporters
{
    public interface IImporterBase
    {
        Task Import(File file);
    }
}
