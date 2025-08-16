using System;
using System.Data.OleDb;
using System.IO;
using System.Data;
using System.Text;
using System.Web;
using System.Configuration;


namespace MDSolution
{
    public enum FieldTypes
    {
        Text = 0,
        //        Integer = 1,
        //        Currency = 2,
        DropDown = 3,
        Radio = 4,
        CheckBox = 5,
        Image = 6,
        TextArea = 7,
        File = 8,
        Date = 9,
        Time = 10,
        Password = 11
    }

	/// <summary>
	/// Summary description for MDSolutionEntities.DBModule.
	/// </summary>
	public class DBModule
	{
		public const string Access = "MS Access";
		public const string SQLServer = "SQLServer";
		public const string Oracle = "Oracle";
		public const string mySQL = "mySQL";
		public static string strConnString = "";
		public static string DbType;
        public static string ServerName;
        public static string UserID = "sa";
        public static string Password = "sa";
        public static string DatabaseName = "MD";

		public DBModule()
		{
		}
		public static string PathConfig="";
		public static void SetDBConnectionString(string FileFullPath)
		{
			if(PathConfig=="") PathConfig = FileFullPath;
		}

		public static OleDbConnection CreateDBConnection()
		{
			return CreateDBConnection(true);
		}
		public static void BuildDatabaseParameters()
		{
			BuildDatabaseParameters(false);
		}
		public static void BuildDatabaseParameters(bool bRebuild)
		{
			//string configKeyConnectionString = "OleDBConnectionString";
			string configKeyDatabaseType = "DBType";
			if ( (strConnString == "") || (bRebuild == true) )
			{
                //if (ConfigurationManager.AppSettings[configKeyConnectionString] != null)
                //{
                //    strConnString = ConfigurationManager.AppSettings[configKeyConnectionString].ToString();
                //    DbType = MDSolutionEntities.DBModule.SQLServer;
                //    if (ConfigurationManager.AppSettings[configKeyDatabaseType] != null)
                //    {
                //        DbType = ConfigurationManager.AppSettings[configKeyDatabaseType].ToString();
                //    }
                //}
                //else
                //{
					string strServerName, strDatabase, strUserName, strPassword;
					ReadDatabaseInfo(out strServerName, out strDatabase, out strUserName, out strPassword, out DbType);
				   // Set paramater config database
                        ServerName = strServerName;
                        UserID = strUserName;
                        Password = strPassword;
                        DatabaseName = strDatabase;
                    // End Set 
					switch (DbType)
					{
						case MDSolutionEntities.DBModule.Access:
							strConnString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + PathConfig + "\\" + strDatabase;
							break;
						case MDSolutionEntities.DBModule.SQLServer:
							strConnString = "driver={SQL Server};server=" + strServerName + ";uid=" + strUserName + ";password=" + strPassword + "; database=" + strDatabase + ";Provider=SQLOLEDB;";
							break;
						case MDSolutionEntities.DBModule.Oracle:
							break;
						case MDSolutionEntities.DBModule.mySQL:
							break;
					}
				//}
                  

				#region test database connection
                /*
				try
				{
					OleDbConnection cn = new OleDbConnection(strConnString);
					cn.Open();
					cn.Close();
					cn = null;
				}
				catch (Exception ex)
				{
					strConnString = "";
					throw ex;
				}*/
				#endregion
			}
		}
		public static OleDbConnection CreateDBConnection(bool doOpen)
		{
			if (strConnString == "") 
			{
				BuildDatabaseParameters();
			}


			OleDbConnection cn = new OleDbConnection(strConnString);

			// if we cannot open the connection, set the connection string to empty so that we will 
			// rebuild the connection string in next time 
			try
			{
				if (doOpen) cn.Open();

			}
			catch (Exception ex)
			{
				strConnString = "";
				throw ex;
			}
			return cn;
		}
		public static void CloseDBConnection(OleDbConnection cn)
		{
			if(cn != null)
			{
				if (cn.State == ConnectionState.Open) cn.Close();
			}
		}

