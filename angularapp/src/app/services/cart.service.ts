import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root',
})
export class CartService {
  public apiUrl =
    'https://8080-bfdeeddcedfabcfacbdcbaeadbebabcdebdca.premiumproject.examly.io';

  constructor(private http: HttpClient) { }

  updateCart(cartDetails: any): any {
    const token = localStorage.getItem('token');
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${token}` // Assuming your token is a bearer token, replace it accordingly
    });
    console.log(cartDetails);
    const cartId = localStorage.getItem('cartId');
    return this.http.put(`${this.apiUrl}/api/cart/update/${cartId}`, cartDetails, { headers });
  }

  removeGiftsFromCart(cartDetails: any, giftId: any): any {
    console.log("cartId", cartDetails.cartId)
    console.log("cartDetails", cartDetails)
    console.log("Gift Details", cartDetails.gifts)
    const token = localStorage.getItem('token');
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${token}` // Assuming your token is a bearer token, replace it accordingly
    });
    return this.http.delete(`${this.apiUrl}/api/cart/${cartDetails.cartId}?giftId=${giftId}`, { headers });
  }

  getGiftsFromCart(cartId: any): any {
    const token = localStorage.getItem('token');
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${token}` // Assuming your token is a bearer token, replace it accordingly
    });
    return this.http.get(`${this.apiUrl}/api/cart/${cartId}`, { headers });
  }


  // getAllGiftsFromCart(): any {
  //   const token = localStorage.getItem('token');
  //   const headers = new HttpHeaders({
  //     'Content-Type': 'application/json',
  //     'Authorization': `Bearer ${token}` // Assuming your token is a bearer token, replace it accordingly
  //   });
  //   const customerId = localStorage.getItem('customerId');
  //   return this.http.get(`${this.apiUrl}/api/cart/customer/${customerId}`, { headers });
  // }

  getAllGiftsFromCart() {
    this.cartService.getAllGiftsFromCart().subscribe(
      (response) => {
        console.log(response);
        if (response && response.gifts) {
          // Check if the gifts property is an array
          if (Array.isArray(response.gifts)) {
            this.gifts = response.gifts;
          } else {
            // If not an array, consider it as a single gift object and convert it to an array
            this.gifts = [response.gifts];
          }
          this.totalAmount = response.totalAmount;
          this.gifts.forEach(gift => {
            gift.userQuantity = 1;
          });
        } else {
          console.error('Invalid response format:', response);
        }
      },
      (error) => {
        console.error(error);
      }
    );
  }
  
  

  addReview(review: any): Observable<any> {
    const token = localStorage.getItem('token');
    // console.log(token)
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${token}` // Assuming your token is a bearer token, replace it accordingly
    });

    return this.http.post(`${this.apiUrl}/api/review`, review, { headers });
  }

  getAllReviews() {
    const token = localStorage.getItem('token');
    // console.log(token)
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${token}` // Assuming your token is a bearer token, replace it accordingly
    });
    return this.http.get(`${this.apiUrl}/api/review`, { headers });
  }

  getTotalAmount(customerId: string): Observable<any> {
    const token = localStorage.getItem('token');
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${token}`
    });
    return this.http.get(`${this.apiUrl}/api/cart/customer/${customerId}/total`, { headers });
  }

}
