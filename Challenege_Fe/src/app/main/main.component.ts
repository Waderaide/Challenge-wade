import { Component, Input, OnInit } from '@angular/core';
import { OrderService } from '../Services/service';
import { Order, Product, Customer } from '../Modals/Orders';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css']
})
export class MainComponent implements OnInit {

  constructor(private service:OrderService) { }
  
  
  
  ngDropdown!:number;
  CustomerList: Customer[] = [];
  ProductsList: Product[] = [];
  
  product:Product = {
    prodID:"",
    catID:0,
    description_:"",
    unitPrice:0    
  }

  customer:Customer = {
    custID:"",
    fullName:"",
    segID:0,
    country:"",
    city:"",
    state_:"",
    region:"",
    postCode:""
  }

  OrdersList:any=[];
  @Input() order:Order = {
    orderID:0,
    custID:"",
    prodID:"",
    orderDate:"",
    quantity:0,
    shipDate:"",
    shipMode:""
  };
  myOrder!:Order; 
  orderID!:number;
  custID!:string;
  prodID!:string;
  orderDate!:string;
  quantity!:number;
  shipDate!:string;
  shipMode!:string;

  


  ngOnInit(): void {
    this.refreshOrdersList()
    this.getCustomerInfo()
    this.getProductInfo()
    
    
  }
  
  createOrder() {
    
      console.log(this.custID)
      console.log(this.prodID)
      console.log(this.orderDate)
      this.service.addOrder(this.custID, this.prodID, this.orderDate, this.quantity, this.shipDate, this.shipMode)
      .subscribe({
        next:(resp:any) => console.log(resp),
        error:(err:any) => console.log(err),
        complete:() => this.refreshOrdersList()
        
      }
      )
      
  }
  getCustomerInfo(){    
    this.service.getAllCustomers().subscribe(data=>{               
      this.CustomerList=data;      
      this.customer.custID = this.CustomerList[0].custID;   
    })
  }
  getProductInfo(){    
    this.service.getAllProducts().subscribe(data=>{               
      this.ProductsList=data;      
      this.product.prodID = this.ProductsList[0].prodID;
 
                 
    })
  }

  deleteClick(item:any) {
    console.log(item.orderID)
    this.service.deleteOrder(item.orderID).subscribe(data=>{          
      this.refreshOrdersList();
    })
  }
  editClick(item:any) {
    
    
    this.order=item;
    
  }
  updateOrder(order: Order){ 
        
        
    
      console.log(order)      
      this.service.updateCard(order.orderID, order.custID, order.prodID, order.orderDate, order.quantity, order.shipDate, order.shipMode)
      .subscribe({
        next:(resp:any) => console.log(resp),
        error:(err:any) => console.log(err),
        complete:() => this.refreshOrdersList()
      })
        
       
      }
  onSelection(event: any) {
    this.custID = event;
    console.log(this.custID)
  }
  onSelectionProduct(event: any) {
    this.prodID = event;
    console.log(this.prodID)
    
  }
  //gets and refreshes order list
  refreshOrdersList(){
    this.service.getAllOrders().subscribe(data=>{
      
      this.OrdersList=data;      
    });
  }

}
