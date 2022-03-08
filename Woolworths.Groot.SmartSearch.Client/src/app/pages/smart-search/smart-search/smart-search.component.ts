import { Component, OnInit } from '@angular/core';
import { BrandSearchResponse } from '@core/services/smartsearch/brandSearchResponse';
import { ProductSearchResponse } from '@core/services/smartsearch/productSearchResponse';
import { SmartsearchService } from '@core/services/smartsearch/smartsearch.service';
import { SmartSearchState } from '@core/store';
import { NgbTypeaheadSelectItemEvent } from '@ng-bootstrap/ng-bootstrap';
import { Store } from '@ngrx/store';
import { catchError, debounceTime, distinctUntilChanged, Observable, of, OperatorFunction, switchMap, tap } from 'rxjs';
import { selectSmartSearchState } from './../../../@core/store/link-click.selector';

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
  selectedBrand = '';
  noResult = false;

  fuzzySearchResult: ProductSearchResponse[] = [];
  fullTextSearchResult: ProductSearchResponse[] = [];
  autocompleteSearchResult: BrandSearchResponse[] = [];

  constructor(private smartsearchService: SmartsearchService, private store: Store<SmartSearchState>) { }

  ngOnInit(): void {
    this.store.select(selectSmartSearchState).subscribe(state => {
      if (state.link)
        this.smartsearchService.saveSearchLinkOpenInfo(state.link, this.searchText)
    });
  }

  handlekeypress(e: KeyboardEvent) {
    if (e.code === 'Enter') {
      console.log(`searchType: ${this.searchType}`);

      this.fullTextSearchResult = [];
      this.fuzzySearchResult = [];

      switch (this.searchType) {
        case 'fullText' :
          this.noResult = false;
          this.smartsearchService.fullTextSearchProduct(this.searchText)
          .subscribe(r => { if(!this.checkNoResult(r)) this.fullTextSearchResult = r; });
          break;
        case 'fuzzy' :
        case 'autocomplete' :
          this.noResult = false;
          if (this.selectedBrand === '') {
            this.smartsearchService.searchProduct(this.searchText)
            .subscribe(r => this.fuzzySearchResult = transformFuzzyResult(r));
          } else {
            this.smartsearchService.searchProductWithBrand(this.selectedBrand, this.searchText)
            .subscribe(r => this.fuzzySearchResult = transformFuzzyResult(r));
          }
          break;
      }
    }
  }

  checkNoResult(result: unknown[]): boolean {
    return this.noResult = result?.length > 0 ? false : true;
  }

  removeSelectedBrand(){
    this.selectedBrand = '';
  }

  itemSelected(selectedItem: NgbTypeaheadSelectItemEvent) {
    this.selectedBrand = selectedItem.item;
    this.searchText = '';
    selectedItem.preventDefault();
  }

  search: OperatorFunction<string, readonly string[]> = (text$: Observable<string>) =>
    text$.pipe(
      debounceTime(300),
      distinctUntilChanged(),
      tap(() => this.searching = true),
      switchMap(term => {
        if (this.searchType === 'autocomplete' && this.selectedBrand === ''){
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
