import { Component } from '@angular/core';
import { ProductService } from '../../services/product.service';
import { Product } from '../../models/product';
import { Router } from '@angular/router';

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

  constructor(private productService: ProductService, private router: Router) { }

  onSubmit(): void {
    if (this.product.id === 0) {
      this.productService.addProduct(this.product).subscribe(
        response => {
          console.log('Product added successfully:', response);
          this.resetForm();
          this.router.navigate('user/viewProducts');
        },
        error => {
          console.error('Error adding product:', error);
        }
      );
    } else {
      this.productService.editProduct(this.product).subscribe(
        response => {
          console.log('Product updated successfully:', response);
          this.resetForm();
        },
        error => {
          console.error('Error updating product:', error);
        }
      );
    }
  }

  deleteProduct(id: number): void {
    this.productService.deleteProduct(id).subscribe(
      () => {
        console.log('Product deleted successfully');
      },
      error => {
        console.error('Error deleting product:', error);
      }
    );
  }

  editProduct(product: Product): void {
    this.product = { ...product };
  }

  resetForm(): void {
    this.product = {
      id: 0,
      name: '',
      description: '',
      price: 0,
      imageUrl: '',
      category: ''
    };
  }
}
