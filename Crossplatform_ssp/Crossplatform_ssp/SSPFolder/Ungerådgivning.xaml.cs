using Crossplatform_ssp.DatabaseFolder;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Crossplatform_ssp.SSPFolder
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Ungerådgivning : ContentPage
	{
        FirebaseFolder.FirebaseSSPUngeråd FbClientUngRåd = new FirebaseFolder.FirebaseSSPUngeråd();

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var list = await FbClientUngRåd.GetUngrådList();
            listviewungråd.BindingContext = list;
        }

        ContentPage UngRåd_pop = new ContentPage
        {
            BackgroundColor = Color.White,
            Padding = new Thickness(20, 20, 20, 20),
        };

        static Editor UngRåd_Besked = new Editor()
        {
            HorizontalOptions = LayoutOptions.Fill,
            HeightRequest = 200,
            Margin = new Thickness(10),
            BackgroundColor = Color.Silver
        };


        static Button UngRåd_SendBtn = new Button()
        {
            HorizontalOptions = LayoutOptions.Fill,
            VerticalOptions = LayoutOptions.Fill,
            BackgroundColor = Color.Green,
            Margin = new Thickness(10),
            Text = "Send"
        };

        static Button annullerBtn = new Button()
        {
            HorizontalOptions = LayoutOptions.Fill,
            VerticalOptions = LayoutOptions.Fill,
            BackgroundColor = Color.Red,
            Margin = new Thickness(10),
            Text = "Afslut"
        };

        static StackLayout Opret_buttons = new StackLayout()
        {
            HorizontalOptions = LayoutOptions.Fill,
            VerticalOptions = LayoutOptions.Fill,
            Orientation = StackOrientation.Horizontal,
            Children = { UngRåd_SendBtn, annullerBtn }
        };

        StackLayout Opret_lay = new StackLayout()
        {
            VerticalOptions = LayoutOptions.CenterAndExpand,
            HorizontalOptions = LayoutOptions.FillAndExpand,
            Orientation = StackOrientation.Vertical,
            Children =
          {UngRåd_Besked, Opret_buttons }
        };

        public Ungerådgivning ()
		{
			InitializeComponent ();

           
           

            annullerBtn.Clicked += (o, i) =>
            {
                Navigation.PopModalAsync();
            };

        }

        private void Send_EmailBtn(object sender, EventArgs e)
        {
            UngRåd_pop.Content = Opret_lay;
            UngRåd_SendBtn.IsEnabled = true;
            annullerBtn.IsEnabled = false;
            Navigation.PushModalAsync(UngRåd_pop, false);


            UngRåd_SendBtn.Clicked += (sende, i) =>
            {
                if (UngRåd_Besked.Text == null)
                {
                    DisplayAlert("Fejl", "Skriv venligst en besked", "Ok");
                }
                else
                {
                    try
                    {
                        SmtpClient client = new SmtpClient("smtp.outlook.com", 587);
                        client.EnableSsl = true;
                        client.DeliveryMethod = SmtpDeliveryMethod.Network;
                        client.UseDefaultCredentials = false;
                        client.Credentials = new NetworkCredential("ssp_helsingor@hotmail.com", "helsingor123");
                        MailMessage msg = new MailMessage();
                        msg.To.Add("umitacike@live.dk");
                        msg.From = new MailAddress("ssp_helsingor@hotmail.com");
                        msg.Subject = "Åben Anonym Ungerådgivning";
                        msg.Body = UngRåd_Besked.Text;
                        client.Send(msg);

                        DisplayAlert("Information", "Din E-mail er blevet sendt, vi vil kontakte dig, hurtigst muligt", "ok");
                        annullerBtn.IsEnabled = true;
                        UngRåd_SendBtn.IsEnabled = false;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                }
            };
        }

        private void åben_opkaldBtn(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("tel:25512492"));

        }

        private async Task listviewungråd_RefreshingAsync(object sender, EventArgs e)
        {
            listviewungråd.BindingContext = await FbClientUngRåd.GetUngrådList();
            listviewungråd.IsRefreshing = false;
        }
    }
}