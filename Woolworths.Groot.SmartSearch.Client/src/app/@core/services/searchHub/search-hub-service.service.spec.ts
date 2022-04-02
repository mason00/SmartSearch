import { TestBed } from '@angular/core/testing';

import { SearchHubServiceService } from './search-hub-service.service';

describe('SearchHubServiceService', () => {
  let service: SearchHubServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SearchHubServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