		#region ExecuteNonQuery functions
		//Execute non-query command, return number of rows affected
		public static int ExecuteNonQuery(string strCommand, OleDbConnection cn, OleDbTransaction trans)
		{
            string tempCommand = strCommand.ToUpper();
            if (tempCommand.IndexOf("SP_") == -1)//Loai tru viec execute mot store
            {
                try
                {
                    string sDateTimeNow =  DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
                    string list_column_name = "";
                    string list_value = "";
                    int sTableName = tempCommand.IndexOf("TBL_");
                    int eTableName;
                    string sqlWhere = " ";
                    string sql = "";
                    int Action;
                    //Backup data:
                    if (tempCommand.IndexOf("INSERT") > -1)//Neu la cau lenh insert
                    {
                        eTableName = strCommand.IndexOf("(", sTableName);
                    }
                    else
                    {
                        eTableName = strCommand.IndexOf(" ", sTableName);
                    }
                    string TableName = strCommand.Substring(sTableName, eTableName - sTableName).Trim();
                    if (tempCommand.IndexOf("INSERT") > -1)//Neu la cau lenh insert
                    {
                        Action = 0;
                        list_value = strCommand.Substring(tempCommand.IndexOf("VALUES(") + 7);
                        list_column_name = strCommand.Substring(eTableName, tempCommand.IndexOf("VALUES(") - eTableName);
                    }
                    else//update,delete:
                    {
                        if (tempCommand.IndexOf("UPDATE") > -1)
                            Action = 1;//update
                        else
                            Action = 2;//Delete
                        sqlWhere = " " + strCommand.Substring(tempCommand.IndexOf("WHERE"));
                        sql = "select * from " + TableName + sqlWhere;
                        DataSet ds = ExecuteQuery(sql, null, null);
                        int i = 0;
                        foreach (DataColumn col in ds.Tables[0].Columns)
                        {
                            if (i == 0)
                            {
                                list_column_name = col.ColumnName;
                                list_value =CreateSqlValue(ds.Tables[0].Rows[0][col.ColumnName].ToString(),col.DataType); ;
                            }
                            else
                            {
                                list_column_name += "," + col.ColumnName;
                                list_value += "," + CreateSqlValue(ds.Tables[0].Rows[0][col.ColumnName].ToString(), col.DataType);
                            }
                            i++;
                        }
                    }
                    
                    //+1.Kiem tra da ton tai bang log chua, neu chua thi tao bang log:
                    ExecuteNoneBackup("sp_Create_backup_table '" + TableName + "'", null, null);
                    //+3.2.Backup vao bang log:
                    list_value =list_value.Replace(")", "").Replace("(", "")+","+ DACASUCO_App.User.ID.ToString() + ",'" + sDateTimeNow + "'," + Action.ToString();
                    string sqlInsertIntoTableLog = "Insert into " + TableName + "_log(" + list_column_name.Replace(")","").Replace("(","") + ",UserID,Date_Modify,Action) Values(" + list_value + ")";
                    ExecuteNoneBackup(sqlInsertIntoTableLog, null, null);
                    //+3.3.Ghi lai bang da bi thay doi vao bang sys_Log: (sys_Log Quan ly su thay doi trong cac bang)
                    sql = "insert into sys_log(TableName,UserID,Date_Modify,Action) values(N'" + TableName + "'," + DACASUCO_App.User.ID.ToString() + ",'" + sDateTimeNow + "'," + Action.ToString() + ")";
                    ExecuteNoneBackup(sql, null, null);
                }
                catch
                { 
                }
            }
            //Thuc thi cau lenh binh thuong:
            return ExecuteNoneBackup(strCommand, cn, trans);
		}
        public static int ExecuteNoneBackup(string strCommand, OleDbConnection cn, OleDbTransaction trans)
        {
            bool cnOpen = false;
            if (cn == null) cn = CreateDBConnection();
            else
            {
                cnOpen = (cn.State == ConnectionState.Open);
                if (!cnOpen) cn.Open();
            }

            try
            {
                //DebugModule.WriteLine("MDSolutionEntities.DBModule.ExecuteNonQuery\n\t{0}", strCommand);
                OleDbCommand cmd = new OleDbCommand(strCommand, cn, trans);
                return cmd.ExecuteNonQuery();
            }
            finally
            {
                if (!cnOpen) cn.Close();
            }
        }
/*
		public static int ExecuteNonQuery(string strCommand)
		{
			OleDbConnection cn = CreateDBConnection(true);
			try
			{
				//DebugModule.WriteLine("MDSolutionEntities.DBModule.ExecuteNonQuery\n\t{0}", strCommand);
				OleDbCommand  cmd = new OleDbCommand(strCommand, cn);
				return cmd.ExecuteNonQuery();
			}
			finally
			{
				CloseDBConnection(ref cn);
			}
		}
*/		
		public static int ExecuteNonQuerySP(OleDbConnection cn, OleDbTransaction trans, string ProcName, params object[] parameters)
		{
			string[] ParamNames = null;
			if (parameters != null && parameters.Length > 0)
			{
				ParamNames = new String[parameters.Length];
				for (int i = 0; i < parameters.Length; i++)
					ParamNames[i] = "@" + (i + 1);
			}
			return _ExecuteNonQuerySP(cn, trans, ProcName, ParamNames, parameters);
		}

		public static int _ExecuteNonQuerySP(OleDbConnection cn, OleDbTransaction trans, string ProcName, string[] ParamNames, object[] ParamValues)
		{
			bool cnOpen = false;
			bool IsConnTransmited = true;
			if (cn == null)
			{
				IsConnTransmited = false;
				cn = CreateDBConnection();
			}
			else
			{
				cnOpen = (cn.State == ConnectionState.Open);
				if (!cnOpen) cn.Open();
			}

			try
			{
				 
				OleDbCommand cmd = new OleDbCommand(ProcName, cn);
				cmd.CommandType = CommandType.StoredProcedure;
				if(trans != null) cmd.Transaction = trans;

                if (ParamNames != null)
                    for (int i = 0; i < ParamNames.Length; i++)
                        cmd.Parameters.AddWithValue(ParamNames[i], ParamValues[i]);
                        //cmd.Parameters.Add(ParamNames[i], ParamValues[i]);

				//				DebugModule.WriteLine("MDSolutionEntities.DBModule._ExecuteSP, ProcName={0}\n\tParameters: {{{1}}}", ProcName, GeneralModules.SqlParamsToString(cmd.Parameters));
				return cmd.ExecuteNonQuery();
			}
			catch(Exception ex)
			{
				throw ex;
			}
			finally
			{
				if(!IsConnTransmited)
				{				
					if (!cnOpen) cn.Close();					
				}
				else{}
			}
		}
		#endregion

