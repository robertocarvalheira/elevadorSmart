using System;
using System.Collections.Generic;
using System.Text;

namespace ElevadorSmartDotNetFramework
{
    interface IPassageiro
    {
        int PosIncial { get; set; }
        int PosDestino { get; set; }
        string NomePassageiro { get; set; }
        bool Wait { get; set; }
    }
}
