using System.ComponentModel.Composition;
using MvvmCross.ViewModels;
using Ruminoid.Studio.Project;

namespace Ruminoid.Studio.Transaction
{
    [Export]
    public sealed class ActionManager : MvxNotifyPropertyChanged
    {
        #region Constructor

        [ImportingConstructor]
        public ActionManager(ProjectManager projectManager)
        {
            _projectManager = projectManager;
        }

        #endregion

        private ProjectManager _projectManager;
    }
}
