// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace Toxic
{
    [Register ("DetailViewController")]
    partial class DetailViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel testLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIPickerView timePicker1 { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIPickerView timePicker2 { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIPickerView timePicker3 { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIPickerView timePicker4 { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIPickerView timePicker5 { get; set; }

        [Action ("buttonClicked:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void buttonClicked (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (testLabel != null) {
                testLabel.Dispose ();
                testLabel = null;
            }

            if (timePicker1 != null) {
                timePicker1.Dispose ();
                timePicker1 = null;
            }

            if (timePicker2 != null) {
                timePicker2.Dispose ();
                timePicker2 = null;
            }

            if (timePicker3 != null) {
                timePicker3.Dispose ();
                timePicker3 = null;
            }

            if (timePicker4 != null) {
                timePicker4.Dispose ();
                timePicker4 = null;
            }

            if (timePicker5 != null) {
                timePicker5.Dispose ();
                timePicker5 = null;
            }
        }
    }
}