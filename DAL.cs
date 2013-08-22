using System;
using System.Text;
using System.Data.OracleClient;
using System.Collections.Generic;
using System.Data;
namespace XmlToOracleData
{
        public partial class T_CP_ACT
        {

            public bool Exists(decimal ACTID, string ACTNAME, string FILENUMBER, DateTime PUBDATE, DateTime STADATE, string DEPTS, string CONTENT, DateTime CREATEDTIME, string EFFECT, decimal ID, string ACTCODE, string DEPTIDS, string SRCTYPE, string STATUS, string DELFLAG, string CREATOR, string UPDATOR, DateTime UPDATETIME, DateTime ENDDATE)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select count(1) from T_CP_ACT");
                strSql.Append(" where ");
                strSql.Append(" ACTID = :ACTID and  ");
                strSql.Append(" ACTNAME = :ACTNAME and  ");
                strSql.Append(" FILENUMBER = :FILENUMBER and  ");
                strSql.Append(" PUBDATE = :PUBDATE and  ");
                strSql.Append(" STADATE = :STADATE and  ");
                strSql.Append(" DEPTS = :DEPTS and  ");
                strSql.Append(" CONTENT = :CONTENT and  ");
                strSql.Append(" CREATEDTIME = :CREATEDTIME and  ");
                strSql.Append(" EFFECT = :EFFECT and  ");
                strSql.Append(" ID = :ID and  ");
                strSql.Append(" ACTCODE = :ACTCODE and  ");
                strSql.Append(" DEPTIDS = :DEPTIDS and  ");
                strSql.Append(" SRCTYPE = :SRCTYPE and  ");
                strSql.Append(" STATUS = :STATUS and  ");
                strSql.Append(" DELFLAG = :DELFLAG and  ");
                strSql.Append(" CREATOR = :CREATOR and  ");
                strSql.Append(" UPDATOR = :UPDATOR and  ");
                strSql.Append(" UPDATETIME = :UPDATETIME and  ");
                strSql.Append(" ENDDATE = :ENDDATE  ");
                OracleParameter[] parameters = {
					new OracleParameter(":ACTID", OracleType.Number,32),
					new OracleParameter(":ACTNAME", OracleType.VarChar,1024),
					new OracleParameter(":FILENUMBER", OracleType.VarChar,4000),
					new OracleParameter(":PUBDATE", OracleType.DateTime),
					new OracleParameter(":STADATE", OracleType.DateTime),
					new OracleParameter(":DEPTS", OracleType.VarChar,1024),
					new OracleParameter(":CONTENT", OracleType.Clob,4000),
					new OracleParameter(":CREATEDTIME", OracleType.DateTime),
					new OracleParameter(":EFFECT", OracleType.Char,2),
					new OracleParameter(":ID", OracleType.Number,32),
					new OracleParameter(":ACTCODE", OracleType.VarChar,64),
					new OracleParameter(":DEPTIDS", OracleType.VarChar,640),
					new OracleParameter(":SRCTYPE", OracleType.Char,2),
					new OracleParameter(":STATUS", OracleType.Char,2),
					new OracleParameter(":DELFLAG", OracleType.Char,2),
					new OracleParameter(":CREATOR", OracleType.VarChar,64),
					new OracleParameter(":UPDATOR", OracleType.VarChar,64),
					new OracleParameter(":UPDATETIME", OracleType.DateTime),
					new OracleParameter(":ENDDATE", OracleType.DateTime)			};
                parameters[0].Value = ACTID;
                parameters[1].Value = ACTNAME;
                parameters[2].Value = FILENUMBER;
                parameters[3].Value = PUBDATE;
                parameters[4].Value = STADATE;
                parameters[5].Value = DEPTS;
                parameters[6].Value = CONTENT;
                parameters[7].Value = CREATEDTIME;
                parameters[8].Value = EFFECT;
                parameters[9].Value = ID;
                parameters[10].Value = ACTCODE;
                parameters[11].Value = DEPTIDS;
                parameters[12].Value = SRCTYPE;
                parameters[13].Value = STATUS;
                parameters[14].Value = DELFLAG;
                parameters[15].Value = CREATOR;
                parameters[16].Value = UPDATOR;
                parameters[17].Value = UPDATETIME;
                parameters[18].Value = ENDDATE;

                return DbHelperOra.Exists(strSql.ToString(), parameters);
            }



