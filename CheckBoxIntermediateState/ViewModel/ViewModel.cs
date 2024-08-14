using System.ComponentModel;

namespace CheckBoxIntermediateState
{
    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private bool skip = false;

        // Properties for individual CheckBoxes
        private bool isPepperoniChecked;
        public bool IsPepperoniChecked
        {
            get => isPepperoniChecked;
            set
            {
                isPepperoniChecked = value;
                CheckIfSelectAll();
                OnPropertyChanged(nameof(IsPepperoniChecked));
            }
        }

        private bool isMushroomsChecked;
        public bool IsMushroomsChecked
        {
            get => isMushroomsChecked;
            set
            {
                isMushroomsChecked = value;
                CheckIfSelectAll();
                OnPropertyChanged(nameof(IsMushroomsChecked));
            }
        }

        private bool isOnionsChecked;
        public bool IsOnionsChecked
        {
            get => isOnionsChecked;
            set
            {
                isOnionsChecked = value;
                CheckIfSelectAll();
                OnPropertyChanged(nameof(IsOnionsChecked));
            }
        }

        // Property for the "Select All" CheckBox
        private bool? isIntermediate;
        public bool? IsIntermediate
        {
            get => isIntermediate;
            set
            {
                isIntermediate = value;
                IntermediateState();
                OnPropertyChanged(nameof(IsIntermediate));
            }
        }

        public ViewModel()
        {
            IsIntermediate = true;
        }

        private void CheckIfSelectAll()
        {
            if (!skip)
            {
                skip = true;
                if (IsPepperoniChecked && IsMushroomsChecked && IsOnionsChecked)
                {
                    IsIntermediate = true;
                }
                else if (!IsPepperoniChecked && !IsMushroomsChecked && !IsOnionsChecked)
                {
                    IsIntermediate = false;
                }
                else
                {
                    IsIntermediate = null;
                }
                skip = false;
            }
        }

        private void IntermediateState()
        {
            if (!skip)
            {
                skip = true;
                if (IsIntermediate == true)
                {
                    IsPepperoniChecked = IsMushroomsChecked = IsOnionsChecked = true;
                }
                else
                {
                    IsPepperoniChecked = IsMushroomsChecked = IsOnionsChecked = false;
                }
                skip = false;
            }
        }
    }
}
