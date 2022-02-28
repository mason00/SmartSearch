import { Component, Input, OnInit } from '@angular/core';
import { ProductSearchResponse } from '@core/services/smartsearch/productSearchResponse';

@Component({
  selector: 'app-fuzzy-search-result',
  templateUrl: './fuzzy-search-result.component.html',
  styleUrls: ['./fuzzy-search-result.component.css'],
})
export class FuzzySearchResultComponent implements OnInit {
  @Input() fuzzySearchResult: ProductSearchResponse[] = [];
  @Input() searchText = '';
  // displayedColumns: string[] = ['name', 'brand', 'description'];

  constructor() {}

  ngOnInit(): void {}

  getImgUrl(stockcode: number | undefined): string {
    return `https://cdn0.woolworths.media/content/wowproductimages/medium/${stockcode}.jpg`;
  }
}
