import { Component } from '@angular/core';

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
  cartProd = [];

  addToCart(prod) {
    const alreadyInCard = this.cartProd.findIndex((element) => {
      return element.id === prod.id;
    });
    if (alreadyInCard !== -1) {
      this.cartProd[alreadyInCard].quantity++;
     } else {
      prod.quantity = 1;
      this.cartProd.push(prod);
    }
  }
}
