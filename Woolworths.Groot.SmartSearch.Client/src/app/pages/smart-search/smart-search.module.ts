import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { SmartSearchRoutingModule } from './smart-search-routing.module';
import { SmartSearchComponent } from './smart-search/smart-search.component';


@NgModule({
  declarations: [
    SmartSearchComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    SmartSearchRoutingModule,
  ]
})
export class SmartSearchModule { }
