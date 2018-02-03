import { TestBed, inject } from '@angular/core/testing';

import { ActivityapiclientService } from './activityapiclient.service';

describe('ActivityapiclientService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ActivityapiclientService]
    });
  });

  it('should be created', inject([ActivityapiclientService], (service: ActivityapiclientService) => {
    expect(service).toBeTruthy();
  }));
});
