

export interface Order {
    orderID:number;
    custID:string;
    prodID:string;
    orderDate:string;
    quantity:number;
    shipDate:string;
    shipMode:string;
}
export interface Product {
    prodID:string;
    catID:number;
    description_:string;
    unitPrice:number;          
}

export interface Customer {
    custID:string;
    fullName:string;
    segID:number;
    country:string;
    city:string;
    state_:string;
    region:string;
    postCode:string;           
}