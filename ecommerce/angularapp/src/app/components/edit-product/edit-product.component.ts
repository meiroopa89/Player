import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ProductService } from 'src/app/services/product.service';
import { Product } from 'src/app/models/product';

@Component({
  selector: 'app-edit-product',
  templateUrl: './edit-product.component.html',
  styleUrls: ['./edit-product.component.css']
})
export class EditProductComponent{
  
  products: Product[] = [];
  editingProduct: Product | null = null;
  readonly localStorageKey = 'products';

  constructor(private productService: ProductService, private router: Router) {}

  refreshProducts(): void {
    this.productService.getProducts().subscribe(products => {
      this.products = products;
      localStorage.setItem(this.localStorageKey, JSON.stringify(products));
    });
  }

  updateProduct(): void {
    if (this.editingProduct && this.editingProduct.productId) {
      console.log('Updating product with id:', this.editingProduct.productId); // Log to ensure id is being used
      this.productService.updateProduct(this.editingProduct).subscribe(updatedProduct => {
        console.log('Updated product:', updatedProduct); // Log the server response
        this.editingProduct = null;
        localStorage.removeItem('editingProduct');
        this.refreshProducts(); // Refresh the product list after update
        this.router.navigate(['/admin/viewProducts']);
      }, error => {
        console.error('Error updating product:', error); // Log any errors
      });
    } else {
      console.error("Error: 'id' property is undefined in the editing product.");
    }
  }

  cancelEdit(): void {
    this.editingProduct = null;
    localStorage.removeItem('editingProduct');
  }
}
