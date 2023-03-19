using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace TemplateGenerator.MVVM
{
    public class MainVM : BaseViewModel
    {
        #region fields
        private BitmapImage _ProgramCapturedImage;
        private List<Process> _Services;
        private Process _SelectedService;
        #endregion
        #region propperties
        public BitmapImage ProgramCapturedImage
        {
            get { return _ProgramCapturedImage; }
            set { SetPropperty(ref _ProgramCapturedImage, value, nameof(ProgramCapturedImage)); }
        }
        public Process SelectedService 
        { 
            get { return _SelectedService; } 
            set { SetPropperty(ref _SelectedService, value, nameof(SelectedService)); } 
        }
        public List<Process> Services 
        { 
            get { return _Services; } 
            set { SetPropperty(ref _Services, value, nameof(Services)); } 
        }

        public ICommand ReloadProcessesCommand => new RelayCommand(CanReloadProcesses, ReloadProcesses);
        #endregion

        public MainVM()
        {
        }

        private bool CanReloadProcesses(object obj)
        {
            return true;
        }

        private void ReloadProcesses(object arg)
        {
            Services = Process.GetProcesses().OrderBy(o => o.ProcessName).ToList();
        }
    }
}
