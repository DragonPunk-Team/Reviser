using System;

namespace Reviser.Files
{
    public interface IFile
    {
        void SetGame(string game);
        void ReadFile(object filepath);
        string RemoveColors(string line);
        Tuple<string, string>[] GetLines(string lineIDs);
    }
}