            /// <summary>
            /// 增加一条数据
            /// </summary>
            public void Add(T_CP_ACT model)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into T_CP_ACT(");
                strSql.Append("ACTID,ID,ACTCODE,DEPTIDS,SRCTYPE,STATUS,DELFLAG,CREATOR,UPDATOR,UPDATETIME,ENDDATE,ACTNAME,FILENUMBER,PUBDATE,STADATE,DEPTS,CONTENT,CREATEDTIME,EFFECT");
                strSql.Append(") values (");
                strSql.Append(":ACTID,:ID,:ACTCODE,:DEPTIDS,:SRCTYPE,:STATUS,:DELFLAG,:CREATOR,:UPDATOR,:UPDATETIME,:ENDDATE,:ACTNAME,:FILENUMBER,:PUBDATE,:STADATE,:DEPTS,:CONTENT,:CREATEDTIME,:EFFECT");
                strSql.Append(") ");

                OracleParameter[] parameters = {
			            new OracleParameter(":ACTID", OracleType.Number,32) ,            
                        new OracleParameter(":ID", OracleType.Number,32) ,            
                        new OracleParameter(":ACTCODE", OracleType.VarChar,64) ,            
                        new OracleParameter(":DEPTIDS", OracleType.VarChar,640) ,            
                        new OracleParameter(":SRCTYPE", OracleType.Char,2) ,            
                        new OracleParameter(":STATUS", OracleType.Char,2) ,            
                        new OracleParameter(":DELFLAG", OracleType.Char,2) ,            
                        new OracleParameter(":CREATOR", OracleType.VarChar,64) ,            
                        new OracleParameter(":UPDATOR", OracleType.VarChar,64) ,            
                        new OracleParameter(":UPDATETIME", OracleType.DateTime) ,            
                        new OracleParameter(":ENDDATE", OracleType.DateTime) ,            
                        new OracleParameter(":ACTNAME", OracleType.VarChar,1024) ,            
                        new OracleParameter(":FILENUMBER", OracleType.VarChar,4000) ,            
                        new OracleParameter(":PUBDATE", OracleType.DateTime) ,            
                        new OracleParameter(":STADATE", OracleType.DateTime) ,            
                        new OracleParameter(":DEPTS", OracleType.VarChar,1024) ,            
                        new OracleParameter(":CONTENT", OracleType.Clob,4000) ,            
                        new OracleParameter(":CREATEDTIME", OracleType.DateTime) ,            
                        new OracleParameter(":EFFECT", OracleType.Char,2)             
              
            };

                parameters[0].Value = model.ACTID;
                parameters[1].Value = model.ID;
                parameters[2].Value = model.ACTCODE;
                parameters[3].Value = model.DEPTIDS;
                parameters[4].Value = model.SRCTYPE;
                parameters[5].Value = model.STATUS;
                parameters[6].Value = model.DELFLAG;
                parameters[7].Value = model.CREATOR;
                parameters[8].Value = model.UPDATOR;
                parameters[9].Value = model.UPDATETIME;
                parameters[10].Value = model.ENDDATE;
                parameters[11].Value = model.ACTNAME;
                parameters[12].Value = model.FILENUMBER;
                parameters[13].Value = model.PUBDATE;
                parameters[14].Value = model.STADATE;
                parameters[15].Value = model.DEPTS;
                parameters[16].Value = model.CONTENT;
                parameters[17].Value = model.CREATEDTIME;
                parameters[18].Value = model.EFFECT;
                DbHelperOra.ExecuteSql(strSql.ToString(), parameters);

            }


    

            /// <summary>
            /// 获得数据列表
            /// </summary>
            public DataSet GetList(string strWhere)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select * ");
                strSql.Append(" FROM T_CP_ACT ");
                if (strWhere.Trim() != "")
                {
                    strSql.Append(" where " + strWhere);
                }
                return DbHelperOra.Query(strSql.ToString());
            }

            /// <summary>
            /// 获得前几行数据
            /// </summary>
            public DataSet GetList(int Top, string strWhere, string filedOrder)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select ");
                if (Top > 0)
                {
                    strSql.Append(" top " + Top.ToString());
                }
                strSql.Append(" * ");
                strSql.Append(" FROM T_CP_ACT ");
                if (strWhere.Trim() != "")
                {
                    strSql.Append(" where " + strWhere);
                }
                strSql.Append(" order by " + filedOrder);
                return DbHelperOra.Query(strSql.ToString());
            }
    }


}
