import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatTableModule } from '@angular/material/table';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FullTextSearchResultComponent } from './full-text-search-result/full-text-search-result.component';
import { FuzzySearchResultComponent } from './fuzzy-search-result/fuzzy-search-result.component';
import { SmartSearchRoutingModule } from './smart-search-routing.module';
import { SmartSearchComponent } from './smart-search/smart-search.component';
import { StockLinkComponent } from './stock-link/stock-link.component';


@NgModule({
  declarations: [
    SmartSearchComponent,
    FuzzySearchResultComponent,
    FullTextSearchResultComponent,
    StockLinkComponent,
  ],
  imports: [
    CommonModule,
    FormsModule,
    MatTableModule,
    SmartSearchRoutingModule,
    NgbModule,
  ]
})
export class SmartSearchModule { }
