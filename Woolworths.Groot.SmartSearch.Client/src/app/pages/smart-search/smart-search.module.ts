import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatTableModule } from '@angular/material/table';
import { FuzzySearchResultComponent } from './fuzzy-search-result/fuzzy-search-result.component';
import { SmartSearchRoutingModule } from './smart-search-routing.module';
import { SmartSearchComponent } from './smart-search/smart-search.component';
import { FullTextSearchResultComponent } from './full-text-search-result/full-text-search-result.component';


@NgModule({
  declarations: [
    SmartSearchComponent,
    FuzzySearchResultComponent,
    FullTextSearchResultComponent,
  ],
  imports: [
    CommonModule,
    FormsModule,
    MatTableModule,
    SmartSearchRoutingModule,
  ]
})
export class SmartSearchModule { }
