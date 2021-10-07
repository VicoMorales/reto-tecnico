import { ENDPOINTS } from './../shared/const/enpoints.enum';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ProductDto } from '../models/ProductDto';

@Injectable({
  providedIn: 'root'
})
export class ProductHttp {

  constructor(private http: HttpClient) { }

  addProduct(body:ProductDto):Observable<ProductDto>{
    const httpOptions = {
      headers: new HttpHeaders({
        'Access-Control-Allow-Origin':'*',
        'Content-Type': 'application/json',
        'Access-Control-Allow-Methods': 'GET, POST, OPTIONS, PUT, DELETE, PATCH'
      })
    };

    return this.http.post<ProductDto>(`api/${ENDPOINTS.PRODUCTS}`,body,httpOptions)
  }
  getProducts():Observable<ProductDto[]>{
    const httpOptions = {
      headers: new HttpHeaders({
        'Access-Control-Allow-Origin': '/',
        'Content-Type': 'application/json',
        'Access-Control-Allow-Methods': 'GET, POST, OPTIONS, PUT, DELETE, PATCH'
      })
    };
    return this.http.get<ProductDto[]>(`api/${ENDPOINTS.PRODUCTS}`,httpOptions)
  }
  editProduct(body:ProductDto):Observable<ProductDto>{
    const httpOptions = {
      headers: new HttpHeaders({
        'Access-Control-Allow-Origin':'*',
        'Content-Type': 'application/json',
        'Access-Control-Allow-Methods': 'GET, POST, OPTIONS, PUT, DELETE, PATCH'
      })
    };

    return this.http.put<ProductDto>(`api/${ENDPOINTS.PRODUCTS}`,body,httpOptions)
  }
  deleteProduct(guid:string):Observable<ProductDto>{
    const httpOptions = {
      headers: new HttpHeaders({
        'Access-Control-Allow-Origin':'*',
        'Content-Type': 'application/json',
        'Access-Control-Allow-Methods': 'GET, POST, OPTIONS, PUT, DELETE, PATCH'
      })
    };

    return this.http.delete<ProductDto>(`api/${ENDPOINTS.PRODUCTS}/${guid}`)
  }
}