		#region ExecuteQuery, ExecuteReader functions
		public static DataSet ExecuteQuery(string strSQL, OleDbConnection cn, OleDbTransaction trans)
		{
			return ExecuteQuery(strSQL, "", cn, trans);
		}
		public static DataSet ExecuteQuery(string strSQL, string strTableName, OleDbConnection cn, OleDbTransaction trans)
		{
            DataSet ds = new DataSet();
			bool cnOpen = false;
			if (cn == null) cn = CreateDBConnection();
			else 
			{
				cnOpen = (cn.State == ConnectionState.Open);
				if (!cnOpen) cn.Open();
			}
			try
			{
                if (!cnOpen) trans = cn.BeginTransaction(IsolationLevel.ReadUncommitted);
				
				OleDbDataAdapter adapter = new OleDbDataAdapter(new OleDbCommand(strSQL, cn, trans));
				if (strTableName != "")
					adapter.Fill(ds,strTableName);
				else
					adapter.Fill(ds);

                if (!cnOpen) trans.Commit();
			}
			finally
			{
				if (!cnOpen) CloseDBConnection(cn);
			}
            return ds;
		}
		private static int ValidateLicenseNumber(string strLicenseNumber)
		{
//			StreamReader f = File.OpenText(PathConfig + "\\database.cfg");
//			string s;
//			string [] spl;
//
//			while (null != (s = f.ReadLine()))
//			{
//				spl = s.Split('=');
//				switch (spl[0].Trim().ToLower()) 
//				{
//					case "servername": strServerName = spl[1]; break;
//					case "username": strUserName = spl[1]; break;
//					case "password": strPassword = spl[1]; break;
//					case "dbname": strDatabase = spl[1]; break;
//					case "dbtype": strDatabaseType = spl[1];break;
//				}
//			}
//			f.Close();
			return 1;
		}
		/// <summary>
		/// Execute a query and return a result as a string
		/// If no result, return null
		/// </summary>
		/// <param name="strSQL"></param>
		/// <param name="cn"></param>
		/// <param name="trans"></param>
		/// <returns></returns>
		public static string ExecuteQueryForOneResult(string strSQL, OleDbConnection cn, OleDbTransaction trans)
		{
			string strResult = "";
			DataSet ds = ExecuteQuery(strSQL, cn, trans);
			if (ds != null)
			{
				if (ds.Tables[0].Rows.Count > 0)
					strResult = ds.Tables[0].Rows[0][0].ToString();
			}
			return strResult;
		}
		public static DataSet ExecuteQuery(string strSQL, int NumOfItemsPerPage, int ItemPage, OleDbConnection cn, OleDbTransaction trans)
		{
			return ExecuteQuery(strSQL, "", NumOfItemsPerPage, ItemPage, cn, trans);
		}
		public static DataSet ExecuteQuery(string strSQL, string strTableName, int NumOfItemsPerPage, int ItemPage, OleDbConnection cn, OleDbTransaction trans)
		{

			bool cnOpen = false;
			if (cn == null) cn = CreateDBConnection();
			else 
			{
				cnOpen = (cn.State == ConnectionState.Open);
				if (!cnOpen) cn.Open();
			}
			DataSet ds = new DataSet();
			DataTable dt;
			if (strTableName != "")
				dt = ds.Tables.Add(strTableName);
			else
				dt = ds.Tables.Add();
			try
			{
                if (!cnOpen) trans = cn.BeginTransaction(IsolationLevel.ReadUncommitted);

				OleDbCommand cmd = new OleDbCommand(strSQL, cn, trans);
				OleDbDataReader dReader = cmd.ExecuteReader(System.Data.CommandBehavior.SequentialAccess);

				if (dReader.HasRows)
				{
                    if (ItemPage <= 0) ItemPage = 1;
					int nPageCount = 0;
					int nStartRow = NumOfItemsPerPage * ( ItemPage - 1) + 1;
					while (dReader.Read())
					{
						nPageCount ++;
						if(nPageCount == nStartRow)
						{
							//create column headers
							int nFieldCount = dReader.FieldCount;
							for (int i = 0; i < nFieldCount; i ++)
							{
								dt.Columns.Add(dReader.GetName(i), dReader.GetFieldType(i));
							}
							//read data
							int nPageRow = 0;
							bool bRead = true;
							object[] objValues;
							while ( (nPageRow < NumOfItemsPerPage) && bRead)
							{
								nPageRow ++;
								objValues = new object[nFieldCount];
								dReader.GetValues(objValues);
								dt.Rows.Add(objValues);
								bRead = dReader.Read();
							}
							// break the reading
							break;
						}
					}
				}
				dReader.Close();
				cmd.Dispose();

                if (!cnOpen) trans.Commit();

				return ds;
			}
			finally
			{
				if (!cnOpen) CloseDBConnection(cn);
			}
		}
		public static DataSet ExecuteQuery(string strSQL, int NumOfItemsPerPage, int ItemPage, out int TotalNumOfPages, OleDbConnection cn, OleDbTransaction trans)
		{			
			return ExecuteQuery(strSQL, "", NumOfItemsPerPage, ItemPage, out TotalNumOfPages, cn, trans);
		}
		public static DataSet ExecuteQuery(string strSQL, string strTableName, int NumOfItemsPerPage, int ItemPage, out int TotalNumOfPages, OleDbConnection cn, OleDbTransaction trans)
		{			
			int nTotalItem = 0;
            return ExecuteQuery(strSQL, strTableName, NumOfItemsPerPage, ItemPage, out TotalNumOfPages, out nTotalItem, cn, trans);			
		}

