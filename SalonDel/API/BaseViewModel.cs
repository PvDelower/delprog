using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace API
{
    public abstract class  BaseViewModel : INotifyPropertyChanged
    {
        protected UnitOfWork unitOfWork;
        protected Window rootWindow;
        public BaseViewModel(Window rootWindow)
        {
            this.rootWindow = rootWindow;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop="")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
