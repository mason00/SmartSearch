import { Component, Input, OnInit } from '@angular/core';
import { SmartsearchService } from '@core/services/smartsearch/smartsearch.service';

@Component({
  selector: 'app-stock-link',
  templateUrl: './stock-link.component.html',
  styleUrls: ['./stock-link.component.css'],
})
export class StockLinkComponent implements OnInit {
  @Input() stockcode: number | undefined;
  @Input() searchText: string | undefined;

  constructor(private smartsearchService: SmartsearchService) {}

  ngOnInit(): void {}

  openStockLink() {
    this.smartsearchService.saveSearchLinkOpenInfo(
      this.getStockLink(),
      this.searchText,
    );
  }

  getStockLink() {
    return `https://www.woolworths.com.au/shop/productdetails/${this.stockcode}`;
  }

  getImgUrl(): string {
    return `https://cdn0.woolworths.media/content/wowproductimages/medium/${this.stockcode}.jpg`;
  }
}
