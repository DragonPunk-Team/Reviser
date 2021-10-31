﻿namespace Reviser.Files
{
    public static class GameFile
    {
        public static IFile Get(string projectType)
        {
            return projectType switch
            {
                "SoJ" => new GMDv2.GMDv2(),
                _ => null
            };
        }
    }
}