        public static void GetPagingParams(string strSQL, int NumOfItemsPerPage, out int TotalNumOfPages, out int TotalItems, OleDbConnection cn, OleDbTransaction trans)
        {
            string strTotalItems = "";
            int nOrderByPosition = -1;
            TotalNumOfPages = 1;
            TotalItems = 0;

            nOrderByPosition = strSQL.ToLower().LastIndexOf("order by");
            if (nOrderByPosition > 0)
                strTotalItems = strSQL.Substring(0, nOrderByPosition);
            else
                strTotalItems = strSQL;

            strTotalItems = "Select count(*) From (" + strTotalItems + ") as LDTRESTableCount";

            DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery(strTotalItems, cn, trans);
            TotalItems = int.Parse(ds.Tables[0].Rows[0][0].ToString());

            if (NumOfItemsPerPage > 0)
            {                
                TotalNumOfPages = (int)((TotalItems + NumOfItemsPerPage - 1) / NumOfItemsPerPage);
            }
        }

        public static DataSet ExecuteQuery(string strSQL, string strTableName, int NumOfItemsPerPage, int ItemPage, out int TotalNumOfPages, out int TotalItems, OleDbConnection cn, OleDbTransaction trans)
        {
            DataSet retVal;
            //string strTotalItems = "";
            //int nOrderByPosition = 0;
            TotalNumOfPages = 1;
            TotalItems = 0;
            if (NumOfItemsPerPage > 0)
            {
                GetPagingParams(strSQL, NumOfItemsPerPage, out TotalNumOfPages, out TotalItems, cn, trans);
                /*nOrderByPosition = strSQL.ToLower().LastIndexOf("order by");
                if (nOrderByPosition > 0)
                    strTotalItems = strSQL.Substring(0, nOrderByPosition);
                else
                    strTotalItems = strSQL;

                strTotalItems = "Select count(*) From (" + strTotalItems + ") as LDTRESTableCount";

                //"Select (count(*) +" + NumOfItemsPerPage.ToString() + "-1)/" + NumOfItemsPerPage.ToString() +
                //    " From (" + strTotalNumOfPageSQL + ") as LDTRESTableCount";

                DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery(strTotalItems, cn, trans);
                TotalItems = int.Parse(ds.Tables[0].Rows[0][0].ToString());
                TotalNumOfPages = (int) ((TotalItems + NumOfItemsPerPage - 1) / NumOfItemsPerPage);*/

                if (ItemPage > TotalNumOfPages) ItemPage = 1;

                retVal = ExecuteQuery(strSQL, strTableName, NumOfItemsPerPage, ItemPage, cn, trans);
            }
            else
            {
                retVal = ExecuteQuery(strSQL, strTableName, cn, trans);
                TotalItems = int.Parse(retVal.Tables[0].Rows[0][0].ToString());
            }
            return retVal;
        }
/*
		public static DataSet ExecuteQuery(string strSQL)
		{
			OleDbConnection cn = CreateDBConnection();
			try
			{
				DataSet ds = new DataSet();
				OleDbDataAdapter adapter = new OleDbDataAdapter(strSQL, cn);
				adapter.Fill(ds);
				//DebugModule.WriteLine("MDSolutionEntities.DBModule.ExecuteQuery\n\t{0}", strSQL);
				return ds;
			}
			finally
			{
				CloseDBConnection(ref cn);
			}
		}
*/
		public static OleDbDataReader ExecuteReader(string strSQL, OleDbConnection cn, OleDbTransaction trans, CommandBehavior behavior)
		{
            OleDbDataReader retVal = null;
			bool cnOpen = false;
			if (cn == null) cn = CreateDBConnection();
			else 
			{
				cnOpen = (cn.State == ConnectionState.Open);
				if (!cnOpen) cn.Open();
			}
			try
			{
                if (!cnOpen) trans = cn.BeginTransaction(IsolationLevel.ReadUncommitted);

				OleDbCommand cmd = new OleDbCommand(strSQL, cn, trans);
				//			DebugModule.WriteLine("MDSolutionEntities.DBModule.ExecuteReader\n\t{0}", strSQL);
				if (!cnOpen) //in case the input connection is null or not open we implicitly close the connection
				{			//when the data reader is closed
					retVal = cmd.ExecuteReader(CommandBehavior.CloseConnection);
				}
				else
				{
					retVal = cmd.ExecuteReader(behavior);
				}
                if (!cnOpen) trans.Commit();
			}
			// we does not need to close the connection in case of !cnOpen. The connection will be closed when the data reader is closed
			finally 
			{
//				if (behavior != CommandBehavior.CloseConnection) // in case of not implicitly close the connection when the data reader is closed
//				{
//					if (!cnOpen) CloseDBConnection(ref cn);
//				}
			}
            return retVal;
		}

		public static OleDbDataReader ExecuteReader(string strSQL, OleDbConnection cn, OleDbTransaction trans)
		{
			return ExecuteReader(strSQL, cn, trans, CommandBehavior.Default);
		}
		#endregion

