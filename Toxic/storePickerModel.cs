using System;
using System.Collections.Generic;
using UIKit;

namespace Toxic
{
    internal class storePickerModel : UIPickerViewModel
    {
        private List<string> list;
        public event EventHandler storeChanged;
        public string selectedStore { get; private set; }

        public storePickerModel(List<string> list)
        {
            this.list = list;
        }
        public storePickerModel(List<int> list){
            this.list = new List<string>();
            foreach(var item in list){
                this.list.Add(item.ToString());
            }
        }

        public override System.nint GetRowsInComponent(UIPickerView pickerView, nint component)
        {
            return list.Count;
        }

        public override System.nint GetComponentCount(UIPickerView pickerView)
        {
            return 1;
        }

        public override string GetTitle(UIPickerView pickerView, nint row, nint component)
        {
            return list[(int)row];
        }

        public override void Selected(UIPickerView pickerView, nint row, nint component)
        {
            var store = list[(int)row];
            selectedStore = store;
            storeChanged?.Invoke(null, null);
        }

        //only call this function in DetailViewController
        public int getNumber(){
            int x = Int32.Parse(selectedStore);
            return x;
        }
    }
}