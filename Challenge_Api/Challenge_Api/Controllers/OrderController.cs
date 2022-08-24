using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using Challenge_Api.Modals;


namespace Challenge_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;
        public OrderController(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }
        
        //Get Orders

        [HttpGet]
        [Route("get-all")]
        public JsonResult Get()
        {
            string query = @"
                            select * from
                            Order_
                            ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("ChallengeDbConnectionString");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult(table);
        }

        //Add Order

        [HttpPost]
        [Route("add")]
        public JsonResult Post(string CustID, string ProdID, string OrderDate, int Quantity, string ShipDate, string ShipMode)
        {
            string query = @"
                            insert into Order_ (CustID, ProdID, OrderDate, Quantity, ShipDate, ShipMode)
                            VALUES (@CustID, @ProdID, @OrderDate, @Quantity, @ShipDate, @ShipMode)

                            
                            ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("ChallengeDbConnectionString");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {                
                    myCommand.Parameters.AddWithValue("@CustID", CustID);
                    myCommand.Parameters.AddWithValue("@ProdID", ProdID);
                    myCommand.Parameters.AddWithValue("@OrderDate", OrderDate);
                    myCommand.Parameters.AddWithValue("@Quantity", Quantity);
                    myCommand.Parameters.AddWithValue("@ShipDate", ShipDate);
                    myCommand.Parameters.AddWithValue("@ShipMode", ShipMode);
                    

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Added Successfully");
        }

        //Delete Order

        [HttpDelete("{id}")]


        public JsonResult Delete(int id)
        {
            string query = @"
                            delete from Order_                           
                            where OrderID = @OrderID
                            ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("ChallengeDbConnectionString");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@OrderID", id);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Deleted Successfully");
        }

        //Update Order

        [HttpPut]
        [Route("update")]        
        public JsonResult Put(int OrderID, string CustID, string ProdID, string OrderDate, int Quantity, string ShipDate, string ShipMode)
        {
            
            string query = @"update Order_ set ProdID = @ProdID, OrderDate = @OrderDate, Quantity = @Quantity, ShipDate = @ShipDate, ShipMode = @ShipMode where OrderID = @OrderID ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("ChallengeDbConnectionString");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@OrderID", OrderID);
                    myCommand.Parameters.AddWithValue("@ProdID", ProdID);
                    myCommand.Parameters.AddWithValue("@OrderDate", OrderDate);
                    myCommand.Parameters.AddWithValue("@Quantity", Quantity);
                    myCommand.Parameters.AddWithValue("@ShipDate", ShipDate);
                    myCommand.Parameters.AddWithValue("@ShipMode", ShipMode);
                    

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Updated Successfully");
        }
    }
}