		#region Helper functions: Refine input, ReadDatabaseInfo, ...
		//SqlEncode: return an Sql-safe string to put into a string variable in an SQL statement
		//Just convert single quote (') to 2 single quotes ('')
       public static string CreateSqlValue(string Source,Type type)
        {
            if (Source == null ||Source == "" ) return "null";
            string result = "";
            switch (type.Name)
            {
                case "DateTime":
                   result= RefineDatetime(Source);
                    break;
                case "String":
                    result="N'"+RefineString(Source)+"'";
                    break;
                default:
                    
                    result =RefineString(Source);
                    break;
               
            }

            return result;
        }
		public static string RefineString(string strSource)
		{
			if (strSource == null) return "";
			string result = strSource.Replace("'", "''");
			//DebugModule.WriteLine(string.Format("MDSolutionEntities.DBModule.SqlEncode\n\tfrom {0} to {1}", strSource, result));
			return result;
		}
        public static string RefineDatetime(DateTime dtSource, Boolean isAllowNull)
        {            
            string result = dtSource.ToString("MM/dd/yyyy HH:mm:ss");
            if (isAllowNull)
            {
                if (dtSource == DateTime.MinValue)
                {
                    result = "null";
                }
                else
                {
                    result = "'" + result + "'";
                }
            }
            else
            {
                result = "'" + result + "'";
            }
            return result;
        }
		public static string RefineDatetime(DateTime dtSource)
		{
			string result = dtSource.ToString("MM/dd/yyyy HH:mm:ss");
			switch (DbType)
			{
				case MDSolutionEntities.DBModule.Access:
					result = "#" + result + "#";
					break;
				case MDSolutionEntities.DBModule.SQLServer:
					result = "'" + result + "'";
					break;
				case MDSolutionEntities.DBModule.Oracle:
					break;
				case MDSolutionEntities.DBModule.mySQL:
					break;
			}
			return result;
		}
		public static string RefineDatetime(string strSource)
		{
			string result = strSource;
			switch (DbType)
			{
				case MDSolutionEntities.DBModule.Access:
					result = "#" + result + "#";
					break;
				case MDSolutionEntities.DBModule.SQLServer:
					result = "'" + result + "'";
					break;
				case MDSolutionEntities.DBModule.Oracle:
					break;
				case MDSolutionEntities.DBModule.mySQL:
					break;
			}
			return result;
		}
		private static void ReadDatabaseInfo(out string strServerName, out string strDatabase,
			out string strUserName, out string strPassword, out string strDatabaseType)
		{
			strServerName = "DATASERVER\\DATASERVER2000";
			strDatabase = "ProjectManagement";
			strUserName = "sa";
			strPassword = "sa";		
			strDatabaseType = MDSolutionEntities.DBModule.mySQL;
			try 
			{
				StreamReader f = File.OpenText(PathConfig + "\\database.cfg");
				string s;
				string [] spl;

				while (null != (s = f.ReadLine()))
				{
					spl = s.Split('=');
					switch (spl[0].Trim().ToLower()) 
					{
						case "servername": strServerName = spl[1]; break;
						case "username": strUserName = spl[1]; break;
						case "password": strPassword = clsComFunctions.Decrypt(spl[1]); break;
						case "dbname": strDatabase = spl[1]; break;
						case "dbtype": strDatabaseType = spl[1];break;
					}
				}
				f.Close();
			}
			catch {}

			//DebugModule.WriteLine("MDSolutionEntities.DBModule.ReadDatabaseInfo\n\tServerName={0}, Database={1}, User ID={2}, Password={3}",
			//	strServerName, strDatabase, strUserName, strPassword);
		}
        public static long GetNewID(Type objType, string strTableName, OleDbConnection cn, OleDbTransaction trans)
        {
            long lRetVal = 1;
            string strSQL = "Select top 1 NewID from TG_NewID";
            DataSet ds = ExecuteQuery(strSQL, cn, trans);
            if (ds.Tables[0].Rows.Count == 0)
            {
                lRetVal = 1;
                strSQL = "Insert Into TG_NewID(NewID) values(1)";
                ExecuteNonQuery(strSQL, cn, trans);
            }
            else
            {
                lRetVal = long.Parse(ds.Tables[0].Rows[0][0].ToString()) + 1;
                strSQL = "update TG_NewID set NewID=" + lRetVal.ToString();
                ExecuteNonQuery(strSQL, cn, trans);
            }
            if (objType != null)
            {
                strSQL = "Insert Into TG_Objects(ObjectID, TypeFullName, AssemblyQualifiedName) values(" + lRetVal.ToString() + ",'" + objType.FullName + "','" + objType.AssemblyQualifiedName + "')";
                ExecuteNonQuery(strSQL, cn, trans);

                CreateObjectType(objType, strTableName, cn, trans);
                
            }
            return lRetVal;
        }
        public static void CreateObjectType(Type objType, string strTableName, OleDbConnection cn, OleDbTransaction trans)
        {
            string strClassName = objType.FullName;
            int nLastPlace = objType.FullName.LastIndexOf('.');

            if (nLastPlace >= 0) strClassName = objType.FullName.Substring(nLastPlace + 1);

            string strSQL = "Select top 1 Name from TG_ObjectType where Name=N'" + strClassName + "'";
            DataSet ds = ExecuteQuery(strSQL, cn, trans);
            if (ds.Tables[0].Rows.Count == 0)
            {
                strSQL = "Insert Into TG_ObjectType(Name, TypeFullName, Description, TableName) values(N'" + strClassName + "',N'" + objType.FullName + "',N'" + objType.AssemblyQualifiedName + "',N'" + strTableName + "')";
                ExecuteNonQuery(strSQL, cn, trans);

                // insert basic permission types
                strSQL = "select Max(ID) from TG_ObjectType";
                long lObjectTypeID = long.Parse(MDSolutionEntities.DBModule.ExecuteQueryForOneResult(strSQL, cn, trans));

                CreateBasicPermissions(lObjectTypeID, strClassName, cn, trans);
            }
        }
        public static void CreateBasicPermissions(long lObjectTypeID, string strClassName, OleDbConnection cn, OleDbTransaction trans)
        {
            long lID = GetNewID(null, "TG_Permissions", cn, trans);
            string strSQL = "Insert into TG_Permissions([ID],[ObjectTypeID],[Name],[UniqueName],[Description]) " +
                    "values(" + lID.ToString() + "," + lObjectTypeID + ",N'Add',N'" + strClassName + "Add',N'Add " + strClassName + "')";
            // run SQL statement
            MDSolutionEntities.DBModule.ExecuteNonQuery(strSQL, cn, trans);

            lID = GetNewID(null, "TG_Permissions", cn, trans);
            strSQL = "Insert into TG_Permissions([ID],[ObjectTypeID],[Name],[UniqueName],[Description]) " +
            "values(" + lID.ToString() + "," + lObjectTypeID + ",N'Delete',N'" + strClassName + "Delete',N'Add " + strClassName + "')";
            // run SQL statement
            MDSolutionEntities.DBModule.ExecuteNonQuery(strSQL, cn, trans);

            lID = GetNewID(null, "TG_Permissions", cn, trans);
            strSQL = "Insert into TG_Permissions([ID],[ObjectTypeID],[Name],[UniqueName],[Description]) " +
            "values(" + lID.ToString() + "," + lObjectTypeID + ",N'Edit',N'" + strClassName + "Edit',N'Add " + strClassName + "')";
            // run SQL statement
            MDSolutionEntities.DBModule.ExecuteNonQuery(strSQL, cn, trans);

            lID = GetNewID(null, "TG_Permissions", cn, trans);
            strSQL = "Insert into TG_Permissions([ID],[ObjectTypeID],[Name],[UniqueName],[Description]) " +
            "values(" + lID.ToString() + "," + lObjectTypeID + ",N'List',N'" + strClassName + "List',N'Add " + strClassName + "')";
            // run SQL statement
            MDSolutionEntities.DBModule.ExecuteNonQuery(strSQL, cn, trans);

            lID = GetNewID(null, "TG_Permissions", cn, trans);
            strSQL = "Insert into TG_Permissions([ID],[ObjectTypeID],[Name],[UniqueName],[Description]) " +
            "values(" + lID.ToString() + "," + lObjectTypeID + ",N'View',N'" + strClassName + "View',N'Add " + strClassName + "')";
            // run SQL statement
            MDSolutionEntities.DBModule.ExecuteNonQuery(strSQL, cn, trans);
        }
        public static void ReturnID(long lID, OleDbConnection cn, OleDbTransaction trans)
        {
            if (lID > 0)
            {
                string strSQL = "Select top 1 ReturnID from TG_ReturnID where ReturnID=" + lID.ToString();
                DataSet ds = ExecuteQuery(strSQL, cn, trans);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    strSQL = "Insert Into TG_ReturnID(ReturnID) values(" + lID.ToString() + ")";
                    ExecuteNonQuery(strSQL, cn, trans);
                }                

                strSQL = "Delete from TG_Objects where ObjectID=" + lID.ToString();
                ExecuteNonQuery(strSQL, cn, trans);
            }
        }
        public static bool isTableExisting(string strTableName, OleDbConnection cn, OleDbTransaction trans)
        {
            bool retVal = true;
            string strSQL = "SELECT top 1 * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[" + strTableName + "]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1";
            DataSet ds = ExecuteQuery(strSQL, cn, trans);
            if (ds.Tables[0].Rows.Count == 0) retVal = false;
            return retVal;
        }
        public static bool isColumnExisting(string strTableName, string strColumnName, OleDbConnection cn, OleDbTransaction trans)
        {
            bool retVal = true;
            string strSQL = "select top 1 * FROM INFORMATION_SCHEMA.COLUMNS where column_name = '" + strColumnName + "' and table_name = '" + strTableName + "'";
            DataSet ds = ExecuteQuery(strSQL, cn, trans);
            if (ds.Tables[0].Rows.Count == 0) retVal = false;
            return retVal;
        }
        public static bool isIndexExisting(string strTableName, string strColumnName, OleDbConnection cn, OleDbTransaction trans)
        {
            bool retVal = false;
            string strSQL = "SELECT TOP 1 sysindexkeys.ID FROM sysindexkeys,INFORMATION_SCHEMA.COLUMNS " +
                            "WHERE sysindexkeys.id = OBJECT_ID(N'[" + strTableName + "]') " +
                                "AND INFORMATION_SCHEMA.COLUMNS.TABLE_NAME ='" + strTableName + "' " +
                                "AND INFORMATION_SCHEMA.COLUMNS.COLUMN_NAME='" + strColumnName + "' " +
                                "AND INFORMATION_SCHEMA.COLUMNS.ORDINAL_POSITION=sysindexkeys.COLID";
            DataSet ds = ExecuteQuery(strSQL, cn, trans);
            if (ds.Tables[0].Rows.Count > 0) retVal = true;
            return retVal;
        }
        public static bool isStoredProcedureExisting(string strStoredProcedureName, OleDbConnection cn, OleDbTransaction trans)
        {
            bool retVal = false;
            string strSQL = "select name from sysobjects where type = 'P' and name = '" + strStoredProcedureName + "'";
            DataSet ds = ExecuteQuery(strSQL, cn, trans);
            if (ds.Tables[0].Rows.Count > 0) retVal = true;
            return retVal;
        }
        public static string buildQueryPart(string strField, string strValueList, string strFieldType, string strExpType)
        {
            string retVal = "";
            switch (strFieldType.ToLower())
            {
                case "char":
                case "varchar":
                case "text":                
                    if (strValueList.IndexOf("like ") >= 0)
                    {
                        strValueList = strValueList.Replace("like ", "like '");
                        strValueList = strValueList + "'";
                        retVal = strField + " " + strValueList;
                    }
                    else
                    {
                        strValueList = strValueList.Replace("'", "''");
                        strValueList = strValueList.Replace(",", "','");
                        strValueList = "'" + strValueList + "'";

                        retVal = strField;
                        if (strValueList.IndexOf(",") > 0)
                        {
                            if ((strExpType == "=") || (strExpType == "in"))
                                retVal += " in (" + strValueList + ")";
                            else
                                retVal += " not in (" + strValueList + ")";
                        }
                        else
                        {
                            retVal += " " + strExpType + " " + strValueList;
                        }
                    }
                    break;
                case "nchar":
                case "nvarchar":
                case "ntext":
                    if (strValueList.IndexOf("like ") >= 0)
                    {
                        strValueList = strValueList.Replace("like ", "like N'");
                        strValueList = strValueList + "'";
                        retVal = strField + " " + strValueList;
                    }
                    else
                    {
                        strValueList = strValueList.Replace("'", "''");
                        strValueList = strValueList.Replace(",", "',N'");
                        strValueList = "N'" + strValueList + "'";

                        retVal = strField;
                        if (strValueList.IndexOf(",") > 0)
                        {
                            if ((strExpType == "=") || (strExpType == "in"))
                                retVal += " in (" + strValueList + ")";
                            else
                                retVal += " not in (" + strValueList + ")";
                        }
                        else
                        {
                            retVal += " " + strExpType + " " + strValueList;
                        }
                    }
                    break;
                case "datetime":
                    strValueList = strValueList.Replace("'", "''");
                    if (strValueList != "")
                    {
                        if (DbType == MDSolutionEntities.DBModule.Access)
                        {
					        strValueList = strValueList.Replace(",", "#,#");
                            strValueList = "#" + strValueList + "#";
                        }
                        else if(DbType == MDSolutionEntities.DBModule.SQLServer)
                        {
                            strValueList = strValueList.Replace(",", "','");
                            strValueList = "'" + strValueList + "'";
                        }

                        retVal = strField;
                        if (strValueList.IndexOf(",") > 0)
                        {
                            if ((strExpType == "=") || (strExpType == "in"))
                                retVal += " in (" + strValueList + ")";
                            else
                                retVal += " not in (" + strValueList + ")";
                        }
                        else
                        {
                            retVal += strExpType + strValueList;
                        }
                    }
                    break;
                default:
                    if (strValueList != "")
                    {
                        retVal = strField;
                        if (strValueList.IndexOf(",") > 0)
                        {
                            if ((strExpType == "=") || (strExpType == "in"))
                                retVal += " in (" + strValueList + ")";
                            else
                                retVal += " not in (" + strValueList + ")";
                        }
                        else
                        {
                            retVal += strExpType + strValueList;
                        }
                    }
                    break;
            }

            return retVal;
        }
        #endregion

