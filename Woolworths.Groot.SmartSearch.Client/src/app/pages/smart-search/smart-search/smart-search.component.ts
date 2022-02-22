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
          .subscribe(r => this.fuzzySearchResult = r);
          break;
      }
    }
  }
}
