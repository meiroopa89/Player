// import { Component, OnInit } from '@angular/core';
// import { ProductService } from '../../services/product.service';
// import { Product } from '../../models/product';
// import { Router } from '@angular/router';

// @Component({
//   selector: 'app-view-product',
//   templateUrl: './view-product.component.html',
//   styleUrls: ['./view-product.component.css']
// })
// export class ViewProductComponent implements OnInit {
//   products: Product[] = [];

//   constructor(private productService: ProductService, private router: Router) { }

//   ngOnInit(): void {
//     this.getProducts();
//   }

//   getProducts(): void {
//     this.productService.getProducts().subscribe(
//       products => {
//         console.log('Fetched products:', products);
//         this.products = products;
//       },
//       error => {
//         console.error('Error fetching products:', error);
//       }
//     );
//   }

//   editProduct(product: Product): void {
//     if (product && product.id !== undefined) {
//       console.log('Navigating to edit product with id:', product.id);
//       this.router.navigate(['/edit-product', product.id]);
//     } else {
//       console.error('Product id is undefined:', product);
//     }
//   }

//   deleteProduct(productId: number): void {
//     this.router.navigate(['/confirmDelete', productId]);
//   }
// }


import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Product } from 'src/app/models/product';


@Component({
  selector: 'app-view-product',
  templateUrl: './view-product.component.html',
  styleUrls: ['./view-product.component.css']
})
export class ViewProductComponent implements OnInit {
  products: Product[] = [];
  editingProduct: Product | null = null;

  constructor(private productService: ProductService, private router: Router) {}

  ngOnInit(): void {
    this.loadProducts();
  }

  loadProducts(): void {
    this.productService.getProducts().subscribe(products => {
      this.products = products;
    });
  }

  deleteProduct(productId: number): void {
    this.productService.deleteProduct(productId).subscribe(() => {
      this.products = this.products.filter(product => product.id !== productId);
    });
  }

  editProduct(product: Product): void {
    // Make sure to clone the product and set its 'id' property
    this.editingProduct = { ...product, id: product.id };
  }

  updateProduct(): void {
    if (this.editingProduct && this.editingProduct.id) {
      this.productService.updateProduct(this.editingProduct).subscribe(updatedProduct => {
        const index = this.products.findIndex(product => product.id === updatedProduct.id);
        if (index !== -1) {
          this.products[index] = updatedProduct;
          this.editingProduct = null;
          this.router.navigate(['/admin/viewProducts']); // Navigate back to the view product component
        }
      });
    } else {
      console.error("Error: 'id' property is undefined in the editing product.");
    }
  }

  cancelEdit(): void {
    this.editingProduct = null;
  }
}

