import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { ROUTER_UTILS } from "@core/utils/router.utils";
import { SmartSearchComponent } from "./smart-search/smart-search.component";

const routes: Routes = [
  {
    path: ROUTER_UTILS.config.smartSearch.home,
    component: SmartSearchComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class SmartSearchRoutingModule {}