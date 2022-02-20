import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '@env/environment';
import { Observable } from 'rxjs';
import { ProductSearchResponse } from './productSearchResponse';

@Injectable({
  providedIn: 'root'
})
export class SmartsearchService {

  constructor(private http: HttpClient) { }

  searchProduct(text: string): Observable<ProductSearchResponse[]>{
    console.log(`smartSearchUrl ${environment.smartSearchUrl}`);

    const searchUrl = `${environment.smartSearchUrl}/api/ProductSearch/${text}`;
    return this.http.get<ProductSearchResponse[]>(searchUrl)
      // .subscribe(data => console.log(`data: ${data}`))
      ;
  }
}
