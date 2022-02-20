import { Component, OnInit } from '@angular/core';
import { SmartsearchService } from '@core/services/smartsearch/smartsearch.service';

@Component({
  selector: 'app-smart-search',
  templateUrl: './smart-search.component.html',
  styleUrls: ['./smart-search.component.css']
})
export class SmartSearchComponent implements OnInit {
  searchText = '';

  constructor(private smartsearchService: SmartsearchService) { }

  ngOnInit(): void {
    
  }

  handlekeypress(e: KeyboardEvent) {
    if (e.code == 'Enter')
      // console.log(`searchText: ${this.searchText}`);
      this.smartsearchService.searchProduct(this.searchText);
  }
}
