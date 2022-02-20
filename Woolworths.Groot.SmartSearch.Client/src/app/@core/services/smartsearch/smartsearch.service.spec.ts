import { TestBed } from '@angular/core/testing';

import { SmartsearchService } from './smartsearch.service';

describe('SmartsearchService', () => {
  let service: SmartsearchService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SmartsearchService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
