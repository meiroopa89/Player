import { Component } from '@angular/core';
import { Product } from '../../models/product';

@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.css']
})
export class AddProductComponent {
  product: Product = {
    id: 0,
    name: '',
    description: '',
    price: 0,
    imageUrl: '',
    category: ''
  };

  onSubmit() {
    // Add your form submission logic here
    console.log('Product Added:', this.product);
  }
}
