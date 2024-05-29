import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Product } from 'src/app/models/product';
import { ProductService } from 'src/app/services/product.service';

@Component({
  selector: 'app-view-product',
  templateUrl: './view-product.component.html',
  styleUrls: ['./view-product.component.css']
})
export class ViewProductComponent implements OnInit {
  products: Product[] = [];

  constructor(private productService: ProductService, private router: Router) {}

  ngOnInit(): void {
    this.loadProducts();
  }

  loadProducts(): void {
    this.productService.getProducts().subscribe(products => {
      this.products = products;
    }, error => {
      console.error('Error fetching products:', error);
    });
  }

  deleteProduct(productId: number): void {
    this.router.navigate(['/confirmDelete', productId]);
  }

  editProduct(product: Product): void {
    if (product && product.productId !== undefined) {
      this.router.navigate(['/edit-product', product.productId]);
    } else {
      console.error('Product id is undefined:', product);
    }
  }

  // Method to handle the productUpdated event
  onProductUpdated(): void {
    this.loadProducts(); // Refresh the product list
  }
}
