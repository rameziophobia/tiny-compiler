using System;
using System.Collections.Generic;

namespace TinyCompiler.Model.Errors
{
    abstract class CompilationExpection : Exception
    {
        private static List<CompilationExpection> ErrorList = new List<CompilationExpection>();
        public CompilationExpection(String Message) : base(Message) { }
        public static List<CompilationExpection> getErrorList()
        {
            return ErrorList;
        }
        public static void clearErrorList()
        {
            ErrorList = new List<CompilationExpection>();
        }
    }
    //TODO add more Exception types
    //TODO each Excepiton will be displayed diffrently by the GUI
}