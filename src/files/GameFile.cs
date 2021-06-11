using Reviser.Files.SoJ;

namespace Reviser.Files
{
    public static class GameFile
    {
        public static IFile Get(string projectType)
        {
            return projectType switch
            {
                "SoJ" => new GMDv2(),
                _ => null
            };
        }
    }
}
