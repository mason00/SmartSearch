import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { SmartSearchComponent } from "./smart-search/smart-search.component";

const routes: Routes = [
  {
    path: '',
    component: SmartSearchComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class SmartSearchRoutingModule {}