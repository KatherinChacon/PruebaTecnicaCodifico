import { TestBed } from '@angular/core/testing';

import { DialogNewService } from './dialog-new.service';

describe('DialogNewService', () => {
  let service: DialogNewService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DialogNewService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
