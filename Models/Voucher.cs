
//using Helpers;
//using Newtonsoft.Json.Linq;
//using System;
//using System.Collections.Generic;
//using System.Drawing;
//using System.Linq;
//using System.Web.UI.WebControls;
//using U8Login;
//using USERPCO;
//namespace U8API
//{
//    public class Voucher
//    {
//        //新增数据
//        public List<Dictionary<string, object>> Create(U8Login.clsLogin clsLogin, string billType, JObject Head, JArray Body, JArray Pos, ref string msg, ref string VouchId)
//        {
//            ADODB.Connection conn = null;
//            MSXML2.IXMLDOMDocument2 domMsg = new MSXML2.DOMDocument();
//            List<Dictionary<string, object>>  domMsgList = new List<Dictionary<string, object>>(); // 初始化返回列表
            
//            try
//            {
//                conn = CreateConnection(clsLogin);
//                conn.BeginTrans();

//                MSXML2.DOMDocument domHead = new MSXML2.DOMDocument();
//                MSXML2.DOMDocument domBody = new MSXML2.DOMDocument();
//                MSXML2.DOMDocument domPos = new MSXML2.DOMDocument();

//                //单据头dom
//                string sqlhead = "";
//                string sqlbody = "";
//                if (billType == "08")
//                {
//                    sqlhead = "select m.* from kcotherinh m with(nolock) where 1=2";
//                    sqlbody = "select '' as editprop,m.* from kcotherinb m with(nolock) where 1=2";
//                }
//                else if (billType == "09")
//                {
//                    sqlhead = "select m.* from KCOtherOutH m with(nolock) where 1=2";
//                    sqlbody = "select '' as editprop,m.* from KCOtherOutB m with(nolock) where 1=2";
//                }
//                else
//                {
//                    throw new Exception("系统目前不支持该类型的单据" + billType);
//                }

//                domHead = Util.getDom(sqlhead, clsLogin.UfDbName);
//                Util.ConvertHeadXML(domHead, Head);
//                string xml = domHead.xml;
//                //单据体dom
//                domBody = Util.getDom(sqlbody, clsLogin.UfDbName);
//                Util.ConvertBodyXML(domBody, Body);
//                xml = domBody.xml;

//                System.Diagnostics.Debug.WriteLine("----------开始----------------");
//                System.Diagnostics.Debug.WriteLine(domHead.xml);
//                System.Diagnostics.Debug.WriteLine(domBody.xml);
//                System.Diagnostics.Debug.WriteLine(domPos.xml);
//                System.Diagnostics.Debug.WriteLine("----------结束----------------");
//                var VCO = new USERPCO.VoucherCO();
//                VCO.IniLogin(clsLogin, ref msg);
//                if (!string.IsNullOrEmpty(msg))
//                {
//                    throw new Exception(msg);
//                }
//                bool bsucess = VCO.Insert(billType, domHead, domBody, domPos, ref msg, ref conn, ref VouchId, ref domMsg);

//                if (!bsucess)
//                {
//                    System.Diagnostics.Debug.WriteLine("----------msg----------------" + msg);
//                    System.Diagnostics.Debug.WriteLine("----------domMsg0----------------" + domMsg.xml);

//                    // 解析domMsg中的<z:row>转成List<Dictionary<string, object>>
//                    if (!string.IsNullOrEmpty(domMsg.xml))
//                    {
//                        domMsgList = ParseDomMsgToList(domMsg);
                        
//                        string stockMsg = ParseDomMsgStockInfo(domMsgList);
//                        if (!string.IsNullOrEmpty(stockMsg))
//                        {
//                            msg = stockMsg;
//                        }
//                        return domMsgList;
//                    }

