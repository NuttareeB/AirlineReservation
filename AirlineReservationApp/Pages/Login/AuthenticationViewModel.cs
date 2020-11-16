using AirlineReservationApp.AuthenticationService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace AirlineReservationApp
{
    public class AuthenticationViewModel : INotifyPropertyChanged
    {
        private readonly IAuthenticationService _authenticationService;
        private string _username;
        private string _status;

        public AuthenticationViewModel(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
            LoginCommand = new DelegateCommand(Login, CanLogin);
            LogoutCommand = new DelegateCommand(Logout, CanLogout);
        }

        #region Properties
        //public NavigationService NavigationService { get; set; }
        public string Username
        {
            get { return _username; }
            set { _username = value; NotifyPropertyChanged("Username"); }
        }

        public string AuthenticatedUser
        {
            get
            {
                if (IsAuthenticated)
                    return string.Format("Signed in as {0}. {1}",
                          Thread.CurrentPrincipal.Identity.Name,
                          Thread.CurrentPrincipal.IsInRole(Role.Admin.ToString()) ? "You are an administrator!"
                              : "You are NOT a member of the administrators group.");

                return "Not authenticated!";
            }
        }

        public string Status
        {
            get { return _status; }
            set { _status = value; NotifyPropertyChanged("Status"); }
        }
        #endregion

        #region Commands
        public DelegateCommand LoginCommand { get; }

        public DelegateCommand LogoutCommand { get; }

        #endregion

        private void Login(object parameter)
        {
            PasswordBox passwordBox = parameter as PasswordBox;
            string clearTextPassword = passwordBox.Password;
            try
            {
                //Validate credentials through the authentication service
                User user = _authenticationService.AuthenticateUser(Username, clearTextPassword);

                if (user == null)
                {
                    throw new UnauthorizedAccessException("Access denied. Please provide some valid credentials.");
                }

                //Get the current principal object
                if (!(Thread.CurrentPrincipal is CustomPrincipal customPrincipal))
                    throw new ArgumentException("The application's default thread principal must be set to a CustomPrincipal object on startup.");

                //Authenticate the user
                customPrincipal.Identity = new CustomIdentity(user.UserDao.FirstName, user.UserDao.LastName, user.UserDao.Age, user.UserDao.Roles.ToList());

                //Update UI
                UpdateUI();
                Username = string.Empty; //reset
                passwordBox.Password = string.Empty; //reset
                Status = string.Empty;

            }
            catch (UnauthorizedAccessException)
            {
                Status = "Login failed! Please provide some valid credentials.";
            }
            catch (Exception ex)
            {
                Status = string.Format("ERROR: {0}", ex.Message);
            }
        }

        private bool CanLogin(object parameter)
        {
            return IsNotAuthenticated;
        }

        private void Logout(object parameter)
        {
            CustomPrincipal customPrincipal = Thread.CurrentPrincipal as CustomPrincipal;
            if (customPrincipal != null)
            {
                customPrincipal.Identity = new AnonymousIdentity();
                UpdateUI();
                Status = string.Empty;
            }
        }

        private void UpdateUI()
        {
            NotifyPropertyChanged("AuthenticatedUser");
            NotifyPropertyChanged("IsAuthenticated");
            NotifyPropertyChanged("IsNotAuthenticated");
            LoginCommand.RaiseCanExecuteChanged();
            LogoutCommand.RaiseCanExecuteChanged();
        }
        private bool CanLogout(object parameter)
        {
            return IsAuthenticated;
        }

        public bool IsAuthenticated
        {
            get { return Thread.CurrentPrincipal.Identity.IsAuthenticated; }
        }

        public bool IsNotAuthenticated
        {
            get { return !IsAuthenticated; }
        }

        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
