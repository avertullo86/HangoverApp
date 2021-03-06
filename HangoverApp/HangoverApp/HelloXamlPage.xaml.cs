﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HangoverApp
{
    public partial class HelloXamlPage : ContentPage
    {
        public HelloXamlPage()
        {
            //this.LoadFromXaml(typeof(HelloXamlPage));

            //BindingContext = loginViewModel = new LoginViewModel(this);
            var activityIndicator = new ActivityIndicator
            {
                Color = Color.FromHex("#8BC34A"),
            };
            activityIndicator.SetBinding(IsVisibleProperty, "IsBusy");
            activityIndicator.SetBinding(ActivityIndicator.IsRunningProperty, "IsBusy");
            //  BackgroundColor = Color.Blue;
            BackgroundImage = "LoginScreen.png";
            var layout = new StackLayout { Padding = 20 };
            layout.Children.Add(activityIndicator);
            var label = new Label
            {
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                TextColor = Color.White,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                XAlign = TextAlignment.Center,
                YAlign = TextAlignment.Center,

            };

            var backgroundImage = new Image()
            {
                Aspect = Aspect.Fill,
                Source = FileImageSource.FromFile("LoginScreen.png")
            };

            layout.Children.Add(label);

            var username = new Entry { Placeholder = "Username", TextColor = Color.White };
            //username.SetBinding(Entry.TextProperty, LoginViewModel.UsernamePropertyName);
            layout.Children.Add(username);

            var password = new Entry { Placeholder = "Password", IsPassword = true, TextColor = Color.White };
            //password.SetBinding(Entry.TextProperty, LoginViewModel.PasswordPropertyName);
            layout.Children.Add(password);

            var relativelayout = new RelativeLayout();

            var button = new Button { Text = "Feed Me!", TextColor = Color.White, BackgroundColor = Color.FromHex("#8BC34A") };
            //button.SetBinding(Button.CommandProperty, LoginViewModel.LoginCommandPropertyName);

            layout.Children.Add(button);
            relativelayout.Children.Add(backgroundImage,
                Constraint.Constant(0),
                Constraint.Constant(0),
                Constraint.RelativeToParent((parent) => { return parent.Width; }),
                Constraint.RelativeToParent((parent) => { return parent.Height; }));

            relativelayout.Children.Add(layout,
                Constraint.Constant(0),
                Constraint.Constant(0),
                Constraint.RelativeToParent((parent) => { return parent.Width; }),
                Constraint.RelativeToParent((parent) => { return parent.Height; }));


            button.Clicked += (sender, e) =>
            {
                if (String.IsNullOrEmpty(username.Text) || String.IsNullOrEmpty(password.Text))
                {
                    DisplayAlert("Validation Error", "Username and Password are required", "Re-try");
                }
                else
                {
                    // REMEMBER LOGIN STATUS!
                    App.Current.Properties["IsLoggedIn"] = true;
                    //ilm.ShowRootPage();
                }
            };

            Content = new ScrollView { Content = relativelayout };

        }

    }
}
