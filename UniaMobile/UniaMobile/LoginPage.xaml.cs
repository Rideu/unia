using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using UniaMobile.Pages;

namespace UniaMobile
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();

        }

        //bool confirmed = false;

        void signInClick(object s, EventArgs e)
        {
            if (signInEditor.Text == "1234")
            {
                App.Current.MainPage = new RegexPage();
            }
        }

        private void Label_Focused(object sender, FocusEventArgs e)
        {

        }

        private void SwipeGestureRecognizer_Swiped(object sender, SwipedEventArgs e)
        {

        }
    }
}
