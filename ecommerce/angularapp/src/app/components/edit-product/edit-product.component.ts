import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Product } from 'src/app/models/product';
import { ProductService } from 'src/app/services/product.service';

@Component({
  selector: 'app-edit-product',
  templateUrl: './edit-product.component.html',
  styleUrls: ['./edit-product.component.css']
})
export class EditProductComponent implements OnInit {
  productId: number;
  product: Product = {} as Product;

  constructor(
    private route: ActivatedRoute, 
    private router: Router,
    private productService: ProductService
  ) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.productId = +params['id'];
      if (this.productId) {
        this.productService.getProduct(this.productId).subscribe(
          (product: Product) => {
            this.product = product;
          },
          error => {
            console.error('Error fetching product:', error);
          }
        );
      }
    });
  }

  onSubmit(): void {
    this.productService.updateProduct(this.product).subscribe(
      () => {
        console.log('Product updated successfully.');
        this.router.navigate(['/admin/viewProducts']);
      },
      (error) => {
        console.error('Error updating product:', error);
      }
    );
  }

  resetForm(): void {
    this.router.navigate(['/admin/viewProducts']);
  }
}
