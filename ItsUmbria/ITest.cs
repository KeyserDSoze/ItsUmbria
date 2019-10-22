using System;
using System.Collections.Generic;
using System.Text;

namespace ItsUmbria
{
    public interface ITest
    {
        void Do();
    }
    public static class TestExtensions
    {
        public static string ToName(this ITest test)
            => test.GetType().FullName.Replace("ItsUmbria.", "");
    }
}
