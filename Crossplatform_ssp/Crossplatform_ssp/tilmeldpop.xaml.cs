using MailKit.Net.Smtp;
using MimeKit;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;



namespace Crossplatform_ssp
{
  
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class tilmeldpop : PopupPage
    {
        public string getkeyy;
        public tilmeldpop(String getkey)
		{
			InitializeComponent();
            getkeyy = getkey;

        }

        public void tilbage(object sender, EventArgs e)
        {
            Navigation.PopPopupAsync();
        }


        public void tjekbtn(object sender, EventArgs e)
        {
            Console.WriteLine(getkeyy);
           
            if (_navn.Text == null || _efternavn.Text == null || _email.Text == null )
            {
                DisplayAlert("Fejl", "Udfyld venligst alle felter", "Ok");
            }
            else
            {
                _tjek.IsEnabled = false;
                _send.IsEnabled = true;
                
            }
        }

        public void sedeltagere(object sender, EventArgs e) {

            Navigation.PushPopupAsync(new spinnerpop(getkeyy));

        }

        public void godkendelseskode(object sender, EventArgs p) {


                 _activi.IsRunning = true;
            
                var navn = _navn.Text;
                var efternavn = _efternavn.Text;
                var email = _email.Text;

                var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                var numbers = "0123456789";
                var stringChars = new char[8];
                var random = new Random();


                for (int i = 0; i < 2; i++)
                {
                    stringChars[i] = chars[random.Next(chars.Length)];
                }
                for (int i = 2; i < 6; i++)
                {
                    stringChars[i] = numbers[random.Next(numbers.Length)];
                }
                for (int i = 6; i < 8; i++)
                {
                    stringChars[i] = chars[random.Next(chars.Length)];
                }

                var finalString = new String(stringChars);



                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("Godkendelse", "ssp_helsingor@hotmail.com"));
                message.To.Add(new MailboxAddress(navn, email));
                message.Subject = "Godkendelseskode";



                message.Body = new TextPart("plain")
                {
                    Text = navn + "<br>" + efternavn + "<br>" + email + "<br>" + "Godkendelseskode:" + finalString
                };
                using (var client = new SmtpClient())
                {
                    // For demo-purposes, accept all SSL certificates (in case the server supports STARTTLS)
                    client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                    client.Connect("smtp.outlook.com", 587, false);

                    // Note: only needed if the SMTP server requires authentication
                    client.Authenticate("ssp_helsingor@hotmail.com", "helsingor123");

                    client.Send(message);
                    client.Disconnect(true);
                }

                _kode.IsVisible = true;
                _godkend.IsVisible = true;

                _navn.IsVisible = false;
                _efternavn.IsVisible = false;
                _email.IsVisible = false;
                _send.IsVisible = false;
                _annuller.IsVisible = false;
                _tjek.IsVisible = false;


                _activi.IsRunning = false;

            _godkend.Clicked += async (object asas, EventArgs aaaa) =>
            {
           
                if (_kode.Text.Equals(finalString))
                {
                    _activi.IsRunning = true;
                    
                    var person = new DatabaseFolder.person(navn, efternavn, email);
                   


                    FirebaseFolder.FirebaseCubeBegivenhederDB db = new FirebaseFolder.FirebaseCubeBegivenhederDB();
                    await db.AddDeltager(getkeyy, person);

                   

                    _navn.Text = "";
                    _efternavn.Text = "";
                    _email.Text = "";

                    await Navigation.PopPopupAsync();
                    _activi.IsRunning = false;
                }
                else
                {
                    Console.WriteLine("oc, det virker ikke");
                }
            };
        }

       
    }
}