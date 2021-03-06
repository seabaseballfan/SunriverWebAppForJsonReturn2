﻿using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Web.Script.Serialization;
using System.Runtime.Serialization.Json;
using System.Web.Services;
using System.Collections.Generic;
using System.IO;

namespace SunriverWebApp {
    public partial class FindCountyAddress1 : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            String resortAddress = Request.QueryString["resortAddress"];
            MemoryStream ms = new MemoryStream();
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(List<CountyAddress>));
            if (resortAddress.Substring(0, 2).Equals("|~")) { // signifies a version 2 of the data
                ser.WriteObject(ms, CountyAddress.FindCountyAddress(resortAddress.Substring(2)));
            } else {
                ser.WriteObject(ms, new CountyAddress(resortAddress));
            }
            ms.Flush();
            ms.Position = 0;
            System.IO.StreamReader sr = new StreamReader(ms);
            string str = sr.ReadToEnd();
            ms.Close();
            sr.Close();
            Response.Clear();
            Response.ContentType = "application/json; charset=utf-8";
            Response.Write(str);
            Response.End();
        }
    }
}
