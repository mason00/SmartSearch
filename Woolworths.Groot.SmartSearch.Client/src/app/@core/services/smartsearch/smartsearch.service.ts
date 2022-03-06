import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { SmartSearchState } from '@core/store/index';
import { selectSmartSearchState } from '@core/store/link-click.selector';
import { environment } from '@env/environment';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { BrandSearchResponse } from './brandSearchResponse';
import { ProductSearchResponse } from './productSearchResponse';

@Injectable({
  providedIn: 'root',
})
export class SmartsearchService {
  constructor(private store: Store<SmartSearchState>, private http: HttpClient){
    this.store.select(selectSmartSearchState).subscribe(state => {
      if (state.link && state.searchTeam)
        this.saveSearchLinkOpenInfo(state.link, state.searchTeam)
    });
  }

  saveSearchLinkOpenInfo(link: string, searchText: string) {
    console.log(`link: ${link}, searchText: ${searchText}`);
  }

  searchProductWithBrand(
    brand: string,
    searchText: string,
  ): Observable<ProductSearchResponse[]> {
    const searchUrl = `${environment.smartSearchUrl}/api/ProductSearch?brand=${brand}&text=${searchText}`;
    return this.http.get<ProductSearchResponse[]>(searchUrl);
  }

  searchProduct(text: string): Observable<ProductSearchResponse[]> {
    const searchUrl = `${environment.smartSearchUrl}/api/ProductSearch/${text}`;
    return this.http.get<ProductSearchResponse[]>(searchUrl);
  }

  fullTextSearchProduct(text: string): Observable<ProductSearchResponse[]> {
    const searchUrl = `${environment.smartSearchUrl}/api/SmartSearch/${text}`;
    return this.http.get<ProductSearchResponse[]>(searchUrl);
  }

  autocompleteOnBrand(text: string): Observable<BrandSearchResponse[]> {
    const searchUrl = `${environment.smartSearchUrl}/api//Brand/autocomplete/${text}`;
    return this.http.get<BrandSearchResponse[]>(searchUrl);
  }
}
