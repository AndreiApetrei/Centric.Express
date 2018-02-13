import { Component } from '@angular/core';
import { CartService } from './cart/cart.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'app';
  products = [
    {
      id: 1,
      title: 'Mahogany bed',
      price: 100,
      image: 'assets/images/mahogany-bed.png'
    },
    {
      id: 2,
      title: 'Black wardrobe',
      price: 400,
      image: 'assets/images/black-wardrobe.png'
    },
    {
      id: 3,
      title: 'Flower cushions',
      price: 45,
      image: 'assets/images/flower-cushions.png'
    },
    {
      id: 4,
      title: 'Wing chair',
      price: 89,
      image: 'assets/images/wing-chair.png'
    }
  ];
  constructor(private cartService: CartService) {}

  addToCart(prod) {
    this.cartService.add(prod);
  }
}
