import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StockLinkComponent } from './stock-link.component';

describe('StockLinkComponent', () => {
  let component: StockLinkComponent;
  let fixture: ComponentFixture<StockLinkComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ StockLinkComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(StockLinkComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
