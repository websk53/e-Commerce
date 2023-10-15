import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Product } from './Models/Product';
import { Pagination } from './Models/Pagination';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'e-Commerce';
  products: Product[] = [];
  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.http.get<Pagination<Product[]>>('https://localhost:5001/api/products?pagesize=50').subscribe({
      next: response => this.products = response.data, //next operation
      error: error => console.log(error), //error
      complete: () => {
        console.log("request completed");
      }
    })
  }
}
