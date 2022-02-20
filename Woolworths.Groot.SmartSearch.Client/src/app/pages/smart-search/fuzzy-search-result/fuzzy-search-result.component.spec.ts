import { ComponentFixture, TestBed } from '@angular/core/testing';
import { FuzzySearchResultComponent } from './fuzzy-search-result.component';

describe('FuzzySearchResultComponent', () => {
  let component: FuzzySearchResultComponent;
  let fixture: ComponentFixture<FuzzySearchResultComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FuzzySearchResultComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FuzzySearchResultComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
