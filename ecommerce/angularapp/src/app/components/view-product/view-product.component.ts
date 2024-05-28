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
        console.log('Fetched products:', products); // Log the fetched products
        this.products = products;
      },
      error => {
        console.error('Error fetching products:', error);
      }
    );
  }
  

  editProduct(product: Product): void {
    console.log('Product object:', product); // Log the product object
    console.log('Navigating to edit product with id:', product.id); // Log the product id
    this.router.navigate(['/edit-product', product.id]);
  }
  

  deletePlayer(productId: number): void { // Adjusted method name and parameter
    // Navigate to confirm delete page with the player ID as a parameter
    this.router.navigate(['/confirmDelete', productId]);
  }
    
}