//                    if (!string.IsNullOrEmpty(msg)) { throw new Exception(msg); }
//                }
//                System.Diagnostics.Debug.WriteLine("----------VouchId----------------" + VouchId);
//                conn.CommitTrans();
//                clsLogin.ShutDown();
//                return domMsgList;
//            }
//            catch (Exception ex)
//            {
//                msg = "新增失败：" + ex.Message;
//                System.Diagnostics.Debug.WriteLine("----------msg----------------" + msg);
//                System.Diagnostics.Debug.WriteLine("----------domMsg----------------" + domMsg.xml);
//                if (conn != null)
//                {
//                    try
//                    {
//                        conn.RollbackTrans();
//                    }
//                    catch { }
//                }
//                throw;
//            }
//            finally
//            {
//                if (conn != null)
//                {
//                    try
//                    {
//                        if (conn.State == 1) // adStateOpen
//                        {
//                            conn.Close();
//                        }
//                    }
//                    catch { }
//                }
//            }
//        }

//        /// <summary>
//        /// 解析domMsg中的<z:row>转成List<Dictionary<string, object>>
//        /// </summary>
//        private List<Dictionary<string, object>> ParseDomMsgToList(MSXML2.IXMLDOMDocument2 domMsg)
//        {
//            var result = new List<Dictionary<string, object>>();

//            try
//            {
//                MSXML2.IXMLDOMNodeList rows = domMsg.selectNodes("//z:row");
//                if (rows == null || rows.length == 0)
//                    rows = domMsg.selectNodes("//*[local-name()='row']");

//                if (rows == null || rows.length == 0)
//                    return result;

//                foreach (MSXML2.IXMLDOMNode row in rows)
//                {
//                    var element = (MSXML2.IXMLDOMElement)row;
//                    var dict = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);

//                    if (element.attributes != null)
//                    {
//                        foreach (MSXML2.IXMLDOMNode attr in element.attributes)
//                        {
//                            dict[attr.nodeName] = attr.nodeValue?.ToString() ?? "";
//                        }
//                    }

//                    result.Add(dict);
//                }
//            }
//            catch (Exception ex)
//            {
//                System.Diagnostics.Debug.WriteLine("ParseDomMsgToList异常: " + ex.Message);
//            }

//            return result;
//        }

//        /// <summary>
//        /// 解析domMsg中的库存不足信息
//        /// </summary>
//        private string ParseDomMsgStockInfo(List<Dictionary<string, object>> domMsgList)
//        {
//            try
//            {
//                var items = new List<string>();

//                foreach (var row in domMsgList)
//                {
//                    string cinvcode = row.ContainsKey("cinvcode") ? row["cinvcode"]?.ToString() ?? "" : "";
//                    string cinvname = row.ContainsKey("cinvname") ? row["cinvname"]?.ToString() ?? "" : "";
//                    string iavaquantity = row.ContainsKey("iavaquantity") ? row["iavaquantity"]?.ToString() ?? "" : "";

//                    if (string.IsNullOrEmpty(cinvcode) || cinvcode == "存货编码")
//                        continue;

//                    if (!string.IsNullOrEmpty(cinvname))
//                    {
//                        items.Add($"{cinvcode}|{cinvname}|可用:{iavaquantity}");
//                    }
//                    else
//                    {
//                        items.Add($"{cinvcode}|可用:{iavaquantity}");
//                    }
//                }

//                if (items.Count > 0)
//                {
//                    return "库存不足：" + string.Join("; ", items);
//                }

//                return "";
//            }
//            catch (Exception ex)
//            {
//                System.Diagnostics.Debug.WriteLine("ParseDomMsgStockInfo异常: " + ex.Message);
//                return "";
//            }
//        }

//        /// <summary>
//        /// 获取XML元素的属性值
//        /// </summary>
//        private string GetNodeAttribute(MSXML2.IXMLDOMElement element, string attrName)
//        {
//            try
//            {
//                MSXML2.IXMLDOMAttribute attr = element.getAttributeNode(attrName);
//                if (attr != null)
//                    return attr.nodeValue?.ToString() ?? "";
//                return "";
//            }
//            catch
//            {
//                return "";
//            }
//        }
//        //查询数据
//        public Dictionary<string, object> Select(U8Login.clsLogin clsLogin, string billType, string id, ref string msg)
//        {
//            var VCO = new USERPCO.VoucherCO();
//            VCO.IniLogin(clsLogin, ref msg);
//            if (!string.IsNullOrEmpty(msg))
//            {
//                throw new Exception(msg);
//            }
//            MSXML2.IXMLDOMDocument2 domHead = new MSXML2.DOMDocumentClass();
//            MSXML2.IXMLDOMDocument2 domBody = new MSXML2.DOMDocumentClass();
//            MSXML2.IXMLDOMDocument2 domPos = new MSXML2.DOMDocumentClass();
//            bool bb = VCO.Load(billType, "ID='" + id + "'", ref domHead, ref domBody, ref domPos, ref msg, false, "");
//            string xml = domHead.xml;
//            xml = domBody.xml;
//            xml = domPos.xml;
//            if (!string.IsNullOrEmpty(msg))
//            {
//                throw new Exception(msg);
//            }
//            System.Diagnostics.Debug.WriteLine(domHead.xml);
//            System.Diagnostics.Debug.WriteLine(domBody.xml);
//            System.Diagnostics.Debug.WriteLine(domPos.xml);

