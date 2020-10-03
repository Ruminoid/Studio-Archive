using System.ComponentModel.Composition;

namespace Ruminoid.Studio.Project
{
    [Export]
    public sealed class ProjectManager
    {
        public RumiProject Project { get; private set; }

        public void Load(string projectPath)
        {

        }
    }
}
