import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FullTextSearchResultComponent } from './full-text-search-result.component';

describe('FullTextSearchResultComponent', () => {
  let component: FullTextSearchResultComponent;
  let fixture: ComponentFixture<FullTextSearchResultComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FullTextSearchResultComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FullTextSearchResultComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
