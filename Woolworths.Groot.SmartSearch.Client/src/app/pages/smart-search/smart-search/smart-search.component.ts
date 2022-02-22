import { Component, OnInit } from '@angular/core';
import { ProductSearchResponse } from '@core/services/smartsearch/productSearchResponse';
import { SmartsearchService } from '@core/services/smartsearch/smartsearch.service';

@Component({
  selector: 'app-smart-search',
  templateUrl: './smart-search.component.html',
  styleUrls: ['./smart-search.component.css']
})
export class SmartSearchComponent implements OnInit {
  searchText = '';
  searchType = 'fullText';

  fuzzySearchResult: ProductSearchResponse[] = [];
  fullTextSearchResult: ProductSearchResponse[] = [];

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
}
function transformFuzzyResult(r: ProductSearchResponse[]): ProductSearchResponse[] {
   r.forEach(result => {
    var brandHightLight = highLightPath(result, 'Brand');
    if (brandHightLight) {
      result.brand = brandHightLight;
    }

    var nameHightLight = highLightPath(result, 'GenericProductName');
    if (nameHightLight) {
      result.name = nameHightLight;
    }
    
    var descHightLight = highLightPath(result, 'Description');
    if (descHightLight) {
      result.description = descHightLight;
    }
  })

  return r;
}

function highLightPath(result: ProductSearchResponse, path: string) {
  var nameHighLight = result.highLights?.find(x => x.path === path);
  var highLightMark = '';
  if (nameHighLight) {
    nameHighLight.texts?.forEach(c => {
      highLightMark = c.type === 'hit' ? highLightMark + `<mark>${c.value}</mark>` : highLightMark + c.value;
      return c;
    });
  }
  return highLightMark;
}

