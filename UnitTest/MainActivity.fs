namespace UnitTest

open System.Reflection

open Android.App
open Android.OS
open Xamarin.Android.NUnitLite

[<Activity (Label = "UnitTest", MainLauncher = true)>]
type MainActivity () =
    inherit TestSuiteActivity ()
    
    override this.OnCreate (bundle) =

        this.AddTest (Assembly.GetExecutingAssembly ());
    
        
        base.OnCreate (bundle)
