using OTTApp.Models;
using System.Data;
using System.Data.SqlClient;

namespace OTTApp.Respo
{
    public class OTT_DataAccess
    {
        public static List<MovieList> getList() { 
        
            List<MovieList > list = new List<MovieList>();
            using (SqlConnection connection = new SqlConnection(AppConnections.GetMyConnection())) 
            { 
            connection.Open();
                string SQL = "select ID,Type,Name,Rating,CreatedDate from tbl_Movies";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(SQL, connection);
                DataTable dt = new DataTable();
                sqlDataAdapter.Fill(dt);
                connection.Close();
                if(dt.Rows.Count > 0 )
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        MovieList movieList = new MovieList();
                        movieList.ID = int.Parse(dt.Rows[i]["ID"].ToString());
                        movieList.Type = dt.Rows[i]["Type"].ToString();
                        movieList.Name = dt.Rows[i]["Name"].ToString();
                        movieList.Rating = dt.Rows[i]["Rating"].ToString();
                        movieList.CreatedDate = dt.Rows[i]["CreatedDate"].ToString();

                        list.Add(movieList);
                    }

                }
            
            }
            return list;


        }
        public static List<MovieList> getListByType(GetListReq getList)
        {

            List<MovieList> list = new List<MovieList>();
            using (SqlConnection connection = new SqlConnection(AppConnections.GetMyConnection()))
            {
                connection.Open();
                string SQL = "select ID,Type,Name,Rating,CreatedDate from tbl_Movies where Type='"+ getList.Type+ "'";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(SQL, connection);
                DataTable dt = new DataTable();
                sqlDataAdapter.Fill(dt);
                connection.Close();
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        MovieList movieList = new MovieList();
                        movieList.ID = int.Parse(dt.Rows[i]["ID"].ToString());
                        movieList.Type = dt.Rows[i]["Type"].ToString();
                        movieList.Name = dt.Rows[i]["Name"].ToString();
                        movieList.Rating = dt.Rows[i]["Rating"].ToString();
                        movieList.CreatedDate = dt.Rows[i]["CreatedDate"].ToString();

                        list.Add(movieList);
                    }

                }

            }
            return list;


        }


        public static string insertMovies(MovieListReq movieList)
        {
            using (SqlConnection connection = new SqlConnection(AppConnections.GetMyConnection()))
            {

                string SQL = "insert into tbl_Movies (Type,Name,Rating) values (@Type,@Name,@Rating)";
                using (SqlCommand command = new SqlCommand(SQL, connection))
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@Type", movieList.Type);
                    command.Parameters.AddWithValue("@Name", movieList.Name);
                    command.Parameters.AddWithValue("@Rating", movieList.Rating);
                    command.Parameters.AddWithValue("@CreatedDate", DateTime.Now.ToString());
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                  
            }
                return "Movie Added successfully !";
        }

        public static bool CheckUserDetails(LoginReq loginReq)
        {
            bool IsTrue = false;
            using (SqlConnection connection = new SqlConnection(AppConnections.GetMyConnection()))
            {
                connection.Open();
                string SQL = "select * from tbl_loginDetails where username='"+ loginReq.Username + "' and password='"+ loginReq.Password + "'";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(SQL, connection);
                DataTable dt = new DataTable();
                sqlDataAdapter.Fill(dt);
                connection.Close();
                if (dt.Rows.Count > 0)
                {
                    IsTrue = true;

                }

            }
            return IsTrue;


        }
    }
}
