using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UniaMobile.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegexPage : ContentPage
    {
        public RegexPage()
        {
            InitializeComponent();
            RegexText.Text = SampleText.Text = "";
        }

        private void SampleText_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (RegexText.Text != null && SampleText.Text != null)
                ResultProvider.SetData(SampleText.Text, RegexText.Text);
        }
    }
}