        #region Stored Procedure functions
        public static void GetDatabaseDataType(string strFieldName, string strTableNames, out string strDataType, out string strMaxLength, OleDbConnection cn, OleDbTransaction trans)
        {
            strDataType = "varchar";
            strMaxLength = "";
            string strSQL;
            DataSet ds;
            DataRow dr;
            string strTableName;
            int nPlace = strFieldName.IndexOf('.');
            if (nPlace > 0)
            {
                strFieldName = strFieldName.Substring(nPlace + 1);
                strTableName = strFieldName.Substring(0, nPlace);
                strSQL = "select Data_Type, character_maximum_length FROM INFORMATION_SCHEMA.COLUMNS where table_name = '" + strTableName + "'" +
                    " and Column_Name='" + strFieldName + "'";
                ds = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, cn, trans);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dr = ds.Tables[0].Rows[0];
                    strDataType = dr["Data_Type"].ToString();
                    if (!dr.IsNull("character_maximum_length")) strMaxLength = dr["character_maximum_length"].ToString();
                }
            }
            else
            {
                string[] arrTables = strTableNames.Split(new char[] { ',', ';' });
                for (int i = 0; i < arrTables.Length; i ++ )
                {
                    strTableName = arrTables[i];
                    strSQL = "select Data_Type,character_maximum_length FROM INFORMATION_SCHEMA.COLUMNS where table_name = '" + strTableName + "'" +
                        " and Column_Name='" + strFieldName + "'";
                    ds = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, cn, trans);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        dr = ds.Tables[0].Rows[0];
                        strDataType = dr["Data_Type"].ToString();
                        if (!dr.IsNull("character_maximum_length")) strMaxLength = dr["character_maximum_length"].ToString();
                    }
                }
            }
        }
        public static string CreateSPSelectScript(string strSPName, string strParamDefinition,
            string strBegin, string strEnd,
            string strSelect, string strFrom, string strWhere, 
            string strOrderBy, string strOrderBySort, string strTableNames, 
            string strKeyField, OleDbConnection cn, OleDbTransaction trans)
        {            
            
            string strOrderByDataType, strDataTypeMaxLength;
            MDSolutionEntities.DBModule.GetDatabaseDataType(strOrderBy, strTableNames, out strOrderByDataType, out strDataTypeMaxLength, cn, trans);

            string retVal = ""; // "IF EXISTS (SELECT name FROM   sysobjects " +
                             //"WHERE  name = N'" + strSPName + "' AND type = 'P') " +
                             //"DROP PROCEDURE " + strSPName + " \n\r";
            retVal += "CREATE PROCEDURE " + strSPName + "\n\r";
            if (strParamDefinition.Length > 0) retVal += strParamDefinition + "\n\r";
            retVal += "AS\n\r";            
            retVal += "BEGIN\n\r";
            retVal += strBegin + "\n\r";
            retVal += "declare @startRow int, @endRow int, @rowCount int, @pageCount int\n\r";
            retVal += "set @startRow = @pageSize * (@pageNumber - 1)\n\r";
            retVal += "set @endRow = @pageSize * @pageNumber\n\r";
            // calculate exactly the total number of records and the number of pages
            retVal += "select @rowCount = count(*)\n\r";
            retVal += "from " + strFrom + "\n\r";
            if (strWhere.Length > 0) retVal += "where " + strWhere + "\n\r";

            retVal += "declare @dCount as decimal(8,2)\n\r";
            retVal += "Set @dCount = @rowCount\n\r";
            retVal += "if(@dCount > 0 and @pageSize > 0) set @pageCount = ceiling(@dCount / @pageSize)\n\r";
            retVal += "else set @pageCount = 0\n\r";
            retVal += "declare @startingValue " + strOrderByDataType;
            if (strDataTypeMaxLength.Length > 0) retVal += "(" + strDataTypeMaxLength + ")";
            retVal += "\n\r";
            retVal += "declare @startingID int\n\r";
            // work out the starting values
            retVal += "if(@startRow > 0) set rowcount @startRow\n\r";
            retVal += "else set rowcount 1\n\r";
            // skip first rows
            retVal += "select @startingValue = " + strOrderBy + ", @startingID = " + strKeyField + "\n\r";
            retVal += "from " + strFrom + "\n\r";
            if (strWhere.Length > 0) retVal += "where " + strWhere + "\n\r";
            retVal += "order by " + strOrderBy + " " + strOrderBySort + ", " + strKeyField + " " + strOrderBySort + "\n\r";
            // get the page rows
            retVal += "if (@endRow > @rowCount) set @endRow = @rowCount\n\r";
            retVal += "set @endRow = @endRow - @startRow \n\r";
            retVal += "if(@endRow > 0) set rowcount @endRow\n\r";
            retVal += "else set rowcount 0\n\r";            

            retVal += "select " + strSelect + "\n\r";
            retVal += "from " + strFrom + "\n\r";
            retVal += "where \n\r";
            retVal += "(@startRow = 0 OR (" + strOrderBy + " = @startingValue And " + strKeyField + " > @startingID) OR " + strOrderBy + " > @startingValue ) \n\r";
            if (strWhere.Length > 0) retVal += " and " + strWhere + "\n\r";
            retVal += "order by " + strOrderBy + " " + strOrderBySort + ", " + strKeyField + " " + strOrderBySort + "\n\r";

            // also return row count and page count
            retVal += "select @rowCount as [RowCount], @pageCount as [PageCount], @startRow + 1 as StartRow, @endRow as EndRow\n\r";

            retVal += strEnd + "\n\r";
            retVal += "END\n\r";
            return retVal;
        }
        public static void CreateSelectStoredProcedure(string strSPName, string strParamDefinition,
            string strBegin, string strEnd,
            string strSelect, string strFrom, string strWhere,
            string strOrderBy, string strOrderBySort, string strTableNames,
            string strKeyField, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = CreateSPSelectScript(strSPName, strParamDefinition, strBegin, strEnd, strSelect, strFrom, strWhere,
                strOrderBy, strOrderBySort, strTableNames,  strKeyField, cn, trans);
            //GV.gResponse.Write(strSQL + "<br>");
            MDSolutionEntities.DBModule.ExecuteNonQuery(strSQL, cn, trans);
        }
        public static DataSet ExecuteQuerySP(string strSQL, 
            int NumOfItemsPerPage, int ItemPage, out int TotalNumOfPages, out int TotalItems, 
            OleDbConnection cn, OleDbTransaction trans)
        {
            TotalNumOfPages = 0;
            TotalItems = 0;

            strSQL += "," + ItemPage + "," + NumOfItemsPerPage;
            DataSet ds = new DataSet();
            bool cnOpen = false;
            if (cn == null) cn = CreateDBConnection();
            else
            {
                cnOpen = (cn.State == ConnectionState.Open);
                if (!cnOpen) cn.Open();
            }
            try
            {
                if (!cnOpen) trans = cn.BeginTransaction(IsolationLevel.ReadUncommitted);

                OleDbDataAdapter adapter = new OleDbDataAdapter(new OleDbCommand(strSQL, cn, trans));
                adapter.Fill(ds);

                TotalNumOfPages = int.Parse(ds.Tables[1].Rows[0]["PageCount"].ToString());
                TotalItems = int.Parse(ds.Tables[1].Rows[0]["RowCount"].ToString());


                if (!cnOpen) trans.Commit();
            }
            finally
            {
                if (!cnOpen) CloseDBConnection(cn);
            }
            return ds;
        }
        #endregion
    }
}