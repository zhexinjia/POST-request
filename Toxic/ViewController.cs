using System;
using System.Collections.Generic;
using UIKit;

namespace Toxic
{
    public partial class ViewController : UIViewController
    {
        public static string storeLocation = "264 Valley River Center, Eugene";
        private string passCode = "1111";

        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            var list = new List<string> { "264 Valley River Center, Eugene", "943 River Road, Eugene" };

            var storesViewModel = new storePickerModel(list);

            storesViewModel.storeChanged += (sender, e) => 
            {
                storeLocation = storesViewModel.selectedStore;
            };


            storePicker.Model = storesViewModel;
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }


        partial void ClickedButton(UIButton sender)
        {
            if (pwField.Text.Equals(passCode)){
				DetailViewController detailView = this.Storyboard.InstantiateViewController("DetailController") as DetailViewController;
                detailView.passedValue = storeLocation;
				this.NavigationController.PushViewController(detailView, true);
            }else{
                UIAlertView alert = new UIAlertView()
                {
                    Title = "Wrong PassCode",
                    Message = "PassCode Incorrect..."
                };
                alert.AddButton("OK");
                alert.Show();
            }

        }
    }
}
