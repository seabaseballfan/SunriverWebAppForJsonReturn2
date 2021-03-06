﻿using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using Newtonsoft.Json;
using System.Text;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Web.Services;
using System.Collections.Generic;
using System.IO;
using System.Web.Script.Serialization;
using System.Runtime.Serialization.Json;

namespace SunriverWebApp {
    public partial class GISLayers1 : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            MemoryStream ms = new MemoryStream();
            JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
            using (JsonTextWriter jsonTextWriter = new JsonTextWriter(
                new StreamWriter(ms, new UTF8Encoding(false, true))) { CloseOutput = false }) {
                serializer.Serialize(jsonTextWriter, new GISLayers().buildList());
                jsonTextWriter.Flush();
            }
            Utils.jsonSerializeStep2(ms, Response);

        }
    }
}
