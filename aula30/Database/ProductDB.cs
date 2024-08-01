using aula30.Models;
using Npgsql;

namespace aula30.Database
{
    public class ProductDB
    {
        public bool Add (product product) 
        {
            bool result = false;

            try
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.CommandText = @"insert into products " + 
                        @"(name,description,qtd,price) " + 
                        @"values " +
                        @"(@name,@description,@qtd,@price);";

                    cmd.Parameters.AddWithValue("@name", product.Name);
                    cmd.Parameters.AddWithValue("@description", product.Description);
                    cmd.Parameters.AddWithValue("@qtd", product.qtd);
                    cmd.Parameters.AddWithValue("@price", product.price);

                    AccessDB db = new AccessDB();

                    using (cmd.Connection = db.OpenConnection())
                    {
                        cmd.ExecuteNonQuery();
                        result = true;
                    }

                }
            }
            catch (Exception ex)
            { 
            }
            return result;
        }
    }
}
