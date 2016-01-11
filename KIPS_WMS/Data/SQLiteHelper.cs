using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using WM6._5_W_RS;

namespace WM_W_RS.Data
{
    public class SQLiteHelper
    {
        public static DataSet query(String select, Object[] args, String tableName)
        {
            var sqliteCon = new SQLiteConnection(Util.GetDbCnnectionString());
            try
            {
                sqliteCon.Open();

                String selectPrepared = null;
                if (args.Length > 0)
                {
                    selectPrepared = String.Format(select, args);
                }
                else
                {
                    selectPrepared = select;
                }

                var selectCommand = new SQLiteCommand(selectPrepared, sqliteCon);
                var selectAdapter = new SQLiteDataAdapter(selectCommand);
                var dataSet = new DataSet();
                selectAdapter.Fill(dataSet, tableName);

                sqliteCon.Close();

                return dataSet;
            }
            catch (Exception)
            {
                if (sqliteCon.State == ConnectionState.Open)
                {
                    sqliteCon.Close();
                }
                return null;
            }
        }

        public static Object simpleQuery(String select, Object[] args)
        {
            var sqliteCon = new SQLiteConnection(Util.GetDbCnnectionString());
            try
            {
                Object result = null;
                sqliteCon.Open();

                String selectPrepared = null;
                if (args.Length > 0)
                {
                    selectPrepared = String.Format(select, args);
                }
                else
                {
                    selectPrepared = select;
                }

                var selectCommand = new SQLiteCommand(selectPrepared, sqliteCon);
                SQLiteDataReader dataReader = selectCommand.ExecuteReader();
                if (dataReader.Read())
                {
                    if (dataReader.IsDBNull(0))
                    {
                        result = null;
                    }
                    else
                    {
                        result = dataReader[0];
                    }
                }

                dataReader.Close();

                sqliteCon.Close();

                return result;
            }
            catch (Exception)
            {
                if (sqliteCon.State == ConnectionState.Open)
                {
                    sqliteCon.Close();
                }
                return null;
            }
        }

        public static List<Object[]> multiRowQuery(String select, Object[] args)
        {
            var sqliteCon = new SQLiteConnection(Util.GetDbCnnectionString());
            try
            {
                sqliteCon.Open();

                String selectPrepared = null;
                if (args.Length > 0)
                {
                    selectPrepared = String.Format(select, args);
                }
                else
                {
                    selectPrepared = select;
                }

                var selectCommand = new SQLiteCommand(selectPrepared, sqliteCon);
                SQLiteDataReader dataReader = selectCommand.ExecuteReader();

                var rowResult = new List<Object[]>();

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        var row = new Object[dataReader.FieldCount];
                        for (int i = 0; i < dataReader.FieldCount; i++)
                        {
                            if (dataReader.IsDBNull(i))
                            {
                                row[i] = null;
                            }
                            else
                            {
                                row[i] = dataReader[i];
                            }
                        }
                        rowResult.Add(row);
                    }
                }

                dataReader.Close();

                sqliteCon.Close();

                return rowResult;
            }
            catch (Exception)
            {
                if (sqliteCon.State == ConnectionState.Open)
                {
                    sqliteCon.Close();
                }
                return null;
            }
        }

        /// <summary>
        ///     Resturns multiple rows in list of objects. Should be used when you want one result from row.
        /// </summary>
        /// <param name="select"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static List<Object> oneRowQuery(String select, Object[] args)
        {
            var sqliteCon = new SQLiteConnection(Util.GetDbCnnectionString());
            try
            {
                sqliteCon.Open();

                String selectPrepared = null;
                if (args.Length > 0)
                {
                    selectPrepared = String.Format(select, args);
                }
                else
                {
                    selectPrepared = select;
                }

                var selectCommand = new SQLiteCommand(selectPrepared, sqliteCon);
                SQLiteDataReader dataReader = selectCommand.ExecuteReader();

                var rowResult = new List<Object>();
                if (dataReader.Read())
                {
                    for (int i = 0; i < dataReader.FieldCount; i++)
                    {
                        if (dataReader.IsDBNull(i))
                        {
                            rowResult.Add(null);
                        }
                        else
                        {
                            rowResult.Add(dataReader[i]);
                        }
                    }
                }

                dataReader.Close();

                sqliteCon.Close();

                return rowResult;
            }
            catch (Exception e)
            {
                if (sqliteCon.State == ConnectionState.Open)
                {
                    sqliteCon.Close();
                }
                throw new Exception("", e);
            }
        }

        public static int nonQuery(String statement, Object[] args)
        {
            int result = -1;
            var sqliteCon = new SQLiteConnection(Util.GetDbCnnectionString());
            try
            {
                sqliteCon.Open();
                using (SQLiteTransaction sqlTransaction = sqliteCon.BeginTransaction())
                {
                    var command = new SQLiteCommand(String.Format(statement, args), sqliteCon);
                    result = command.ExecuteNonQuery();
                    sqlTransaction.Commit();
                }
                sqliteCon.Close();

                return result;
            }
            catch (Exception ex)
            {
                if (sqliteCon.State == ConnectionState.Open)
                {
                    sqliteCon.Close();
                }
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        ///     Runs insert query and returns record id.
        /// </summary>
        /// <param name="statement"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static int insertQuery(String statement, Object[] args)
        {
            int result = -1;
            var sqliteCon = new SQLiteConnection(Util.GetDbCnnectionString());
            try
            {
                sqliteCon.Open();
                using (SQLiteTransaction sqlTransaction = sqliteCon.BeginTransaction())
                {
                    var command = new SQLiteCommand(String.Format(statement, args), sqliteCon);
                    result = command.ExecuteNonQuery();

                    if (result > 0)
                    {
                        var getIdCommand = new SQLiteCommand("select last_insert_rowid();", sqliteCon);
                        Object obj = getIdCommand.ExecuteScalar();
                        result = Convert.ToInt32(obj);
                    }

                    sqlTransaction.Commit();
                }
                sqliteCon.Close();

                return result;
            }
            catch (Exception)
            {
                if (sqliteCon.State == ConnectionState.Open)
                {
                    sqliteCon.Close();
                }
                return result;
            }
        }
    }
}