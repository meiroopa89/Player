import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ProductService } from '../../services/product.service';
import { Product } from '../../models/product';

@Component({
  selector: 'app-edit-product',
  templateUrl: './edit-product.component.html',
  styleUrls: ['./edit-product.component.css']
})
export class EditProductComponent implements OnInit {
  product: Product = {
    id: 0,
    name: '',
    description: '',
    price: 0,
    imageUrl: '',
    category: ''
  };

  constructor(
    private productService: ProductService,
    private router: Router,
    private route: ActivatedRoute
  ) { }

  ngOnInit(): void {
    const productId = this.route.snapshot.params['id'];
    this.productService.getProduct(productId).subscribe(
      (product: Product) => {
        this.product = product;
      },
      error => {
        console.error('Error fetching product:', error);
      }
    );
  }

  onSubmit(): void {
    this.productService.updateProduct(this.product).subscribe(
      () => {
        console.log('Product updated successfully');
        this.router.navigate(['/admin/viewProducts']);
      },
      error => {
        console.error('Error updating product:', error);
      }
    );
  }
}
