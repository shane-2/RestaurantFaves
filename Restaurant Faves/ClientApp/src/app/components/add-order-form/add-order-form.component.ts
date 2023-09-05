import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Order } from 'src/app/Models/order';


@Component({
  selector: 'app-add-order-form',
  templateUrl: './add-order-form.component.html',
  styleUrls: ['./add-order-form.component.css']
})
export class AddOrderFormComponent implements OnInit {
  o:Order = {} as Order;
  @Output() OrderCreated = new EventEmitter<Order>();
  constructor() { }

  ngOnInit(): void {
  }

CreateOrder(){
  this.OrderCreated.emit(this.o);
}

}
