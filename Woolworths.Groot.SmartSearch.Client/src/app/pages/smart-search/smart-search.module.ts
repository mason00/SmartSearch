import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatTableModule } from '@angular/material/table';
import { FuzzySearchResultComponent } from './fuzzy-search-result/fuzzy-search-result.component';
import { SmartSearchRoutingModule } from './smart-search-routing.module';
import { SmartSearchComponent } from './smart-search/smart-search.component';


@NgModule({
  declarations: [
    SmartSearchComponent,
    FuzzySearchResultComponent,
  ],
  imports: [
    CommonModule,
    FormsModule,
    MatTableModule,
    SmartSearchRoutingModule,
  ]
})
export class SmartSearchModule { }
