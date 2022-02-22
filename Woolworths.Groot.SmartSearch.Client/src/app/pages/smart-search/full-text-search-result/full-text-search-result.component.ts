import { Component, Input, OnInit } from '@angular/core';
import { ProductSearchResponse } from '@core/services/smartsearch/productSearchResponse';

@Component({
  selector: 'app-full-text-search-result',
  templateUrl: './full-text-search-result.component.html',
  styleUrls: ['./full-text-search-result.component.css']
})
export class FullTextSearchResultComponent implements OnInit {
  @Input()
  fullTextSearchResult: ProductSearchResponse[] = [];
  displayedColumns: string[] = ['name', 'brand', 'description'];

  constructor() { }

  ngOnInit(): void {
  }

}
