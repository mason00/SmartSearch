import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '@env/environment';
import { Observable } from 'rxjs';
import { BrandSearchResponse } from './brandSearchResponse';
import { ProductSearchResponse } from './productSearchResponse';

@Injectable({
  providedIn: 'root'
})
export class SmartsearchService {
  searchProductWithBrand(searchText: string): Observable<ProductSearchResponse[]>{
    throw new Error('Method not implemented.');
  }

  constructor(private http: HttpClient) { }

  searchProduct(text: string): Observable<ProductSearchResponse[]>{
    console.log(`smartSearchUrl ${environment.smartSearchUrl}`);

    const searchUrl = `${environment.smartSearchUrl}/api/ProductSearch/${text}`;
    return this.http.get<ProductSearchResponse[]>(searchUrl);
  }

  fullTextSearchProduct(text: string): Observable<ProductSearchResponse[]>{
    console.log(`smartSearchUrl ${environment.smartSearchUrl}`);

    const searchUrl = `${environment.smartSearchUrl}/api/SmartSearch/${text}`;
    return this.http.get<ProductSearchResponse[]>(searchUrl);
  }

  autocompleteOnBrand(text: string): Observable<BrandSearchResponse[]>{
    console.log(`smartSearchUrl ${environment.smartSearchUrl}`);

    const searchUrl = `${environment.smartSearchUrl}/api//Brand/autocomplete/${text}`;
    return this.http.get<BrandSearchResponse[]>(searchUrl);
  }
}
