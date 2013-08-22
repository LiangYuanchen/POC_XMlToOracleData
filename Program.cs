using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.OracleClient;
namespace XmlToOracleData
{
    class Program
    {
        static void Main(string[] args)
        {
            DBHelper.init();
            root r = new root();
            r.act=new act() { actid = "43", content = "2", fileNumber = "df"};
            
            string a = SerializationHelper.SerializeObject<root>(r);
            string basePath = @"E:\SkyDrive\Projects\浦发事项\上线程序\POC自动打包上线\bin\Debug\Data\201308211916";
            string[] strFiles = Directory.GetFiles(basePath);
            foreach (var item in strFiles)
            {
                StreamReader sr = new StreamReader(item);
                string parm = sr.ReadToEnd();
                sr.Close();
                root roots = SerializationHelper.DeserializeObject<root>(parm);
                DBInsert(roots);
            }
        }
        static void DBInsert(root parm)
        {
              ActInsert(parm.act);
              ActItemInsert(parm.act.actitems);
          //  ActCorrelationInsert(parm.act.actcorrelations);
        }
        static void ActInsert(act parm)
        {
//            string sql = @"insert into T_CP_ACT (ID,ACTID,ACTNAME,FILENUMBER,CONTENT,PUBDATE,STADATE,DEPTS,CREATEDTIME,EFFECT,ACTCODE,DEPTIDS,SRCTYPE,STATUS,DELFLAG,UPDATETIME,ENDDATE)
//                                        values (:ID,:ACTID,:ACTNAME,:FILENUMBER,:CONTENT,:PUBDATE,:STADATE,:DEPTS,:CREATEDTIME,:EFFECT,:ACTCODE,:DEPTIDS,:SRCTYPE,:STATUS,:DELFLAG,:UPDATETIME,:ENDDATE)";
//            //:ID,:ACTID,:ACTNAME,:FILENUMBER,:CONTENT,:PUBDATE,:STADATE,:DEPTS,:CREATEDTIME,:EFFECT,:ACTCODE,:DEPTIDS,:SRCTYPE,:STATUS,:DELFLAG,:UPDATETIME,:ENDDATE
//            OracleParameter[] parms ={
//                                   new OracleParameter(":ID",OracleType.Number,32,parm.actid),
//                                   new OracleParameter(":ACTID",OracleType.Number,32,parm.actid),
//                                   new OracleParameter(":ACTNAME",parm.actname),
//                                   new OracleParameter(":FILENUMBER",parm.fileNumber),
//                                   new OracleParameter(":CONTENT",parm.content),
//                                   new OracleParameter(":PUBDATE", Convert.ToDateTime(parm.pubdate)),//有问题
//                                   new OracleParameter(":STADATE",Convert.ToDateTime(parm.stadate)),//有问题
//                                   new OracleParameter(":DEPTS",parm.depts),
//                                   new OracleParameter(":CREATEDTIME",DateTime.Now),
//                                   new OracleParameter(":EFFECT",parm.effect),
//                                   new OracleParameter(":ACTCODE",""),
//                                   new OracleParameter(":DEPTIDS",parm.deptids),
//                                   new OracleParameter(":SRCTYPE","1"),
//                                   new OracleParameter(":STATUS","1"),
//                                   new OracleParameter(":DELFLAG","N"),//如果是"Y"呢？
//                                   new OracleParameter(":UPDATETIME",DateTime.Now),
//                                   new OracleParameter(":ENDDATE",parm.enddate==null?DateTime.MinValue:Convert.ToDateTime(parm.enddate))
//                                    };
//            DBHelper.ExecuteNonQuery(sql, System.Data.CommandType.Text, parms);

          //  string sql = "INSERT INTO T_CP_ACT (ID,ACTID,ACTNAME,FILENUMBER,CONTENT,PUBDATE,STADATE,DEPTS,CREATEDTIME,EFFECT,ACTCODE,DEPTIDS,SRCTYPE,STATUS,DELFLAG,UPDATETIME,ENDDATE) VALUES (" + parm.actid + "," + parm.actid + ",'" + parm.actname + "','" + parm.fileNumber + "','" + parm.content + "','" + parm.pubdate + "','" + parm.stadate + "','" + parm.depts + "','" + DateTime.Now.ToString("yyyy/MM/dd") + "'," + parm.effect + ",1,'" + parm.deptids + "',1,1,'N','" + DateTime.Now.ToString("yyyy/MM/dd") + "','"+parm.enddate+"')";
          //  DBHelper.ExecuteNonQuery(sql);
            T_CP_ACT act = new T_CP_ACT() { 
             ID = Convert.ToInt32( parm.actid),
              ACTCODE = "",
               ACTID = Convert.ToInt32(parm.actid),
                ACTNAME = parm.actname,
                 CONTENT = parm.content,
                  CREATEDTIME = DateTime.Now,
                   CREATOR = "",
                    DELFLAG = "N",
                     DEPTIDS = parm.deptids,
                      DEPTS = parm.depts,
                       EFFECT = parm.effect,
                         FILENUMBER = parm.fileNumber,
                           SRCTYPE = "1",
                             STATUS  = "1",
                              UPDATETIME = DateTime.Now,
                               UPDATOR = "",
                                STADATE = DateTime.MinValue,
                                 PUBDATE = DateTime.MinValue,
                                  ENDDATE = DateTime.MinValue
            };
            if (parm.pubdate!=null&&parm.pubdate!=string.Empty)
            {
                act.PUBDATE =Convert.ToDateTime( parm.pubdate);
            }
            
            if (parm.stadate != null && parm.stadate != string.Empty)
            {
                act.STADATE = Convert.ToDateTime(parm.stadate);
            }
            if (parm.enddate != null && parm.enddate != string.Empty)
            {
                act.ENDDATE = Convert.ToDateTime(parm.enddate);
            }
            act.Add(act);
            Console.WriteLine("Act Inserted "+act.ACTID);
        }
        static void ActItemInsert(List<item> parm)
        {
            foreach (var model in parm)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into T_CP_ACT_ITEMS(");
                strSql.Append("ITEMID,ACTID,ITEMNAME,ITEMTYPE,ITEMPARENTID,ORDERS,CONTENT");
                strSql.Append(") values (");
                strSql.Append(":ITEMID,:ACTID,:ITEMNAME,:ITEMTYPE,:ITEMPARENTID,:ORDERS,:CONTENT");
                strSql.Append(") ");

                OracleParameter[] parameters = {
			            new OracleParameter(":ITEMID",  OracleType .Number,32) ,            
                        new OracleParameter(":ACTID", OracleType.Number,32) ,            
                        new OracleParameter(":ITEMNAME", OracleType.VarChar,512) ,            
                        new OracleParameter(":ITEMTYPE", OracleType.Char,4) ,            
                        new OracleParameter(":ITEMPARENTID", OracleType.Number,32) ,            
                        new OracleParameter(":ORDERS", OracleType.Number,8) ,            
                        new OracleParameter(":CONTENT", OracleType.Clob,4000)             
            };

                parameters[0].Value = model.itemid;
                parameters[1].Value = model.actid;
                parameters[2].Value = model.itemname;
                parameters[3].Value = model.itemtype;
                parameters[4].Value = model.itemparentid;
                parameters[5].Value = model.orders;
                parameters[6].Value = model.content;
                DBHelper.ExecuteNonQuery(strSql.ToString(), System.Data.CommandType.Text, parameters);
                Console.WriteLine("ActItem Inserted "+model.itemid);
            }
        }
        static void ActCorrelationInsert(List<actcorrelation> parm)
        {
            foreach (var item in parm)
            {
                string sql = "insert into T_CP_ACT_CORRELATION (ID,TOACTID,TOITEMID,FROMACTID,FROMITEMID,FROMACTNAME,FROMITEMCONTENT,FROMITEMNAME) VALUES (:ID,:TOACTID,:TOITEMID,:FROMACTID,:FROMITEMID,:FROMACTNAME,:FROMITEMCONTENT,:FROMITEMNAME)";
                //:TOACTID,:TOITEMID,:FROMACTID,:FROMITEMID,:FROMACTNAME,:FROMITEMCONTENT,:FROMITEMNAME
                OracleParameter[] parms = { 
                                              new OracleParameter(":ID",item.toitemid),
                                            new OracleParameter(":TOACTID",item.toactid),
                                            new OracleParameter(":TOITEMID",item.toitemid),
                                            new OracleParameter(":FROMACTID",item.fromactid),
                                            new OracleParameter(":FROMITEMID",item.fromitemid),
                                            new OracleParameter(":FROMACTNAME",item.fromactname),
                                            new OracleParameter(":FROMITEMCONTENT",item.fromitemcontent),
                                            new OracleParameter(":FROMITEMNAME",item.fromitemname)
                                          };
                DBHelper.ExecuteNonQuery(sql,System.Data.CommandType.Text,parms);
            }
        }
    }
}