//            object domHeadData = XmlRsDataConverter.ConvertXmlToObject(domHead.xml);
//            //domHeadData取第一个值改成对象 如果为空 则设为空对象
//            if (domHeadData is List<Dictionary<string, object>> list && list.Count > 0)
//            {
//                domHeadData = list[0];
//            }
//            else
//            {
//                domHeadData = new Dictionary<string, object>();
//            }
//            object domBodyData = XmlRsDataConverter.ConvertXmlToObject(domBody.xml);
//            object domPosData = XmlRsDataConverter.ConvertXmlToObject(domPos.xml);
//            var result = new Dictionary<string, object>
//            {
//                { "head", domHeadData },
//                { "body", domBodyData },
//                { "pos", domPosData }
//            };
//            return result;
//        }

//        //审核单据
//        public bool Verify(U8Login.clsLogin clsLogin, string billType, string vouchId, ref string msg)
//        {
//            ADODB.Connection conn = null;
//            try
//            {
//                Dictionary<string, object> voucherInfo = Select(clsLogin, billType, vouchId, ref msg);
//                Dictionary<string, object> domHead = (Dictionary<string, object>)voucherInfo["domHead"];
//                object timeStamp = domHead["ufts"];
//                conn = CreateConnection(clsLogin);
//                conn.BeginTrans();
//                VoucherCO vco = CreateVoucherCO(clsLogin, ref msg);
//                MSXML2.IXMLDOMDocument2 domMsg = new MSXML2.DOMDocumentClass();
//                bool bCheck = true, bBeforCheckStock = true, bList = false;
//                bool bsuccess = vco.Verify(billType, vouchId, ref msg, ref conn, ref timeStamp, domMsg, ref bCheck, bBeforCheckStock, bList);
//                if (!string.IsNullOrEmpty(msg))
//                {
//                    throw new Exception(msg);
//                }
//                conn.CommitTrans();
//                msg = "审核成功";
//                return bsuccess;
//            }
//            catch (Exception ex)
//            {
//                if (conn != null)
//                {
//                    conn.RollbackTrans();
//                }
//                msg = "审核失败：" + ex.Message;
//                return false;
//            }
//            finally
//            {
//                if (conn != null)
//                {
//                    conn.Close();
//                }
//            }
//        }

//        //单据弃审
//        public bool UnVerify(U8Login.clsLogin clsLogin, string billType, string vouchId, ref string msg)
//        {
//            ADODB.Connection conn = null;
//            try
//            {
//                Dictionary<string, object> voucherInfo = Select(clsLogin, billType, vouchId, ref msg);
//                Dictionary<string, object> domHead = (Dictionary<string, object>)voucherInfo["domHead"];
//                object timeStamp = domHead["ufts"];
//                conn = CreateConnection(clsLogin);
//                conn.BeginTrans();
//                VoucherCO vco = CreateVoucherCO(clsLogin, ref msg);
//                MSXML2.IXMLDOMDocument2 domMsg = new MSXML2.DOMDocumentClass();
//                bool bCheck = true, bBeforCheckStock = true, bList = false;
//                bool bsuccess = vco.UnVerify(billType, vouchId, ref msg, ref conn, ref timeStamp, domMsg, ref bCheck, bBeforCheckStock, bList);
//                if (!string.IsNullOrEmpty(msg))
//                {
//                    throw new Exception(msg);
//                }
//                conn.CommitTrans();
//                msg = "弃审成功";
//                return bsuccess;
//            }
//            catch (Exception ex)
//            {
//                if (conn != null)
//                {
//                    conn.RollbackTrans();
//                }
//                msg = "弃审失败：" + ex.Message;
//                return false;
//            }
//            finally
//            {
//                if (conn != null)
//                {
//                    conn.Close();
//                }
//            }
//        }

