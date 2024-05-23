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
          this.router.navigate(['user/viewProducts']); // Correct navigation syntax
        },
        error => {
          console.error('Error adding product:', error);
        }
      );
    } else {
      this.productService.updateProduct(this.product).subscribe( // Change to updateProduct
        response => {
          console.log('Product updated successfully:', response);
          this.resetForm();
          this.router.navigate(['user/viewProducts']); // Navigate after updating
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
        this.router.navigate(['user/viewProducts']); // Navigate after deleting
      },
      error => {
        console.error('Error deleting product:', error);
      }
    );
  }

  loadProductForEdit(product: Product): void { // Renamed to avoid confusion
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
