import { Component, Input, OnInit } from '@angular/core';
import { ProductSearchResponse } from '@core/services/smartsearch/productSearchResponse';

@Component({
  selector: 'app-fuzzy-search-result',
  templateUrl: './fuzzy-search-result.component.html',
  styleUrls: ['./fuzzy-search-result.component.css']
})
export class FuzzySearchResultComponent implements OnInit {
  @Input()
  fuzzySearchResult: ProductSearchResponse[] = [];
  displayedColumns: string[] = ['name', 'brand', 'description'];

  constructor() { }

  ngOnInit(): void {
  }

}
