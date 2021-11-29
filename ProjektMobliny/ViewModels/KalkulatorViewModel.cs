using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Xamarin.Forms;

namespace ProjektMobliny.ViewModels
{
    public class KalkulatorViewModel : BaseViewModel
    {
        private string _screenVal;
        private List<string> _availableOperations = new List<string> { "+", "-", "*", "/" };
        private bool _isLastSignAnOperation;
        private DataTable _dataTable = new DataTable();
        public KalkulatorViewModel()
        {
            ScreenVal = "0";
            Title = "Kalkulator";

            AddNumberCommand = new Command(AddNumber);
            AddOperationCommand = new Command(AddOperation);
            ClearScreenCommand = new Command(ClearScreen);
            GetResultCommand = new Command(GetResult);
        }



        public Command AddNumberCommand { get; }
        public Command AddOperationCommand { get; }
        public Command ClearScreenCommand { get; }
        public Command GetResultCommand { get; }

        public string ScreenVal
        {
            get { return _screenVal; }
            set
            {
                SetProperty(ref _screenVal, value);
            }
        }

        public bool IsLastSignAnOperation
        {
            get { return _isLastSignAnOperation; }
            set
            {
                SetProperty(ref _isLastSignAnOperation, value);
                GetResultCommand.ChangeCanExecute();
                AddOperationCommand.ChangeCanExecute();
            }
        }

        private void AddNumber(object obj)
        {
            var number = obj as string;

            if (ScreenVal == "0" && number != ",")
                ScreenVal = string.Empty;
            else if (number == "," && _availableOperations.Contains(ScreenVal.Substring(ScreenVal.Length - 1)))
                number = "0,";

            ScreenVal += number;

            IsLastSignAnOperation = false;
        }

        private void GetResult(object obj)
        {
            var result = Math.Round(Convert.ToDouble(_dataTable.Compute(ScreenVal.Replace(",", "."), "")), 2);

            ScreenVal = result.ToString();
        }

        private void ClearScreen(object obj)
        {
            ScreenVal = "0";
            IsLastSignAnOperation = false;
        }

        private void AddOperation(object obj)
        {
            var operation = obj as string;

            ScreenVal += operation;

            IsLastSignAnOperation = true;
        }
    }
}
