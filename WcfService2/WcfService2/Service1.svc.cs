using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Library4;

namespace WcfService2
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        string DB = "Data Source=DESKTOP-COE6723; Initial Catalog=BeautySalo; Integrated Security=true;";


        public double F4(double x)
        {
            return Class4.F4(x, 3);
        }

        public DataTable GetAllElements()
        {
            DataTable DatTab = new DataTable("DatTab1");
            using (SqlConnection sqlConn = new SqlConnection(DB))
            {
                sqlConn.Open();
                string query = "SELECT * FROM Salon";
                SqlDataAdapter sqlDatAdapt = new SqlDataAdapter(query, sqlConn);
                sqlDatAdapt.Fill(DatTab);
                return DatTab;
            }
        }

        public DataTable GetElementById(int ID)
        {
            DataTable dt = new DataTable("DatTab2");
            using (SqlConnection sqlConn = new SqlConnection(DB))
            {
                sqlConn.Open();
                string allId = "SELECT ID FROM Salon";
                SqlCommand allIDComm = new SqlCommand(allId, sqlConn);
                SqlDataReader allIDRead = allIDComm.ExecuteReader();
                List<int> listID = new List<int>();
                while (allIDRead.Read())
                {
                    listID.Add(int.Parse(allIDRead[0].ToString()));
                }
                allIDRead.Close();
                string query = $"SELECT * FROM Salon WHERE ID = {ID}";
                SqlCommand sqlComm = new SqlCommand(query, sqlConn);
                SqlDataReader sqlRead = sqlComm.ExecuteReader();
                sqlRead.Read();
                if (sqlRead[0].ToString() != null)
                {
                    int id = Int32.Parse(sqlRead[0].ToString());
                    sqlRead.Close();
                    for (int i = 0; i < listID.Count; i++)
                    {
                        if (listID[i] == id)
                        {
                            SqlDataAdapter sqlAdap = new SqlDataAdapter(query, sqlConn);
                            sqlAdap.Fill(dt);
                            return dt;
                        }
                    }
                }
                else
                {
                    System.Threading.Thread.Sleep(2000);
                }
                return null;
            }
        }
    }
}
