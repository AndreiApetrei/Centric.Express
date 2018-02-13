import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
// import { Input } from '@angular/core/src/metadata/directives';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {
  @Input() product: any;
  @Output() addToCart: EventEmitter<any> = new EventEmitter<any>();
  constructor() {}
  ngOnInit() {}

  add() {
    this.addToCart.emit(this.product);
  }
}
