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

        public  product get (int id) 
        {
            product result = new product();
            AccessDB db = new AccessDB();

                try
                {
                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.CommandText = @"select * from products " + @"where id=@id;";

                    cmd.Parameters.AddWithValue("@id", id);

                    using (cmd.Connection=db.OpenConnection())
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read()) 
                        {
                            result.Id = Convert.ToInt32(reader["id"]);
                            result.Name = reader["name"].ToString();
                            result.Description = reader["description"].ToString();
                            result.qtd = Convert.ToInt32(reader["qtd"]);
                            result.price = float.Parse(reader["price"].ToString());
                        }
                    }

                }
                }
                catch (Exception ex)
                {
                }

                return result;
            }

        public List<product> GetAll()
        { 
          List<product> result = new List<product>();
            AccessDB db = new AccessDB();

            try
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.CommandText = @"select * from products;";

                    using (cmd.Connection = db.OpenConnection())
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            product product = new product();
                            product.Id = Convert.ToInt32(reader["id"]);
                            product.Name = reader["name"].ToString();
                            product.Description = reader["description"].ToString();
                            product.qtd = Convert.ToInt32(reader["qtd"]);
                            product.price = float.Parse(reader["price"].ToString());
                            result.Add(product);

                        }
                    }
                }
            }
            catch (Exception)
            {

                
            }
            return result;
        }


        public bool Update(product product)
        {
            bool result = false;
            AccessDB db = new AccessDB();

            try
            {
                using(NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.CommandText = @"UPDATE products " + @"SET name = @name, description = @description, " + @"qtd = @qtd, price = @price " + @"WHERE id = @id;";

                    cmd.Parameters.AddWithValue("@id", product.Id);
                    cmd.Parameters.AddWithValue("@name", product.Name);
                    cmd.Parameters.AddWithValue("@description", product.Description);
                    cmd.Parameters.AddWithValue("@qtd", product.qtd);
                    cmd.Parameters.AddWithValue("@price", product.price);

                    using(cmd.Connection = db.OpenConnection()) 
                    {
                        cmd.ExecuteNonQuery();
                        result = true;

                    }


                }
            }
            catch (Exception ex)
            { }


            return result;
        }

        public bool Delete(int id) 
        {
            bool result = false;
            AccessDB db = new AccessDB();

            try
            {
                using(NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.CommandText = @"delete from products where id = @id;";

                    cmd.Parameters.AddWithValue("@id", id);

                    using (cmd.Connection = db.OpenConnection())
                    {
                        cmd.ExecuteNonQuery();
                        result = true;
                    }

                }

            }
            catch (Exception ex)
            { }
            
            
            
            
            
            return result;
        }







        }
    }

