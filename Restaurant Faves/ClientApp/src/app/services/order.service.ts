import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';

import { Order } from '../Models/order';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class OrderService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }


GetOrders():Observable<Order[]>{
  return this.http.get<Order[]>(`${this.baseUrl}api/Order`);
}

DeleteOrder(id:number):Observable<Order>{
  return this.http.delete<Order>(`${this.baseUrl}api/Order/${id}`);

}

AddOrder(newOrder:Order):Observable<Order>{
  return this.http.post<Order>(`${this.baseUrl}api/Order`,newOrder);
}



}
