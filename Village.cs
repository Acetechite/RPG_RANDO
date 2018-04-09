using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace RPG_Rando
{
    public class Village
    {
        public string government { get; set; }
        public string income { get; set; }
        public Person[] people { get; set; }
    }
}