//        //单据删除
//        public bool Delete(U8Login.clsLogin clsLogin, string billType, string vouchId, ref string msg)
//        {
//            ADODB.Connection conn = null;
//            try
//            {
//                Dictionary<string, object> voucherInfo = Select(clsLogin, billType, vouchId, ref msg);
//                Dictionary<string, object> domHead = (Dictionary<string, object>)voucherInfo["domHead"];
//                object timeStamp = domHead["ufts"];
//                conn = CreateConnection(clsLogin);
//                conn.BeginTrans();
//                VoucherCO vco = CreateVoucherCO(clsLogin, ref msg);
//                MSXML2.IXMLDOMDocument2 domMsg = new MSXML2.DOMDocumentClass();
//                bool bCheck = true, bBeforCheckStock = true, bList = false;
//                bool bsuccess = vco.Delete(billType, vouchId, ref msg, ref conn, ref timeStamp, domMsg, ref bCheck, bBeforCheckStock, bList);
//                if (!string.IsNullOrEmpty(msg))
//                {
//                    throw new Exception(msg);
//                }
//                conn.CommitTrans();
//                msg = "删除成功";
//                return bsuccess;
//            }
//            catch (Exception ex)
//            {
//                if (conn != null)
//                {
//                    conn.RollbackTrans();
//                }
//                msg = "删除失败：" + ex.Message;
//                return false;
//            }
//            finally
//            {
//                if (conn != null)
//                {
//                    conn.Close();
//                }
//            }
//        }

//        //单据创建
//        public bool Create(U8Login.clsLogin clsLogin, string billType, string headXml, string bodyXml, ref string vouchId, ref string msg)
//        {
//            ADODB.Connection conn = null;
//            try
//            {
//                conn = CreateConnection(clsLogin);
//                conn.BeginTrans();
//                var vco = CreateVoucherCO(clsLogin, ref msg);
//                MSXML2.IXMLDOMDocument2 domHead = new MSXML2.DOMDocumentClass();
//                MSXML2.IXMLDOMDocument2 domBody = new MSXML2.DOMDocumentClass();
//                MSXML2.IXMLDOMDocument2 domPos = new MSXML2.DOMDocumentClass();
//                MSXML2.IXMLDOMDocument2 domMsg = new MSXML2.DOMDocumentClass();
//                domHead.loadXML(headXml);
//                domBody.loadXML(bodyXml);
//                bool bCheck = true, bBeforCheckStock = true, bList = false;
//                bool bsuccess = vco.Insert(billType, domHead, domBody, domPos, ref msg, ref conn, ref vouchId, ref domMsg, bCheck, bBeforCheckStock, bList);

//                if (!string.IsNullOrEmpty(msg))
//                {
//                    throw new Exception(msg);
//                }
//                conn.CommitTrans();
//                return bsuccess;
//            }
//            catch (Exception ex)
//            {
//                if (conn != null)
//                {
//                    conn.RollbackTrans();
//                }
//                msg = "创建失败：" + ex.Message;
//                return false;
//            }
//            finally
//            {
//                if (conn != null)
//                {
//                    conn.Close();
//                }
//            }
//        }

//        protected ADODB.Connection CreateConnection(U8Login.clsLogin clsLogin)
//        {
//            var con = new ADODB.Connection();
//            con.ConnectionString = clsLogin.UfDbName;
//            con.Open();
//            return con;
//        }

//        protected VoucherCO CreateVoucherCO(U8Login.clsLogin clsLogin, ref string msg)
//        {
//            var vco = new VoucherCO();
//            vco.IniLogin(clsLogin, ref msg);
//            if (!string.IsNullOrEmpty(msg))
//            {
//                throw new Exception(msg);
//            }
//            return vco;
//        }


//    }

//}