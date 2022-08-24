using Challenge_Api.Modals;
namespace Challenge_Api.Modals
{
    public class Order
    {
        

        public Product Product { get; set; }
        public float UnitPrice { get { return Product.UnitPrice; } set {  } }
        public int OrderID { get; set; }
        public string CustID { get; set; }
        public string ProdID { get; set; }
        public string OrderDate { get; set; }
        public int Quantity { get; set; }

        public float Total { get; set; }
        public string ShipDate { get; set; }
        public string ShipMode { get; set; }

        
        

        public float GetTotal()
        {
            float total = UnitPrice * Quantity;
            Total = total;
            return total;

                
        } 
        public float CalculateGST()
        {
            double gst = (Total * 1.1) / 11;
            Math.Round(gst, 2);
            return (float)gst;
        }
    }
        
        

    
}
