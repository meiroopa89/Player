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
import { ProductService } from 'src/app/services/product.service';

@Component({
  selector: 'app-view-product',
  templateUrl: './view-product.component.html',
  styleUrls: ['./view-product.component.css']
})
export class ViewProductComponent implements OnInit {
  products: Product[] = [];
  editingProduct: Product | null = null;
  readonly localStorageKey = 'products';

  constructor(private productService: ProductService, private router: Router) {}

  ngOnInit(): void {
    this.loadProducts();
  }

  loadProducts(): void {
    const storedProducts = localStorage.getItem(this.localStorageKey);
    if (storedProducts) {
      this.products = JSON.parse(storedProducts);
    } else {
      this.productService.getProducts().subscribe(products => {
        this.products = products;
        localStorage.setItem(this.localStorageKey, JSON.stringify(products));
      });
    }
  }

  deleteProduct(productId: number): void {
    this.router.navigate(['/confirmDelete', productId]);
  }

  editProduct(product: Product): void {
    if (product && product.productId !== undefined) {
      this.editingProduct = { ...product };
      console.log('Editing product:', this.editingProduct); // Log to ensure id is present
      localStorage.setItem('editingProduct', JSON.stringify(this.editingProduct));
    } else {
      console.error('Product id is undefined:', product);
    }
  }

  updateProduct(): void {
    if (this.editingProduct && this.editingProduct.productId) {
      console.log('Updating product with id:', this.editingProduct.productId); // Log to ensure id is being used
      this.productService.updateProduct(this.editingProduct).subscribe(updatedProduct => {
        const index = this.products.findIndex(product => product.productId === updatedProduct.productId);
        if (index !== -1) {
          this.products[index] = updatedProduct;
          localStorage.setItem(this.localStorageKey, JSON.stringify(this.products));
          this.editingProduct = null;
          this.router.navigate(['/admin/viewProducts']);
        }
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
