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
export class EditProductComponent implements OnInit {
  editProductForm: FormGroup;
  product: Product;
  errorMessage = '';

  photoImage = '';

  constructor(
    private fb: FormBuilder,
    private productService: ProductService,
    private route: ActivatedRoute,
    private router: Router
  ) {
    this.editProductForm = this.fb.group({
      name: ['', Validators.required],
      imageUrl: ['', Validators.required],
      description: ['', Validators.required],
      price: ['', [Validators.required, Validators.pattern('^[0-9]*$')]],
      stockQuantity: ['', [Validators.required, Validators.min(1)]],
      category: ['', Validators.required]
    });
  }

  ngOnInit(): void {
    // Retrieve the product ID from the route parameters
    const productId = this.route.snapshot.paramMap.get('id');
    if (productId) {
      this.productService.getProduct(+productId).subscribe(
        (product: Product) => {
          this.product = product;
          this.editProductForm.patchValue({
            name: product.name,
            imageUrl: product.imageUrl,
            description: product.description,
            price: product.price,
            stockQuantity: product.stockQuantity,
            category: product.category
          });
        },
        (error) => {
          console.error('Error fetching product:', error);
        }
      );
    }
  }

  onSubmit(): void {
    if (this.editProductForm.valid) {
      const updatedProduct = this.editProductForm.value;

      const requestObj: Product = {
        id: this.product.id,
        name: updatedProduct.name,
        imageUrl: this.photoImage || updatedProduct.imageUrl,
        description: updatedProduct.description,
        price: updatedProduct.price,
        stockQuantity: updatedProduct.stockQuantity,
        category: updatedProduct.category
      };

      this.productService.updateProduct(requestObj).subscribe(
        (response) => {
          console.log('Product updated successfully', response);
          this.product = response;
          this.router.navigate(['admin/viewProducts']);
        },
        (error) => {
          console.error('Error updating product', error);
        }
      );
    }
  }

  handleFileChange(event: any): void {
    const file = event.target.files[0];

    if (file) {
      this.convertFileToBase64(file).then(
        (base64String) => {
          this.photoImage = base64String;
          console.log(this.photoImage, 'final');
        },
        (error) => {
          console.error('Error converting file to base64:', error);
        }
      );
    }
  }

  convertFileToBase64(file: File): Promise<string> {
    return new Promise((resolve, reject) => {
      const reader = new FileReader();

      reader.onload = () => {
        resolve(reader.result as string);
      };

      reader.onerror = (error) => {
        reject(error);
      };

      reader.readAsDataURL(file);
    });
  }

  onCancel(): void {
    this.router.navigate(['admin/viewProducts']);
  }
}
