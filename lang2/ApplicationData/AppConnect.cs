using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lang2.ApplicationData
{
    class AppConnect
    {
        public static lang2Entities modelOdb { get; } = new lang2Entities();
        public partial class App
        {
            public string Fullname { get => $"{Firstname} {Lastname} {Patronymic}"; }
            public object Firstname { get; private set; }
            public object Lastname { get; private set; }
            public object Patronymic { get; private set; }
        }
    }
}
