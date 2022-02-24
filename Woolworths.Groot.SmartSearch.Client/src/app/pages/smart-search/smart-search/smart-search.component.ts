import { Component, OnInit } from '@angular/core';
import { BrandSearchResponse } from '@core/services/smartsearch/brandSearchResponse';
import { ProductSearchResponse } from '@core/services/smartsearch/productSearchResponse';
import { SmartsearchService } from '@core/services/smartsearch/smartsearch.service';
import { catchError, debounceTime, distinctUntilChanged, Observable, of, OperatorFunction, switchMap, tap } from 'rxjs';

@Component({
  selector: 'app-smart-search',
  templateUrl: './smart-search.component.html',
  styleUrls: ['./smart-search.component.css'],
})
export class SmartSearchComponent implements OnInit {
  searchText = '';
  searchType = 'fullText';
  searching = false;
  searchFailed = false;

  fuzzySearchResult: ProductSearchResponse[] = [];
  fullTextSearchResult: ProductSearchResponse[] = [];
  autocompleteSearchResult: BrandSearchResponse[] = [];

  constructor(private smartsearchService: SmartsearchService) { }

  ngOnInit(): void {

  }

  handlekeypress(e: KeyboardEvent) {
    if (e.code === 'Enter') {
      console.log(`searchType: ${this.searchType}`);

      this.fullTextSearchResult = [];
      this.fuzzySearchResult = [];

      switch (this.searchType) {
        case 'fullText' :
          this.smartsearchService.fullTextSearchProduct(this.searchText)
          .subscribe(r => this.fullTextSearchResult = r);
          break;
        case 'fuzzy' :
          this.smartsearchService.searchProduct(this.searchText)
          .subscribe(r => this.fuzzySearchResult = transformFuzzyResult(r));
          break;
      }
    }
  }

  search: OperatorFunction<string, readonly string[]> = (text$: Observable<string>) =>
    text$.pipe(
      debounceTime(300),
      distinctUntilChanged(),
      tap(() => this.searching = true),
      switchMap(term => {
        if (this.searchType === 'autocomplete'){
          return this.smartsearchService.autocompleteOnBrand(term).pipe(
            switchMap((results: BrandSearchResponse[]) => {
              return of(results.map(x => x.brandName));
            }),
            tap(() => this.searchFailed = false),
            catchError(() => {
              this.searchFailed = true;
              return of([]);
            }))
          }
        return of([]);
      }),
      tap(() => this.searching = false)
    )
  }

function transformFuzzyResult(r: ProductSearchResponse[]): ProductSearchResponse[] {
   r.forEach(result => {
    const brandHightLight = highLightPath(result, 'Brand');
    if (brandHightLight) {
      result.brand = brandHightLight;
    }

    const nameHightLight = highLightPath(result, 'GenericProductName');
    if (nameHightLight) {
      result.name = nameHightLight;
    }

    const descHightLight = highLightPath(result, 'Description');
    if (descHightLight) {
      result.description = descHightLight;
    }
  })

  return r;
}

function highLightPath(result: ProductSearchResponse, path: string) {
  const nameHighLight = result.highLights?.find(x => x.path === path);
  let highLightMark = '';
  if (nameHighLight) {
    nameHighLight.texts?.forEach(c => {
      highLightMark = c.type === 'hit' ? highLightMark + `<mark>${c.value}</mark>` : highLightMark + c.value;
      return c;
    });
  }
  return highLightMark;
}
