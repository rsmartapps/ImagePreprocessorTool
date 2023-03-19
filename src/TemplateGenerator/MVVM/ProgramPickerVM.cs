using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TemplateGenerator.MVVM
{
    public class ProgramPickerVM : BaseViewModel
    {
        #region fields
        private List<Process> _Services;
        private Process _SelectedService;
        #endregion
        #region propperties
        public Process SelectedService { get { return _SelectedService; } set { SetPropperty(ref _SelectedService, value, nameof(_SelectedService)); } }
        public List<Process> Services { get { return _Services; } set { SetPropperty(ref _Services, value, nameof(_Services)); } }
        #endregion

        public ProgramPickerVM()
        {
            Services = Process.GetProcesses().ToList();
        }
    }
}
