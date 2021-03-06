﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remotely_Desktop.Win.ViewModels
{
    public class HostNamePromptViewModel : INotifyPropertyChanged
    {
        public static HostNamePromptViewModel Current { get; private set; }
        public HostNamePromptViewModel()
        {
            Current = this;
        }
        public string Host { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
