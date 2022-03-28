using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Windows.Media;
using System.Windows.Threading;
using System.Windows;

namespace agentAssignment
{
    public class MainWindowViewModel : BindableBase
    {
        ObservableCollection<Agent> agents;

        public MainWindowViewModel()
        {
            agents = new ObservableCollection<Agent>();
            agents.Add(new Agent("001", "Tom Jenkins", "Infiltration", "Sudan"));
            agents.Add(new Agent("003", "Erwin Baker", "Exfiltration", "Mosambique"));
            agents.Add(new Agent("007", "James Bond", "Assasination", "Korea"));
            CurrentAgent = agents[0];

        }

        #region Properties

        Agent currentAgent = new Agent("001", "Tom Jenkins", "Infiltration", "Sudan");

        private Agent _currentAgent;
        public Agent CurrentAgent
        {
            get { return _currentAgent; }
            set { SetProperty(ref _currentAgent, value); }

        }

        private int _currentIndex;

        public int CurrentIndex
        {
            get { return _currentIndex; }
            set { SetProperty(ref _currentIndex, value); }
        }

        public ObservableCollection<Agent> Agents
        {
            get
            {
                return agents;
            }
        }
        #endregion
        
        #region Methods

        public void AddNewAgent()
        {
            agents.Add(new Agent());
        }

        #endregion

        #region Commands

        private DelegateCommand? _previousCommand;
        public DelegateCommand PreviousCommand =>
        _previousCommand ?? (_previousCommand = new DelegateCommand(ExecutePreviousCommand, CanExecutePreviousCommand)
        .ObservesProperty(() => CurrentIndex));
        void ExecutePreviousCommand()
        {
            if (CurrentIndex > 0)
                --CurrentIndex;
        }
        bool CanExecutePreviousCommand()
        {
            if (CurrentIndex > 0)
                return true;
            else
                return false;
        }

        private DelegateCommand? _nextCommand;
        public DelegateCommand NextCommand =>
        _nextCommand ?? (_nextCommand = new DelegateCommand(ExecuteNextCommand, CanExecuteNextCommand)
        .ObservesProperty(() => CurrentIndex));
        void ExecuteNextCommand()
        {
            if (CurrentIndex < Agents.Count-1)
                ++CurrentIndex;
        }
        bool CanExecuteNextCommand()
        {
            if (CurrentIndex < Agents.Count-1)
                return true;
            else
                return false;
        }

        private DelegateCommand? _addAgentCommand;
        public DelegateCommand AddAgentCommand => 
            _addAgentCommand ?? (_addAgentCommand = new DelegateCommand(ExecuteAddAgentCommand)
            .ObservesProperty(() => CurrentIndex));
  
        void ExecuteAddAgentCommand()
        {
            Agents.Add(new Agent());
            CurrentIndex = Agents.Count - 1;
        }

        private DelegateCommand? _deleteAgentCommand;
        public DelegateCommand DeleteAgentCommand =>
            _deleteAgentCommand ?? (_deleteAgentCommand = new DelegateCommand(ExecuteDeleteAgentCommand, CanExecuteDeleteAgentCommand)
            .ObservesProperty(() => CurrentIndex));

        void ExecuteDeleteAgentCommand()
        {
            if (CurrentAgent != null) 
            {
                Agents.Remove(CurrentAgent);
            }
        }
        bool CanExecuteDeleteAgentCommand()
        {
            if (CurrentAgent != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private DelegateCommand? _exitCommand;
        public DelegateCommand ExitCommand =>
            _exitCommand ?? (_exitCommand = new DelegateCommand(ExecuteExitCommand)
            .ObservesProperty(() => CurrentIndex));

        void ExecuteExitCommand()
        {
            App.Current.MainWindow.Close();
        }

        private DelegateCommand<string> _changeColorCommand;
        public DelegateCommand<string> ChangeColorCommand =>
            _changeColorCommand ?? (_changeColorCommand = new DelegateCommand<string>(ExecuteChangeColorCommand));


        void ExecuteChangeColorCommand(string colorStr)
        {
            SolidColorBrush newBrush = SystemColors.WindowBrush;
            if (colorStr != null)
                if (colorStr != "Default")
                    newBrush = new SolidColorBrush(
                    (Color)ColorConverter.ConvertFromString(colorStr));
            Application.Current.Resources["backgroundColor"] = newBrush;
        }

        #endregion

        Clock clock = new Clock();
        public Clock Clock { get => clock; set => clock = value; }
    }
}
        