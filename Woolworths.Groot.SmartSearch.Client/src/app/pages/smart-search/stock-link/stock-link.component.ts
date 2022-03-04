import { Component, Input, OnInit } from '@angular/core';
import { SmartsearchService } from '@core/services/smartsearch/smartsearch.service';
import { Store } from '@ngrx/store';
import { SmartSearchState } from './../../../@core/store/index';

@Component({
  selector: 'app-stock-link',
  templateUrl: './stock-link.component.html',
  styleUrls: ['./stock-link.component.css'],
})
export class StockLinkComponent implements OnInit {
  @Input() stockcode: number | undefined;
  @Input() searchText: string | undefined;

  constructor(private smartsearchService: SmartsearchService, private store: Store<SmartSearchState>) {}

  ngOnInit(): void {}

  openStockLink() {
    const productLink = this.getStockLink();
    // this.smartsearchService.saveSearchLinkOpenInfo(
    //   productLink,
    //   this.searchText,
    // );
    // this.store.dispatch(ProductLinkClicked({ linkClickInfo: { stockCode: this.stockcode, link: productLink}}))
    // this.store.dispatch(new ProductLinkClicked({ stockCode: this.stockcode, link: productLink}));
  }

  getStockLink() {
    return `https://www.woolworths.com.au/shop/productdetails/${this.stockcode}`;
  }

  getImgUrl(): string {
    return `https://cdn0.woolworths.media/content/wowproductimages/medium/${this.stockcode}.jpg`;
  }
}
