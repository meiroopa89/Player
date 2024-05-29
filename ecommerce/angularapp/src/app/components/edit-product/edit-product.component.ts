import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ProductService } from 'src/app/services/product.service';
import { Product } from 'src/app/models/product';

@Component({
  selector: 'app-edit-product',
  templateUrl: './edit-product.component.html',
  styleUrls: ['./edit-product.component.css']
})
export class EditProductComponent implements OnInit {
  editingProduct: Product | null = null;

  constructor(
    private route: ActivatedRoute,
    private productService: ProductService,
    private router: Router
  ) {}

  ngOnInit(): void {
    const productId = this.route.snapshot.paramMap.get('id');
    if (productId) {
      this.productService.getProduct(+productId).subscribe(product => {
        this.editingProduct = product;
      }, error => {
        console.error('Error fetching product:', error);
      });
    } else {
      console.error('Product ID is missing in the route parameters.');
    }
  }

  updateProduct(): void {
    if (this.editingProduct && this.editingProduct.productId) {
      this.productService.updateProduct(this.editingProduct).subscribe(updatedProduct => {
        console.log('Updated product:', updatedProduct); // Log the server response
        this.router.navigate(['/admin/viewProducts'], { state: { refresh: true } });
      }, error => {
        console.error('Error updating product:', error); // Log any errors
      });
    } else {
      console.error("Error: 'id' property is undefined in the editing product.");
    }
  }

  cancelEdit(): void {
    this.editingProduct = null;
    this.router.navigate(['/admin/viewProducts']);
  }
}
