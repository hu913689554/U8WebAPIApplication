using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class BomDTO
{
    public string Cinvcode { get; set; }

    public string VersionDesc { get; set; }

    public string VsDate { get; set; }

    public string VeDate { get; set; }

    public string sAccID { get; set; }

    public string sYear { get; set; }

    public string sUserID { get; set; }

    public string sPassword { get; set; }

    public string sDate { get; set; }

    public string sServer { get; set; }

    public string PartentID { get; set; }

    public string BomType { get; set; }

    public string IdentCode { get; set; }

    public string IdentDesc { get; set; }

    public string CusCode { get; set; }

    public List<BomLineDTO> bomline { get; set; }
}
