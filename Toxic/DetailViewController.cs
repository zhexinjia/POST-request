using Foundation;
using System;
using UIKit;
using System.Net;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Net.Http;

namespace Toxic
{
    public partial class DetailViewController : UIViewController
    {
		//list info about all store schedule
		private List<StoreInfo> storeInformation;
        private StoreInfo currentStore;

        //number of orders can be taken
        List<int> numbers;

		//used to pass store name from log in page to current page
		public string passedValue { get; set; }


        public DetailViewController (IntPtr handle) : base (handle)
        {
            storeInformation = new List<StoreInfo>();
            numbers = new List<int> { 1, 2, 3, 4, 5 };
            getInfo();
        }

        public override void LoadView()
        {
            base.LoadView();
            ReloadCallBack();
        }

		//get information from server
		private void getInfo()
		{
		    WebClient client = new WebClient();
			var scheduleInfo = client.UploadString("http://thetoxicwings.com/getTimes.php", "");
			storeInformation = JsonConvert.DeserializeObject<List<StoreInfo>>(scheduleInfo);
		}

		//return the single store info
		private StoreInfo getSingleSchedule()
		{
			foreach (var dataItem in storeInformation)
			{
				if (dataItem.storename.Equals(passedValue))
				{
					return dataItem;
				}
			}
			return null;
		}

        partial void buttonClicked(UIButton sender)
        {
            WebClient client = new WebClient();
            client.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
            string sql = "sql=" + getSQL();
            var param = new System.Collections.Specialized.NameValueCollection();
            param.Add("sql", getSQL());

            string method = "POST";
            string message = client.UploadString("http://thetoxicwings.com/setTimes.php", method, sql);

            if (message.Equals("success!")){
                UIAlertView alert = new UIAlertView()
                {
                    Title = "Update Success!",
                    Message = "Schedule Updated"
                };
                alert.AddButton("OK");
                alert.Show();
            }else{
                UIAlertView alert = new UIAlertView()
                {
                    Title = "Update Failed",
                    Message = "Please Check your Internet Connection or contact Developer"
                };
                alert.AddButton("OK");
                alert.Show();
            }
        }

        //return sql comment used to update database
        private String getSQL(){
            var name = currentStore.storename;
            List<String> columns = new List<string> { "time1", "time2", "time3", "time4", "time5" };
            string sql = "UPDATE times SET ";
            for (int i = 0; i < columns.Count; i++){
                sql += columns[i] + " = " + numbers[i];
                if (i != columns.Count-1){
                    sql += ", ";
                }
            }
            sql += " WHERE storename = '" + name + "';";
            return sql;
        }

        partial void Reload(UIButton sender)
        {
            getInfo();
            this.ReloadCallBack();
        }

        //reload the screen
        private void ReloadCallBack(){
            currentStore = getSingleSchedule();
            numbers[0] = currentStore.time1;
            numbers[1] = currentStore.time2;
            numbers[2] = currentStore.time3;
            numbers[3] = currentStore.time4;
            numbers[4] = currentStore.time5;

            var list = new List<int>();
            for (int i = 0; i < 21; i++)
            {
                list.Add(i);
            }

            var ModelList = new List<storePickerModel>();
            var timeViewModel1 = new storePickerModel(list);
            var timeViewModel2 = new storePickerModel(list);
            var timeViewModel3 = new storePickerModel(list);
            var timeViewModel4 = new storePickerModel(list);
            var timeViewModel5 = new storePickerModel(list);

            timeViewModel1.storeChanged += (sender, e) =>
            {
                numbers[0] = Int32.Parse(timeViewModel1.selectedStore);
            };
            timePicker1.Model = timeViewModel1;
            timePicker1.Select(numbers[0], 0, true);

            timeViewModel2.storeChanged += (sender, e) =>
            {
                numbers[1] = Int32.Parse(timeViewModel2.selectedStore);
            };
            timePicker2.Model = timeViewModel2;
            timePicker2.Select(numbers[1], 0, true);

            timeViewModel3.storeChanged += (sender, e) =>
            {
                numbers[2] = Int32.Parse(timeViewModel3.selectedStore);
            };
            timePicker3.Model = timeViewModel3;
            timePicker3.Select(numbers[2], 0, true);

            timeViewModel4.storeChanged += (sender, e) =>
            {
                numbers[3] = Int32.Parse(timeViewModel4.selectedStore);
            };
            timePicker4.Model = timeViewModel4;
            timePicker4.Select(numbers[3], 0, true);

            timeViewModel5.storeChanged += (sender, e) =>
            {
                numbers[4] = Int32.Parse(timeViewModel5.selectedStore);
            };
            timePicker5.Model = timeViewModel5;
            timePicker5.Select(numbers[4], 0, true);

            //FIXME: array index out of range???????WHY????
            /*
            var timePickerList = new List<UIPickerView>();
            timePickerList.Add(timePicker1);
            timePickerList.Add(timePicker2);
            timePickerList.Add(timePicker3);
            timePickerList.Add(timePicker4);
            timePickerList.Add(timePicker5);
            ModelList.Add(timeViewModel1);
            ModelList.Add(timeViewModel2);
            ModelList.Add(timeViewModel3);
            ModelList.Add(timeViewModel4);
            ModelList.Add(timeViewModel5);

            for (int i = 0; i < 5; i++)
            {
                ModelList[i].storeChanged += (sender, e) => 
                {
                    numbers[i] = Int32.Parse(ModelList[0].selectedStore);
                };
                timePickerList[i].Model = ModelList[i];
            }
            */
        }




    }
}