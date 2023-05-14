using Azure.Identity;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZealandZooLIB.Models;
using ZealandZooLIB.Secrets;

namespace ZealandZooLIB.Services
{
    public class BulletRepoService : IRepositoryService
    {
        #region Create
        public BaseModel Create(BaseModel model)
        {
            string queryString = "INSERT INTO [dbo].[Bullet] VALUES (@Title, @ContentBullet";
            using SqlConnection conn = new SqlConnection(Secret.GetSecret());
            {
                conn.Open();
                SqlCommand command = new SqlCommand(queryString, conn);
                Bullet bullet = (Bullet)model;

                command.Parameters.AddWithValue("@Title", bullet.Title);
                command.Parameters.AddWithValue("@ContentBullet", bullet.ContentBullet);

                int rows = command.ExecuteNonQuery();
                if(rows != 1) 
                {
                    throw new ArgumentException("Artiklen kan ikke blive oprettet");
                }

                return model;
            }
            
        }
        #endregion
        #region Delete
        public BaseModel Delete(int id)
        {
            Bullet deleteBullet = (Bullet)GetById(id);

            string queryString = "DELETE FROM [dbo].[Bullet] WHERE id = @Id";

            using SqlConnection conn = new SqlConnection(Secret.GetSecret());
            {
                SqlCommand command = new SqlCommand(queryString, conn);
                command.Connection.Open();
                command.Parameters.AddWithValue("@Id", id);

                int rows = command.ExecuteNonQuery();
                return deleteBullet;
            }

        }
        #endregion
        #region GetAll
        public List<BaseModel> GetAll()
        {
            SqlConnection conn = new SqlConnection(Secret.GetSecret());
            conn.Open();

            string sql = "SELECT" +
                        "[Id]," +
                        "[Title]," +
                        "[ContentBullet]" +
                        "FROM" +
                        "[bullerbob_dk_db_zealandzoo].[dbo].[Bullet]";

            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            List<BaseModel> bullets = new List<BaseModel>();
            while (reader.Read())
            {
                bullets.Add(ReadBullet(reader));
            }

            conn.Close();
            return bullets;

        }
        #endregion


        #region GetByID
        public BaseModel GetById(int id)
        {
            SqlConnection conn = new SqlConnection(Secret.GetSecret());
            conn.Open();

            string sql = "SELECT" +
                        "[Id]," +
                        "[Title]," +
                        "[ContentBullet]" +
                        "FROM" +
                        "[bullerbob_dk_db_zealandzoo].[dbo].[Bullet]" +
                        "WHERE" +
                        $"[Id] = {id}";

            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            List<Bullet>bullets= new List<Bullet>();
            while (reader.Read())
            {
                bullets.Add(ReadBullet(reader));
            }
            conn.Close();

            if (bullets.Count > 0)
            {
                return bullets[0];
            }
            else
            {
                throw new ArgumentException("Artiklen ikke fundet");
            }

        }
        #endregion
        #region Update
        public BaseModel Update(int id, BaseModel model)
        {
            string queryString = "UPDATE [dbo].[Bullet] SET " +
                                "[Title] = @Title," +
                                "[ContentBullet] = @ContentBullet" +
                                $"WHERE Id = {id}";
            using SqlConnection conn = new SqlConnection(Secret.GetSecret());
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(queryString, conn);
                Bullet bullet = (Bullet)model;
                cmd.Parameters.AddWithValue("@Title", bullet.Id);
                cmd.Parameters.AddWithValue("@ContentBullet", bullet.ContentBullet);

                SqlDataReader reader = cmd.ExecuteReader();
                if(reader.Read())
                {
                    model.Id = id;
                }
                else
                {
                    throw new ArgumentException("Artikkel ikke opdateret");
                }
                return model;
            }
        }
        #endregion

        private Bullet ReadBullet(SqlDataReader reader)
        {
            Bullet bullet = new Bullet();

            bullet.Id = reader.GetInt32(0);
            bullet.Title = reader.GetString(1);
            bullet.ContentBullet = reader.GetString(2);

            return bullet;
        }
    }
}
