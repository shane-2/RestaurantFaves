import { Component, OnInit } from '@angular/core';
import { Order } from 'src/app/Models/order';
import { OrderService } from 'src/app/services/order.service';

@Component({
  selector: 'app-order-history',
  templateUrl: './order-history.component.html',
  styleUrls: ['./order-history.component.css']
})
export class OrderHistoryComponent implements OnInit {

OrderListResult:Order[] = [];

  constructor(private orderService:OrderService) { }

  ngOnInit(): void {
    this.orderService.GetOrders().subscribe((response:Order[]) =>{
      console.log(response)
      this.OrderListResult = response;
      
    })
  }


  RemoveOrder(id:number):void{
    let target:number = this.OrderListResult.findIndex(i => i.id == id);
    this.OrderListResult.splice(target, 1);

    this.orderService.DeleteOrder(id).subscribe((response:Order) =>{
      console.log(response);
    })
  }

  NewOrder(newOrder:Order){
    this.orderService.AddOrder(newOrder).subscribe((response:Order) =>{
      console.log(response)
      this.OrderListResult.push(response);
    })
  }



}
