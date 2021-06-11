using System;

namespace Reviser.Files
{
    public interface IFile
    {
        void ReadFile(object filepath);
        string RemoveColors(string line);
        Tuple<string, string>[] GetLines(string lineIds);
    }
}
