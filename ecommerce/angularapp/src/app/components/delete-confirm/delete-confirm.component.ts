import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Product } from 'src/app/models/product';
import { ProductService } from 'src/app/services/product.service';


@Component({
  selector: 'app-delete-confirm', // Component selector
  templateUrl: './delete-confirm.component.html',
  styleUrls: ['./delete-confirm.component.css']
})
export class DeleteConfirmComponent implements OnInit {
  productId: number;
  product: Product = {} as Product; // Initialize product property with an empty object

  constructor(
    private route: ActivatedRoute, 
    private router: Router,
    private productService: ProductService // Adjusted service name
  ) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.productId = +params['id']; // Adjust parameter name
      this.productService.getProduct(this.productId).subscribe(
        (product: Product) => { // Adjust type casting
          this.product = product;
        },
        error => {
          console.error('Error fetching product:', error);
        }
      );
    });
  }

  confirmDelete(productId: number): void { // Adjust method signature
    this.productService.deleteProduct(productId).subscribe(
      () => {
        console.log('Product deleted successfully.');
        this.router.navigate(['/admin/viewProducts']); // Adjust the route
      },
      (error) => {
        console.error('Error deleting product:', error);
      }
    );
  }

  cancelDelete(): void {
    this.router.navigate(['/admin/viewProducts']); // Adjust the route
  }
}
