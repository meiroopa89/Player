import { Component, OnInit } from '@angular/core';
import { ProductService } from '../../services/product.service';
import { Product } from '../../models/product';
import { Router } from '@angular/router';

@Component({
  selector: 'app-view-product',
  templateUrl: './view-product.component.html',
  styleUrls: ['./view-product.component.css']
})
export class ViewProductComponent implements OnInit {
  products: Product[] = [];

  constructor(private productService: ProductService, private router: Router) { }

  ngOnInit(): void {
    this.getProducts();
  }

  getProducts(): void {
    this.productService.getProducts().subscribe(
      products => {
        console.log('Fetched products:', products);
        this.products = products;
      },
      error => {
        console.error('Error fetching products:', error);
      }
    );
  }

  editProduct(product: Product): void {
    if (product && product.id !== undefined) {
      console.log('Navigating to edit product with id:', product.id);
      this.router.navigate(['/edit-product', product.id]);
    } else {
      console.error('Product id is undefined:', product);
    }
  }

  deleteProduct(productId: number): void {
    this.router.navigate(['/confirmDelete', productId]);
  }
}
