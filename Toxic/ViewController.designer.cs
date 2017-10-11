// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace Toxic
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField pwField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel showID { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton signInButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIPickerView storePicker { get; set; }

        [Action ("ClickedButton:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void ClickedButton (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (pwField != null) {
                pwField.Dispose ();
                pwField = null;
            }

            if (showID != null) {
                showID.Dispose ();
                showID = null;
            }

            if (signInButton != null) {
                signInButton.Dispose ();
                signInButton = null;
            }

            if (storePicker != null) {
                storePicker.Dispose ();
                storePicker = null;
            }
        }
    }
}