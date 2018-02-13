import { Component, OnInit, Input, DoCheck } from '@angular/core';
import { CartService } from './cart.service';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {
  // @Input()
  cartProd: any;
  total = 0;
  constructor(private cartService: CartService) {}

  ngOnInit() {
    this.cartService.getCart().subscribe(cart => {
      this.cartProd = cart;
      this.calculateTotal();
    });
  }

  prodModelChange() {
    this.calculateTotal();
  }

  onDelete(index) {
    this.cartService.delete(index);
  }
  calculateTotal() {
    this.total = 0;
    this.cartProd.forEach(value => {
      this.total += parseInt(value.quantity, 10) * value.price;
    });
  }
}
