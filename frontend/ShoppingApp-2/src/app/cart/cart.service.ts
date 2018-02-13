import { Injectable } from '@angular/core';
import { Subject } from 'rxjs/Subject';

@Injectable()
export class CartService {
  private cart: any[] = [];
  private cart$: Subject<any> = new Subject<any>();
  constructor() {}

  public getCart() {
    return this.cart$.asObservable();
  }

  add(prod) {
    const alreadyInCard = this.cart.findIndex(element => {
      return element.id === prod.id;
    });
    if (alreadyInCard !== -1) {
      this.cart[alreadyInCard].quantity++;
    } else {
      prod.quantity = 1;
      this.cart.push(prod);
    }
    this.cart$.next(this.cart);
  }

  delete(index?: any) {
    const cart = this.cart.splice(index, 1);
    this.cart$.next(this.cart);
  }
}
