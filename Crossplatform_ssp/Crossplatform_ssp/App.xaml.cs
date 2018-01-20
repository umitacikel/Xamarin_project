﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Crossplatform_ssp
{
	public partial class App : Application
	{
       /* 
        static DatabaseFolder.DatabaseCubeBegivenhedController db_cb;
        static DatabaseFolder.DatabaseCubeOpslagController db_co;
        static DatabaseFolder.DatabaseTetrizBegivenhedController db_tb;
        static DatabaseFolder.DatabaseTetrizOpslagController db_to;
        static DatabaseFolder.DatabaseSSPUngRådController db_ur;
        static DatabaseFolder.DatabaseSSPFritidspassController db_fp;
        static DatabaseFolder.DatabaseTCPersonaleController db_tcp;

    */
        public static MasterDetailPage MasterDetail { get; set; }

        public async static Task NavigateMasterDetail(Page page)
        {
            App.MasterDetail.IsPresented = false;
            await App.MasterDetail.Detail.Navigation.PushAsync(page);
        }

        public App ()
		{
			InitializeComponent();

			MainPage = new Crossplatform_ssp.MainPage();
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}



        

    }
}
